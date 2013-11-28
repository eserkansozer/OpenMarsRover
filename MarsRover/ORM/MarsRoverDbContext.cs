using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MarsRover.DomainObjects;

namespace MarsRover.ORM
{
    public class MarsRoverDbContext : DbContext, IMarsRoverDbContext
    {
        public IDbSet<Rover> Rovers { get; set; }
        public IDbSet<Position> Positions { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}