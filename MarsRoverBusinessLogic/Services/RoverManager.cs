using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MarsRoverDAL.DAObjects;
using MarsRoverDAL.ORM;

namespace MarsRoverBusinessLogic.Services
{
    public class RoverManager : IRoverManager
    {
        public const string OutOfRangeErrorMsg = "Error... Rover went out of terrain!";
        public const string ParsingErrorMsg = "Parsing Error... Please check your input!";
        public const string RoverLimitExceededErrorMsg = "No more than 5 rovers please!";
        public const string TrailHitErrorMsg = "You hit your trail somewhere. Be careful!";

        public const int MAX_ROVER_COUNT = 5;
        public const string OUTPUT_TRAIL_KEY = "OutputTrailKey";
        public const string STEP_COUNT_KEY = "StepCountKey";
        public const string ROVER_COUNT_KEY = "RoverCountKey";

        IInputParser _inputParser;
        IRoverCommander _roverCommander;
        IMarsRoverDbAccessor _dbAccessor;
        
        public RoverManager(IInputParser inputParser, IRoverCommander roverCommander, IMarsRoverDbAccessor dbAccessor)
        {
            _inputParser = inputParser;
            _roverCommander = roverCommander;
            _dbAccessor = dbAccessor;
        }

        public Dictionary<string, string> GenerateGameResultInfo(string inputData)
        {
            var gameResults = new Dictionary<string, string>();
            InputEntity inputCommands;
            try
            {
                inputCommands = _inputParser.ParseInput(inputData);
            }
            catch (ApplicationException ex)
            {
                gameResults.Add(OUTPUT_TRAIL_KEY, ex.Message);
                return gameResults;
            }
            catch (Exception)
            {
                gameResults.Add(OUTPUT_TRAIL_KEY, ParsingErrorMsg);
                return gameResults;
            }

            if (!IsRoverCountInRange(inputCommands))
            {
                gameResults.Add(OUTPUT_TRAIL_KEY, RoverLimitExceededErrorMsg);
                return gameResults;
            }

            string outputTrailInfo = "";
            try
            {
                 outputTrailInfo = GenerateOutputTrailInfo(inputCommands);
            }catch (ApplicationException e)
            {
                outputTrailInfo = e.Message;
                return gameResults;
            }finally {
                gameResults.Add(OUTPUT_TRAIL_KEY, outputTrailInfo);
            }

            var roverCountInfo = GenerateRoverCountInfo(inputCommands);
            gameResults.Add(ROVER_COUNT_KEY, roverCountInfo);

            var cumulativeStepCountInfo = GenerateCumulativeStepCountInfo(inputCommands);
            gameResults.Add(STEP_COUNT_KEY, cumulativeStepCountInfo);

            return gameResults;
        }

        private string GenerateRoverCountInfo(InputEntity inputCommands)
        {
            return inputCommands.RoverTrails.Count().ToString();
        }

        private string GenerateCumulativeStepCountInfo(InputEntity inputCommands)
        {
            //TODO: convert to linq
            int stepCount =0;
            foreach (var rt in inputCommands.RoverTrails)
            {
                foreach (var ac in rt.ActionCommands)
                {
                    if (ac == RoverCommand.M)
                        stepCount++;
                }
            }
         
            return stepCount.ToString();                             
            
        }

        private string GenerateOutputTrailInfo(InputEntity inputCommands)
        {
            var output = new StringBuilder();
            foreach (var roverCommand in inputCommands.RoverTrails)
            {
                var rover = new Rover(roverCommand.InitialPosition);
                foreach (RoverCommand command in roverCommand.ActionCommands)
                {
                    _roverCommander.MoveRover(rover, command);
                    if (!IsCoordsInRange(rover.CurrentPosition.Coordinates, inputCommands.PlateauUpperRight))
                        throw new ApplicationException(OutOfRangeErrorMsg);
                    if (!IsCoordsClearOfTrail(rover))
                        throw new ApplicationException(TrailHitErrorMsg);
                }
                var finalPosition = rover.CurrentPosition.ToString();
                if (output.Length != 0)
                    output.Append("\n");
                output.Append(finalPosition);
                
                PersistRover(rover);
            }
            return output.ToString();
        }


        private bool IsCoordsClearOfTrail(Rover rover)
        {
            var sameLocations = rover.Track.Where(t => t.Overlaps(rover.CurrentPosition) && t.Step != rover.CurrentPosition.Step).ToList();
            if (sameLocations.Count != 0)
            {
                var lastHit = sameLocations.Max(p => p.Step);
                if (rover.CurrentPosition.Step - lastHit > 2)
                    return false;
            }
            return true;
        }

        private bool IsRoverCountInRange(InputEntity inputCommands)
        {
            return inputCommands.RoverTrails.Count <= MAX_ROVER_COUNT;
        }

        private bool IsCoordsInRange(Coordinates coords, Coordinates upperRight)
        {
            if (coords.X < 0 || coords.X > upperRight.X || coords.Y < 0 || coords.Y > upperRight.Y)
                return false;
            return true;
        }

        private void PersistRover(Rover rover)
        {
            _dbAccessor.PersistRover(rover);            
        }

        public string QueryForTheLastTravelledTrack()
        {
            return _dbAccessor.QueryForTheLastTravelledTrack();
        }

        public string QueryForTheLongestDistanceRover()
        {
            return _dbAccessor.QueryForTheLongestDistanceRover();
        }        
    }
}