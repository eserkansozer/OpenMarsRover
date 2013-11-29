using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverDAL.ORM;
using Rhino.Mocks;
using System.Data.Entity;
using MarsRoverDAL.DAObjects;
using System.Collections.ObjectModel;

namespace MarsRoverTest
{
    [TestClass]
    public class MarsRoverDbAccessorTest
    {
        [TestMethod]
        public void QueryForTheLastTravelledTrackShouldReturnCorrectPath()
        {
            var roverDbSet = new InMemoryDbSet<Rover>();
            var positionDbSet = new InMemoryDbSet<Position>();
            var pos1 = new Position(new Coordinates(1, 1), "N") { RoverID = 1, PositionID = 1, Step = 0, Rover = new Rover() };
            var pos2 = new Position(new Coordinates(1, 2), "N") { RoverID = 1, PositionID = 2, Step = 1 , Rover = new Rover()};
            positionDbSet.Add(pos1);
            positionDbSet.Add(pos2);

            var accessor = new MarsRoverDbAccessor(new CannedMarsRoverDbContext(roverDbSet, positionDbSet));

            var output = accessor.QueryForTheLastTravelledTrack();

            Assert.AreEqual("1 1 N -> 1 2 N", output);
        }

        [TestMethod]
        public void QueryForTheLongestDistanceRoverShouldReturnCorrectId()
        {
            var roverDbSet = new InMemoryDbSet<Rover>();
            var positionDbSet = new InMemoryDbSet<Position>();
            var pos1 = new Position(new Coordinates(1, 1), "N") { RoverID = 1, PositionID = 1, Step = 0, Rover = new Rover() };
            var pos2 = new Position(new Coordinates(1, 2), "N") { RoverID = 1, PositionID = 2, Step = 1, Rover = new Rover() };
            var pos3 = new Position(new Coordinates(1, 1), "N") { RoverID = 2, PositionID = 1, Step = 0, Rover = new Rover() };
            var pos4 = new Position(new Coordinates(1, 2), "N") { RoverID = 2, PositionID = 2, Step = 1, Rover = new Rover() };
            var pos5 = new Position(new Coordinates(1, 2), "N") { RoverID = 2, PositionID = 3, Step = 2, Rover = new Rover() };
            positionDbSet.Add(pos1);
            positionDbSet.Add(pos2);
            positionDbSet.Add(pos3);
            positionDbSet.Add(pos4); 
            positionDbSet.Add(pos5);

            var accessor = new MarsRoverDbAccessor(new CannedMarsRoverDbContext(roverDbSet, positionDbSet));

            var output = accessor.QueryForTheLongestDistanceRover();
            
            Assert.AreEqual("2", output);             
        }
    }
}
