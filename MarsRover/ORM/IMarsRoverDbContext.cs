using System;
using System.Data.Entity;
using MarsRover.DomainObjects;
namespace MarsRover.ORM
{
    public interface IMarsRoverDbContext
    {
        IDbSet<Position> Positions { get; set; }
        IDbSet<Rover> Rovers { get; set; }
        int SaveChanges();
    }
}
