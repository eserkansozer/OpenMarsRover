using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRover.DomainObjects;

namespace MarsRover.ORM
{
    public interface IMarsRoverDbAccessor
    {
        string QueryForTheLastTravelledTrack();
        string QueryForTheLongestDistanceRover();
        void PersistRover(Rover rover);
    }
}