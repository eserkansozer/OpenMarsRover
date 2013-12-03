using System;
using TechTalk.SpecFlow;
using MarsRoverBusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarsRoverSpecFlowTests
{
    [Binding]
    public class MovingRoverSteps
    {
        [Given]
        public void GivenIHaveEnteredTheRoverMATRIXAs_P0(string p0)
        {
            ScenarioContext.Current["input"] = p0 + "\n";
        }
        
        [Given(@"I have entered the initial position as '(.*)'")]
        public void GivenIHaveEnteredTheInitialPositionAs(string InitialPosition)
        {
            ScenarioContext.Current["input"] += InitialPosition + "\n";
        }
        
        [Given(@"I have entered the command as '(.*)'")]
        public void GivenIHaveEnteredTheCommandAs(string command)
        {
            ScenarioContext.Current["input"] += command;
        }
        
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            var roverManager = new RoverManager(new InputParser(), new RoverCommander(), new MarsRoverTest.CannedMarsRoverDbAccessor());
            var input = ScenarioContext.Current["input"].ToString();
            var output = roverManager.GenerateGameResultInfo(input);
            ScenarioContext.Current["output"] = output;
        }
        
        [Then(@"the result should be '(.*)' on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string expectedResult)
        {
            var result = ((Dictionary<string,string>)ScenarioContext.Current["output"])[RoverManager.OUTPUT_TRAIL_KEY].ToString();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
