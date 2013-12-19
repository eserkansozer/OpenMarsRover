using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverBusinessLogic.DomainObjects;
using MarsRoverDAL.DAObjects;

namespace MarsRoverBusinessLogic.Services
{
    public interface IRoverCommander
    {
        void MoveRover(Rover rover, RoverCommand command);
    }
}
