using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverBusinessLogic.Services;
using MarsRoverDAL.DAObjects;
using System.Data.Entity;

namespace MarsRoverTest
{
    [TestClass]
    public class RoverManagerTest
    {
        [TestMethod]
        public void GetOutputTrailInfoShouldReturnCorrectOutputForGivenInput()
        {
            var inputEntity = new InputEntity(new Coordinates(1, 1), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { InitialPosition = new Position(new Coordinates(0, 0), Direction.N), ActionCommands = new List<RoverCommand> { RoverCommand.M } } });
            var inputParser = new CannedInputParser(inputEntity);
            var roverCommander = new CannedRoverCommander();
            var accessor = new CannedMarsRoverDbAccessor();


            var roverManager = new RoverManager(inputParser, roverCommander, accessor);
            var expectedOutput = "0 0 N";

            var output = roverManager.GenerateGameResultInfo("");

            Assert.AreEqual(expectedOutput, output[RoverManager.OUTPUT_TRAIL_KEY]);
        }

        [TestMethod]
        public void GetOutputTrailInfoShouldReturnErrorIfRoverGetsOutOfTerrain()
        {
            var inputEntity = new InputEntity(new Coordinates(1, 1), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { InitialPosition = new Position(new Coordinates(2, 0), Direction.N), ActionCommands = new List<RoverCommand> { RoverCommand.M, RoverCommand.M } } });
            var inputParser = new CannedInputParser(inputEntity);
            var roverCommander = new CannedRoverCommander();
            var accessor = new CannedMarsRoverDbAccessor();

            var roverManager = new RoverManager(inputParser, roverCommander, accessor);
            var expectedOutput = RoverManager.OutOfRangeErrorMsg;

            var output = roverManager.GenerateGameResultInfo("");

            Assert.AreEqual(expectedOutput, output[RoverManager.OUTPUT_TRAIL_KEY]);

        }

        [TestMethod]
        public void GetOutputTrailInfoShouldReturnErrorIfInputIsNotValid()
        {
            var inputEntity = new InputEntity(new Coordinates(1, 1), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { InitialPosition = new Position(new Coordinates(0, 0), Direction.N), ActionCommands = new List<RoverCommand> { RoverCommand.M } } });
            var inputParser = new CannedInputParser(inputEntity, true);
            var roverCommander = new CannedRoverCommander();
            var accessor = new CannedMarsRoverDbAccessor();

            var roverManager = new RoverManager(inputParser, roverCommander, accessor);
            var expectedOutput = RoverManager.ParsingErrorMsg;

            var output = roverManager.GenerateGameResultInfo("xxx");

            Assert.AreEqual(expectedOutput, output[RoverManager.OUTPUT_TRAIL_KEY]);

        }

        [TestMethod]
        public void QueryForTheLastTravelledTrackShouldReturnCorrectOutputForGivenInput()
        {
            var inputEntity = new InputEntity(new Coordinates(1, 1), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { InitialPosition = new Position(new Coordinates(0, 0), Direction.N), ActionCommands = new List<RoverCommand> { RoverCommand.M } } });
            var inputParser = new CannedInputParser(inputEntity);
            var roverCommander = new CannedRoverCommander();
            var accessor = new CannedMarsRoverDbAccessor("1 1 N -> 1 2 N", "1");

            //var context = new CannedMarsRoverDbAccessor();
            //context.Rovers = context.Set<Rover>();
            //context.Rovers.Add(new Rover(new Position(new Coordinates(1, 1), "N")));
            //context.Positions = context.Set<Position>();
            //context.Positions.Add(new Position(new Coordinates(1, 2), "N"));
            //context.SaveChanges();
            

            var roverManager = new RoverManager(inputParser, roverCommander, accessor);
            var output = roverManager.QueryForTheLastTravelledTrack();
            var expectedOutput = "1 1 N -> 1 2 N";

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void QueryForTheLongestDistanceRoverShouldReturnCorrectOutputForGivenInput()
        {
            var inputEntity = new InputEntity(new Coordinates(1, 1), new List<RoverCommandsInputEntity>() { new RoverCommandsInputEntity() { InitialPosition = new Position(new Coordinates(0, 0), Direction.N), ActionCommands = new List<RoverCommand> { RoverCommand.M } } });
            var inputParser = new CannedInputParser(inputEntity);
            var roverCommander = new CannedRoverCommander();
            var accessor = new CannedMarsRoverDbAccessor("", "666");

            //var context = new CannedMarsRoverDbAccessor();
            //context.Rovers = context.Set<Rover>();
            //var longestRover = new Rover(new Position(new Coordinates(1, 1), "N"));
            //context.Rovers.Add(longestRover);
            //context.Positions = context.Set<Position>();
            //context.Positions.Add(new Position(new Coordinates(1, 2), "N") {Step = 1 });
            //context.SaveChanges();
            //context.Rovers.Add(new Rover(new Position(new Coordinates(2, 2), "S")));
            //context.SaveChanges();

            var roverManager = new RoverManager(inputParser, roverCommander, accessor);
                        
            var output = roverManager.QueryForTheLongestDistanceRover();
            var expectedOutput = "666";

            Assert.AreEqual(expectedOutput, output);
        }
    }
}
