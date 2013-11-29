﻿using System.ComponentModel.DataAnnotations.Schema;
namespace MarsRoverDAL.DAObjects
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