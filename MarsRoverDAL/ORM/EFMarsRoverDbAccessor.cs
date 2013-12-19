using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MarsRoverDAL.DAObjects;

namespace MarsRoverDAL.ORM
{
    public class EFMarsRoverDbAccessor : IMarsRoverDbAccessor
    {
        private IMarsRoverDbContext _context;

        public EFMarsRoverDbAccessor(IMarsRoverDbContext context)
        {
            _context = context;
        }

        public string QueryForTheLastTravelledTrack()
        {
            var max = Convert.ToInt32(_context.Positions.Max(p => p.RoverID));
            var l = from p in _context.Positions
                    where p.RoverID == max
                    select p;
            var builder = new StringBuilder();
            foreach (Position p in l)
            {
                if (builder.Length != 0)
                    builder.Append(" -> ");
                builder.Append(p.ToString());

            }
            return builder.ToString();
        }

        public string QueryForTheLongestDistanceRover()
        {               
            var longerList = (from p in _context.Positions
                              group p by p.RoverID into gr
                              select new { stepsCount = gr.Count(), id = gr.Key })
                              .OrderByDescending(x => x.stepsCount)
                              .Select(x => x.id).First();
            return longerList.ToString();
        }

        public void PersistGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }
    }
}