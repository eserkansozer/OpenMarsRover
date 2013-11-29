using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverDAL.ORM;
using MarsRoverDAL.DAObjects;
using System.Data.Entity;

namespace MarsRoverTest
{
    public class CannedMarsRoverDbAccessor : /*DbContext, */ IMarsRoverDbAccessor
    {
        string _lastTravelledTrack, _longestDistanceRover;

        public CannedMarsRoverDbAccessor()
        {

        }

        public CannedMarsRoverDbAccessor(string lastTravelledTrack, string longestDistanceRover)
        {
            _lastTravelledTrack = lastTravelledTrack;
            _longestDistanceRover = longestDistanceRover;
        }

        public string QueryForTheLastTravelledTrack()
        {
            return _lastTravelledTrack;
        }

        public string QueryForTheLongestDistanceRover()
        {
            return _longestDistanceRover;
        }


        public void PersistRover(Rover rover)
        {
           // do nothing
        }
    }
}
