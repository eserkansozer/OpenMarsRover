using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarsRoverDAL.DAObjects
{
    public class Rover
    {
        private Position _currentPosition;

        public Rover()
        {

        }

        [NotMapped]
        public Position CurrentPosition
        {
            get { return _currentPosition; }
        }
                
        public int RoverID
        { get; set; }

        public Rover(Position initialPosition)
        {            
            _currentPosition = initialPosition;
            _currentPosition.Step = 0;
            Track = new List<Position>();
            Track.Add((Position)_currentPosition.Clone());
        }

        public virtual List<Position> Track
        {
            get;
            set;
        }
    }
}