using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarsRover.DomainObjects
{
    public class Position : IEquatable<Position>, ICloneable
    {
        private int _step;
               
        public int PositionID { get; set; }

        public Position()
        {       }

        [ForeignKey("Rover")]
        public int RoverID { get; set; }
        public virtual Rover Rover { get; set; }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public virtual Coordinates Coordinates
        { 
            get; set; 
        }

        public string Orientation
        { 
            get; set; 
        }

        public Position(Position position)
        {
            Coordinates = (Coordinates)position.Coordinates.Clone();
            Orientation = position.Orientation;
            Step = position.Step;
        }
        public Position(Coordinates coordinates, string orientation)
        {
            Coordinates = coordinates;
            Orientation = orientation;
        }

        #region IEquatable<Position> Members

        public bool Equals(Position other)
        {
            return this.Coordinates.Equals(other.Coordinates) && this.Orientation.Equals(other.Orientation);
        }

        #endregion

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.Coordinates.X, this.Coordinates.Y, this.Orientation);
        }

        public object Clone()
        {
            var p = (Position)this.MemberwiseClone();
            p.Coordinates = (Coordinates)this.Coordinates.Clone();            
            return p;
        }
    }
}