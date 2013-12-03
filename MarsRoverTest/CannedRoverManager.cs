using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverBusinessLogic.Services;

namespace MarsRoverTest
{
    public class CannedRoverManager : IRoverManager
    {
        Dictionary<string, string> _result = new Dictionary<string, string>();

        public CannedRoverManager(string output)
        {
            _result.Add(RoverManager.OUTPUT_TRAIL_KEY, output);
        }

        public string QueryForTheLastTravelledTrack()
        {
            return String.Empty;
        }

        public string QueryForTheLongestDistanceRover()
        {
            return String.Empty;
        }

        public Dictionary<string, string> GenerateGameResultInfo(string inputCommands)
        {
            return _result;
        }
    }
}
