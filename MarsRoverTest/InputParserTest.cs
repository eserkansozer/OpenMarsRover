using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverBusinessLogic.Services;
using MarsRoverDAL.DAObjects;
using MarsRoverBusinessLogic.DomainObjects;

namespace MarsRoverTest
{
    [TestClass]
    public class InputParserTest
    {
        [TestMethod]
        public void ParseInputShouldReturnCorrectInputEntity()
        {
            var expectedResult = new InputEntity(new Coordinates(5, 5), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { ActionCommands = new List<RoverCommand>() { RoverCommand.M }, InitialPosition = new Position(new Coordinates(1, 2), Direction.N) } });
            var inputParser = new InputParser();

            var result = inputParser.ParseInput("5 5\r\n1 2 N\r\nM");

            var expectedInputEntity = new InputEntity(new Coordinates(5,5), new List<RoverCommandsInputEntity>(){
                new RoverCommandsInputEntity(){
                    InitialPosition = new Position(new Coordinates(1,2), "N"),
                    ActionCommands = new List<RoverCommand>(){
                        RoverCommand.M }
                    }
                });
            Assert.IsTrue(expectedInputEntity.Equals(result));
        }

        [TestMethod]
        public void ParseInputShouldReturnCorrectInputEntityForMultiDigitMatrix()
        {
            var expectedResult = new InputEntity(new Coordinates(5, 5), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { ActionCommands = new List<RoverCommand>() { RoverCommand.M }, InitialPosition = new Position(new Coordinates(1, 2), Direction.N) } });
            var inputParser = new InputParser();

            var result = inputParser.ParseInput("100 100\r\n1 2 N\r\nM");
            Assert.IsTrue(new Coordinates(100, 100).Equals(result.PlateauUpperRight));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void ParseInputShouldRaiseExceptionForBiggerThan100Matrix()
        {
            var expectedResult = new InputEntity(new Coordinates(5, 5), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { ActionCommands = new List<RoverCommand>() { RoverCommand.M }, InitialPosition = new Position(new Coordinates(1, 2), Direction.N) } });
            var inputParser = new InputParser();

            var result = inputParser.ParseInput("101 102\r\n1 2 N\r\nM");            
        }
    }
}
