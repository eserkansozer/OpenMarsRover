using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverDAL.DAObjects;

namespace MarsRoverBusinessLogic.Services
{
    public class InputParser : IInputParser
    {
        public InputParser()
        {}

        public InputEntity ParseInput(string inputData)
        {
            var inputEntity = new InputEntity();
            var lines = inputData.Split(new String[] { "\r\n" }, StringSplitOptions.None);
            if(lines.Length == 1)
                lines = inputData.Split(new String[] { "\n" }, StringSplitOptions.None);
            inputEntity.PlateauUpperRight = ParseUpperRightPoint(lines[0]);
            int lineOrder = 1;
            while (lineOrder < lines.Length)
            {
                var roverInitialCoords = ParseInitialCoordinates(lines[lineOrder]);
                var roverInitialOrientation = ParseInitialOrientation(lines[lineOrder]);
                var roverCommands = new RoverCommandsInputEntity();
                roverCommands.initialPosition = new Position(roverInitialCoords, roverInitialOrientation.ToString());
                lineOrder++;
                roverCommands.actionCommands = ParseCommands(lines[lineOrder]);
                inputEntity._roverTrails.Add(roverCommands);
                lineOrder++;
            }

            return inputEntity;
        }

        #region private methods

        private List<RoverCommand> ParseCommands(string line)
        {
            List<RoverCommand> commands = new List<RoverCommand>();
            for (int i = 0; i < line.Length; i++)
            {
                commands.Add((RoverCommand)Enum.Parse(typeof(RoverCommand), line.Substring(i, 1)));
            }
            return commands;
        }

        private string ParseInitialOrientation(string line)
        {
            return line.Substring(4, 1);
        }

        private Coordinates ParseInitialCoordinates(string line)
        {
            return new Coordinates(Int32.Parse(line.Substring(0, 1)), Int32.Parse(line.Substring(2, 1)));
        }

        private Coordinates ParseUpperRightPoint(string line)
        {
            return new Coordinates(Int32.Parse(line.Substring(0, 1)), Int32.Parse(line.Substring(2, 1)));
        }

        #endregion
    }
}