using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverBusinessLogic.Services;
using MarsRoverDAL.DAObjects;

namespace MarsRoverTest
{
    [TestClass]
    public class InputParserTest
    {
        [TestMethod]
        public void ParseInputShouldReturnCorrectInputEntity()
        {
            var expectedResult = new InputEntity(new Coordinates(5, 5), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { actionCommands = new List<RoverCommand>() { RoverCommand.M }, initialPosition = new Position(new Coordinates(1, 2), Direction.N) } });
            var inputParser = new InputParser();

            var result = inputParser.ParseInput("5 5\r\n1 2 N\r\nM");
        }
    }
}
