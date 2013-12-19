using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverDAL.DAObjects;
using MarsRoverBusinessLogic.Services;
using MarsRoverBusinessLogic.DomainObjects;

namespace MarsRoverTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class RoverCommanderTest
    {
        public RoverCommanderTest()
        {}

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void MoverRoverShouldForwardTheRoverOneStepInTheCurrentDirection()
        {
            //in north direction
            var rover = new Rover(new Position(new Coordinates(1,1), Direction.N));
            var expectedPosition = new Position(new Coordinates(1, 2), Direction.N);
            var roverCommander = new RoverCommander();

            roverCommander.MoveRover(rover, RoverCommand.M);
            
            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //in south direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.S));
            expectedPosition = new Position(new Coordinates(1, 0), Direction.S);

            roverCommander.MoveRover(rover, RoverCommand.M);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //in east direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.E));
            expectedPosition = new Position(new Coordinates(2, 1), Direction.E);

            roverCommander.MoveRover(rover, RoverCommand.M);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //in west direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.W));
            expectedPosition = new Position(new Coordinates(0, 1), Direction.W);

            roverCommander.MoveRover(rover, RoverCommand.M);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));
        }

        [TestMethod]
        public void MoveRoverShouldTurnTheRoverLeft()
        {
            //while in north direction
            var rover = new Rover(new Position(new Coordinates(1, 1), Direction.N));
            var expectedPosition = new Position(new Coordinates(1,1), Direction.W);
            var roverCommander = new RoverCommander();

            roverCommander.MoveRover(rover, RoverCommand.L);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //while in south direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.S));
            expectedPosition = new Position(new Coordinates(1, 1), Direction.E);

            roverCommander.MoveRover(rover, RoverCommand.L);

            //while in east direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.E));
            expectedPosition = new Position(new Coordinates(1, 1), Direction.N);

            roverCommander.MoveRover(rover, RoverCommand.L);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //while in west direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.W));
            expectedPosition = new Position(new Coordinates(1, 1), Direction.S);

            roverCommander.MoveRover(rover, RoverCommand.L);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));
        }

        [TestMethod]
        public void MoveRoverShouldTurnTheRoverRight()
        {
            //while in north direction
            var rover = new Rover(new Position(new Coordinates(1, 1), Direction.N));
            var expectedPosition = new Position(new Coordinates(1, 1), Direction.E);
            var roverCommander = new RoverCommander();

            roverCommander.MoveRover(rover, RoverCommand.R);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //while in south direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.S));
            expectedPosition = new Position(new Coordinates(1, 1), Direction.W);

            roverCommander.MoveRover(rover, RoverCommand.R);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //while in east direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.E));
            expectedPosition = new Position(new Coordinates(1, 1), Direction.S);

            roverCommander.MoveRover(rover, RoverCommand.R);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));

            //while in west direction
            rover = new Rover(new Position(new Coordinates(1, 1), Direction.W));
            expectedPosition = new Position(new Coordinates(1, 1), Direction.N);

            roverCommander.MoveRover(rover, RoverCommand.R);

            Assert.IsTrue(rover.CurrentPosition.Equals(expectedPosition));
        }
    }
}
