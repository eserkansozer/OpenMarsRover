using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRoverDAL.DAObjects
{
    public class InputEntity : IEquatable<InputEntity>
    {
        private Coordinates _plateauUpperRight;
        public List<RoverCommandsInputEntity> _roverTrails;

        public Coordinates PlateauUpperRight
        {
            get { return _plateauUpperRight; }
            set { _plateauUpperRight = value; }
        }

        public InputEntity()
        {
            _plateauUpperRight = new Coordinates(0, 0);
            _roverTrails = new List<RoverCommandsInputEntity>();
        }

        public InputEntity(Coordinates plateauUpperRight, List<RoverCommandsInputEntity> roverTrails)
        {
            _plateauUpperRight = plateauUpperRight;
            _roverTrails = roverTrails;
        }

        public bool Equals(InputEntity other)
        {
            //for (int i = 0; i <= this._roverTrails.Count; i++)
            //{
            //    if (!this._roverTrails[i].Equals(other._roverTrails[i]))
            //        return false;
            //}

            //if (!this._plateauUpperRight.Equals(other._plateauUpperRight))
            //    return false;

            //return true;

            return this._roverTrails.SequenceEqual(other._roverTrails) && this._plateauUpperRight.Equals(other._plateauUpperRight);
        }
    }
}