using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverDAL.DAObjects;

namespace MarsRoverBusinessLogic.Services
{
    public class RoverCommander : IRoverCommander
    {
        public RoverCommander()
        {}
        
        public void MoveRover(Rover rover, RoverCommand command)
        {
            switch (command)
            {
                case RoverCommand.L:
                    TurnLeft(rover);
                    break;
                case RoverCommand.R:
                    TurnRight(rover);
                    break;
                case RoverCommand.M:
                    Move(rover);
                    break;
            }
            rover.CurrentPosition.Step++;
            rover.Track.Add((Position)rover.CurrentPosition.Clone());
        }

        private void TurnLeft(Rover rover)
        {
            switch (rover.CurrentPosition.Orientation)
            {
                case Direction.W:
                    rover.CurrentPosition.Orientation = Direction.S;
                    break;
                case Direction.E:
                    rover.CurrentPosition.Orientation = Direction.N;
                    break;
                case Direction.N:
                    rover.CurrentPosition.Orientation = Direction.W;
                    break;
                case Direction.S:
                    rover.CurrentPosition.Orientation = Direction.E;
                    break;
            }
        }

        private void TurnRight(Rover rover)
        {
            switch (rover.CurrentPosition.Orientation)
            {
                case Direction.W:
                    rover.CurrentPosition.Orientation = Direction.N;
                    break;
                case Direction.E:
                    rover.CurrentPosition.Orientation = Direction.S;
                    break;
                case Direction.N:
                    rover.CurrentPosition.Orientation = Direction.E;
                    break;
                case Direction.S:
                    rover.CurrentPosition.Orientation = Direction.W;
                    break;
            }
        }

        private void Move(Rover rover)
        {
            switch (rover.CurrentPosition.Orientation)
            {
                case Direction.W:
                    rover.CurrentPosition.Coordinates.X--;
                    break;
                case Direction.E:
                    rover.CurrentPosition.Coordinates.X++;
                    break;
                case Direction.N:
                    rover.CurrentPosition.Coordinates.Y++;
                    break;
                case Direction.S:
                    rover.CurrentPosition.Coordinates.Y--;
                    break;
            }
        }        
    }      
}
