using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverBusinessLogic.Services;

namespace MarsRoverTest
{
    public class CannedRoverManager : IRoverManager
    {
        string _result;

        public CannedRoverManager(string output)
        {
            _result = output;
        }

        #region IRoverManager Members

        public string GenerateOutputTrailInfo(string inputCommands)
        {
            return _result;
        }

        #endregion


        public string QueryForTheLastTravelledTrack()
        {
            return String.Empty;
        }

        public string QueryForTheLongestDistanceRover()
        {
            return String.Empty;
        }
    }
}
