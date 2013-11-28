using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.DomainObjects;

namespace MarsRover.Services
{
    public interface IInputParser
    {
        InputEntity ParseInput(string inputData);
    }
}
