using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRoverDAL.DAObjects
{
    public class RoverCommandsInputEntity : IEquatable<RoverCommandsInputEntity>
    {
        private Position _initialPosition;
        public Position InitialPosition
        {
            get { return _initialPosition; }
            set { _initialPosition = value; }
        }

        private List<RoverCommand> _actionCommands;
        public List<RoverCommand> ActionCommands
        {
            get { return _actionCommands; }
            set { _actionCommands = value; }
        }

        public RoverCommandsInputEntity()
        {
            _initialPosition = new Position(new Coordinates(0, 0), Direction.N);
            _actionCommands = new List<RoverCommand>();
        }

        public bool Equals(RoverCommandsInputEntity other)
        {
            return this.ActionCommands.SequenceEqual(other.ActionCommands) && this.InitialPosition.Equals(other.InitialPosition);
        }
    }
}