using System;
using System.Collections.Generic;
using MarsRoverBusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace MarsRoverSpecFlowTests
{
    [Binding]
    public class ErrorMessagesSteps
    {

        [Given]
        public void GivenIHaveEnteredMatrixAs_P0(string matrix)
        {
            var steps = new MovingRoverSteps();
            steps.GivenIHaveEnteredTheRoverMATRIXAs_P0(matrix);
            steps.GivenIHaveEnteredTheInitialPositionAs("1 1 N");
            steps.GivenIHaveEnteredTheCommandAs("M");
        }
        
        [Then]
        public void ThenIDoNotGetAnErrorMessage()
        {
            var result = ScenarioContext.Current["output"].ToString();
            Assert.AreNotEqual(InputParser.MatrixErrorMessage, result);
        }

        [Then]
        public void ThenITheResultShouldBeMatrixLimitExceededError()
        {
            var result = ScenarioContext.Current["output"].ToString();
            Assert.AreEqual(InputParser.MatrixErrorMessage, result);
        }

        [Then]
        public void ThenTheResultShouldBeTheInputParserError()
        {
            var resultList = (IList<string>)ScenarioContext.Current["resultList"];

            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(RoverManager.ParsingErrorMsg, resultList[i]);
            }  
        }

        [Then]
        public void ThenTheResultShouldBeOutOfTerrainError()
        {
            var resultList = (IList<string>)ScenarioContext.Current["resultList"];

            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(RoverManager.OutOfRangeErrorMsg, resultList[i]);
            }  
        }
    }
}
