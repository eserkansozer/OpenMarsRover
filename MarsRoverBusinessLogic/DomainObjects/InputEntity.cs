using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverDAL.DAObjects;

namespace MarsRoverBusinessLogic.DomainObjects
{
    public class InputEntity : IEquatable<InputEntity>
    {
        private Coordinates _plateauUpperRight;
        private List<RoverCommandsInputEntity> _roverTrails;

        public List<RoverCommandsInputEntity> RoverTrails
        {
            get { return _roverTrails; }
            set { _roverTrails = value; }
        }

        public Coordinates PlateauUpperRight
        {
            get { return _plateauUpperRight; }
            set { _plateauUpperRight = value; }
        }

        public InputEntity()
        {
            _plateauUpperRight = new Coordinates(0, 0);
            RoverTrails = new List<RoverCommandsInputEntity>();
        }

        public InputEntity(Coordinates plateauUpperRight, List<RoverCommandsInputEntity> roverTrails)
        {
            _plateauUpperRight = plateauUpperRight;
            RoverTrails = roverTrails;
        }

        public bool Equals(InputEntity other)
        {
            return this.RoverTrails.SequenceEqual(other.RoverTrails) && this._plateauUpperRight.Equals(other._plateauUpperRight);
        }
    }
}