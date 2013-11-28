using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.ORM;
using System.Data.Entity;
using MarsRover.DomainObjects;

namespace MarsRoverTest
{
    public class CannedMarsRoverDbContext : IMarsRoverDbContext
    {
        public CannedMarsRoverDbContext(IDbSet<Rover> rovers, IDbSet<Position> positions)
        {
            Rovers = rovers;
            Positions = positions;
        }

        public IDbSet<Position> Positions
        {
            get;
            set;
        }

        public IDbSet<Rover> Rovers
        {
            get;
            set;
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
