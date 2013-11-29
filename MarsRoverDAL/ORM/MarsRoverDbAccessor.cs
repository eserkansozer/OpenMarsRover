using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MarsRoverDAL.DAObjects;

namespace MarsRoverDAL.ORM
{
    public class MarsRoverDbAccessor : IMarsRoverDbAccessor
    {
        private IMarsRoverDbContext _context;

        public MarsRoverDbAccessor(IMarsRoverDbContext context)
        {
            _context = context;
        }

        public string QueryForTheLastTravelledTrack()
        {
            var max = Convert.ToInt32(_context.Positions.Max(p => p.RoverID));
            //var l = _context.Positions
            //    .Where(x => x.RoverID == max);
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
            //var maxStep = _context.Positions
            //    .Max(p => p.Step);
            //var longestRovers = from p in _context.Positions
            //                    where p.Step == maxStep
            //                    select p.RoverID;
            //var longest = new StringBuilder();
            //foreach (var rover in longerList)
            //{
            //    longest.Append(rover.ToString() + " ");
            //}
            //return longest.ToString().TrimEnd();
            var longerList = (from p in _context.Positions
                              group p by p.RoverID into gr
                              select new { stepsCount = gr.Count(), id = gr.Key })
                              .OrderByDescending(x => x.stepsCount)
                              .Select(x => x.id).First();
            return longerList.ToString();
        }

        public void PersistRover(Rover rover)
        {
            _context.Rovers.Add(rover);
            _context.SaveChanges();
        }
    }
}