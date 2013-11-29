using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarsRoverDAL.DAObjects
{
    [ComplexType]
    public class Coordinates : IEquatable<Coordinates>, ICloneable
    {
        public Coordinates()
        {}
    
        [Column("X")]
        public int X
        {
            get;
            set;
        }

        [Column("Y")]
        public int Y
        {
            get;
            set;
        }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region IEquatable<Coordinates> Members

        public bool Equals(Coordinates other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}