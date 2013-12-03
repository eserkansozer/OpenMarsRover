using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverDAL.DAObjects;

namespace MarsRoverBusinessLogic.Services
{
    public class InputParser : IInputParser
    {
        public const string MatrixErrorMessage = "Matrix Limit Exceeded! Max 100 X 100";

        public InputParser()
        {}

        public InputEntity ParseInput(string inputData)
        {
            var inputEntity = new InputEntity();
            var lines = inputData.Trim().Split(new String[] { "\r\n" }, StringSplitOptions.None);
            if(lines.Length == 1)
                lines = inputData.Trim().Split(new String[] { "\n" }, StringSplitOptions.None);
            inputEntity.PlateauUpperRight = ParseUpperRightPoint(lines[0]);
            int lineOrder = 1;
            while (lineOrder < lines.Length)
            {
                var roverInitialCoords = ParseInitialCoordinates(lines[lineOrder]);
                var roverInitialOrientation = ParseInitialOrientation(lines[lineOrder]);
                var roverCommands = new RoverCommandsInputEntity();
                roverCommands.InitialPosition = new Position(roverInitialCoords, roverInitialOrientation.ToString());
                lineOrder++;
                roverCommands.ActionCommands = ParseCommands(lines[lineOrder]);
                inputEntity.RoverTrails.Add(roverCommands);
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
            var points = line.Split(new char[] { ' ' });
            var x = Int32.Parse(points[0]);
            var y = Int32.Parse(points[1]);
            if(x>100 || y>100)
                throw new ApplicationException(MatrixErrorMessage);
            return new Coordinates(x, y);
        }

        #endregion
    }
}