using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverBusinessLogic.Services;
using MarsRoverDAL.DAObjects;

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
