using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDAL.DAObjects
{
    public class Game
    {
        public int GameID
        { get; set; }

        public virtual List<Rover> Rovers
        { get; set; }

        public string UserName
        { get; set; }

        public int Score
        { get; set; }

    }
}
