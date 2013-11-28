using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.DomainObjects
{
    public class InputEntity
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
    }
}