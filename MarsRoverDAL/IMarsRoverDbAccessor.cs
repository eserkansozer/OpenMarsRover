using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverDAL.DAObjects;

namespace MarsRoverDAL
{
    public interface IMarsRoverDbAccessor
    {
        string QueryForTheLastTravelledTrack();
        string QueryForTheLongestDistanceRover();
        void PersistGame(Game game);
    }
}