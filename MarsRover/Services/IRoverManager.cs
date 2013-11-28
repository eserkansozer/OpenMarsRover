using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Services
{
    public interface IRoverManager
    {
        string GenerateOutputTrailInfo(string inputCommands);

        string QueryForTheLastTravelledTrack();

        string QueryForTheLongestDistanceRover();
    }
}
