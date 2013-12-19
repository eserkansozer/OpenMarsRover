using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverDAL;
using MarsRoverDAL.DAObjects;
using System.Data.Entity;

namespace MarsRoverTest
{
    public class CannedMarsRoverDbAccessor : IMarsRoverDbAccessor
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
        
        public void PersistGame(Game game)
        {
            // do nothing
        }
    }
}
