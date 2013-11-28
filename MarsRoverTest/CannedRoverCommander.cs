using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.DomainObjects;
using MarsRover.Services;

namespace MarsRoverTest
{
    public class CannedRoverCommander : IRoverCommander
    {
        #region IRoverCommander Members

        public void MoveRover(Rover rover, RoverCommand command)
        {
            //do notthing
        }

        #endregion
    }
}
