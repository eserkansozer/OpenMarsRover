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
        { }
           
        public int RoverID
        { get; set; }

        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        public Rover(Position InitialPosition)
        {            
            _currentPosition = InitialPosition;
            _currentPosition.Step = 0;
            Track = new List<Position>();
            Track.Add((Position)_currentPosition.Clone());
        }

        public int Mileage
        {
            get { return Track.Count(); }
            set { }
        }

        public virtual List<Position> Track
        {
            get;
            set;
        }

        [NotMapped]
        public Position CurrentPosition
        {
            get { return _currentPosition; }
        }
    }
}