using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRover.DomainObjects;
using System.Text;
using MarsRover.ORM;

namespace MarsRover.Services
{
    /// <summary>
    /// Facade for parsing input, creating rovers, moving them and generating output from their final positions
    /// </summary>
    public class RoverManager : IRoverManager
    {
        public const string OutOfRangeErrorMsg = "Error... Rover went out of terrain!";
        public const string ParsingErrorMsg = "Parsing Error... Please check your input!";

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
            catch (Exception e)
            {
                return ParsingErrorMsg;
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