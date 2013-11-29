using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverDAL.DAObjects;

namespace MarsRoverBusinessLogic.Services
{
    public interface IInputParser
    {
        InputEntity ParseInput(string inputData);
    }
}
