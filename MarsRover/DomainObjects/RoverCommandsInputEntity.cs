using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.DomainObjects
{
    public class RoverCommandsInputEntity
    {
        public Position initialPosition;
        public List<RoverCommand> actionCommands;

        public RoverCommandsInputEntity()
        {
            initialPosition = new Position(new Coordinates(0, 0), Direction.N);
            actionCommands = new List<RoverCommand>();
        }
    }
}