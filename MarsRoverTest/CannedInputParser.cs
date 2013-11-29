using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRoverBusinessLogic.Services;
using MarsRoverDAL.DAObjects;
using MarsRoverDAL.ORM;
using System.Data.Entity;

namespace MarsRoverTest
{
    public class CannedInputParser : IInputParser
    {
        InputEntity _inputEntity;
        bool _shouldThrowException;

        public CannedInputParser(InputEntity inputEntity) : this(inputEntity, false)
        {}

        public CannedInputParser(InputEntity inputEntity, bool shouldThrowException)
        {
            _inputEntity = inputEntity;
            _shouldThrowException = shouldThrowException;
        }

        #region IInputParser Members

        public InputEntity ParseInput(string inputData)
        {
            if (_shouldThrowException)
                throw new ApplicationException();
            return _inputEntity; ;
        }

        #endregion
    }
}
