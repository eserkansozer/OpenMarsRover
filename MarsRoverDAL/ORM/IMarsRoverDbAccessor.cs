using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverDAL.DAObjects;

namespace MarsRoverDAL.ORM
{
    public interface IMarsRoverDbAccessor
    {
        string QueryForTheLastTravelledTrack();
        string QueryForTheLongestDistanceRover();
        void PersistRover(Rover rover);
    }
}