using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverBusinessLogic.Services
{
    public interface IRoverManager
    {

        string QueryForTheLastTravelledTrack();

        string QueryForTheLongestDistanceRover();

        Dictionary<string, string> GenerateGameResultInfo(string inputCommands);
    }
}
