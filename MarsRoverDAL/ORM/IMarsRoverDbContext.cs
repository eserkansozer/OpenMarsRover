using System;
using System.Data.Entity;
using MarsRoverDAL.DAObjects;
namespace MarsRoverDAL.ORM
{
    public interface IMarsRoverDbContext
    {
        IDbSet<Position> Positions { get; set; }
        IDbSet<Rover> Rovers { get; set; }
        IDbSet<Game> Games { get; set; }
        int SaveChanges();
    }
}
