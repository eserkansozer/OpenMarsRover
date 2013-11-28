using System.ComponentModel.DataAnnotations.Schema;
namespace MarsRover.DomainObjects
{
    public enum RoverCommand
    {
        L,
        R,
        M
    }

    public class Direction
    {
        public const string W = "W";
        public const string E = "E";
        public const string N = "N";
        public const string S = "S";
    }
}