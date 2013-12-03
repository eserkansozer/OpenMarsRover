using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MarsRoverDAL.DAObjects;
using MarsRoverDAL.ORM;

namespace MarsRoverBusinessLogic.Services
{
    /// <summary>
    /// Facade for parsing input, creating rovers, moving them and generating output from their final positions
    /// </summary>
    public class RoverManager : IRoverManager
    {
        public const string OutOfRangeErrorMsg = "Error... Rover went out of terrain!";
        public const string ParsingErrorMsg = "Parsing Error... Please check your input!";
        public const string RoverLimitExceededErrorMsg = "No more than 5 rovers please!";
        public const int MAX_ROVER_COUNT = 5;

        IInputParser _inputParser;
        IRoverCommander _roverCommander;
        IMarsRoverDbAccessor _dbAccessor;
        
        public RoverManager(IInputParser inputParser, IRoverCommander roverCommander, IMarsRoverDbAccessor dbAccessor)
        {
            _inputParser = inputParser;
            _roverCommander = roverCommander;
            _dbAccessor = dbAccessor;
        }

        public string GenerateOutputTrailInfo(string inputData)
        {
            InputEntity inputCommands;
            try
            {
                inputCommands = _inputParser.ParseInput(inputData);
            }
            catch (ApplicationException ex)
            {
                return ex.Message;
            }
            catch (Exception)
            {
                return ParsingErrorMsg;
            }

            if (!IsRoverCountInRange(inputCommands))
            {
                return RoverLimitExceededErrorMsg;
            }

            var output = new StringBuilder();
            foreach(var roverCommand in inputCommands._roverTrails)
            {
                var rover = new Rover(roverCommand.initialPosition);                
                foreach (RoverCommand command in roverCommand.actionCommands)
                {
                    _roverCommander.MoveRover(rover, command);
                    if (!IsCoordsInRange(rover.CurrentPosition.Coordinates, inputCommands.PlateauUpperRight))
                        return OutOfRangeErrorMsg;
                }
                var finalPosition = rover.CurrentPosition.ToString();
                if (output.Length != 0)
                    output.Append("\n");
                output.Append(finalPosition);
                PersistRover(rover);
            }
            return output.ToString();
        }

        private static bool IsRoverCountInRange(InputEntity inputCommands)
        {
            return inputCommands._roverTrails.Count <= MAX_ROVER_COUNT;
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