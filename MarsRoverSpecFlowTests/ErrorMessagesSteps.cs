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

        [Given]
        public void GivenIHaveEnteredMoreThan_P0_Rovers(int maxRoverCount)
        {
            var roverCount = maxRoverCount + 1;
            var steps = new MovingRoverSteps();
            steps.GivenIHaveEnteredTheRoverMATRIXAs_P0("5 5");
            for (var i = 0; i < roverCount; i++)
            {
                steps.GivenIHaveEnteredTheInitialPositionAs("1 1 N");
                steps.GivenIHaveEnteredTheCommandAs("MM\n");
            }
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
            var result = ((Dictionary<string,string>)ScenarioContext.Current["output"])[RoverManager.OUTPUT_TRAIL_KEY].ToString();
            Assert.AreEqual(InputParser.MatrixErrorMessage, result);
        }

        [Then]
        public void ThenTheResultShouldBeTheInputParserError()
        {
            var resultList = (IList<Dictionary<string,string>>)ScenarioContext.Current["resultList"];

            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(RoverManager.ParsingErrorMsg, resultList[i][RoverManager.OUTPUT_TRAIL_KEY]);
            }  
        }

        [Then]
        public void ThenTheResultShouldBeOutOfTerrainError()
        {
            var resultList = (IList<Dictionary<string,string>>)ScenarioContext.Current["resultList"];

            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(RoverManager.OutOfRangeErrorMsg, resultList[i][RoverManager.OUTPUT_TRAIL_KEY]);
            }  
        }

        [Then]
        public void ThenTheResultShouldBeRoverLimitExceededError()
        {
            var result = ((Dictionary<string,string>)ScenarioContext.Current["output"])[RoverManager.OUTPUT_TRAIL_KEY].ToString();
            Assert.AreEqual(RoverManager.RoverLimitExceededErrorMsg, result);
        }

        [Then]
        public void ThenTheResultShouldBeTrailHitError()
        {
            var result = ((Dictionary<string, string>)ScenarioContext.Current["output"])[RoverManager.OUTPUT_TRAIL_KEY].ToString();
            Assert.AreEqual(RoverManager.TrailHitErrorMsg, result); 
        }
    }
}
