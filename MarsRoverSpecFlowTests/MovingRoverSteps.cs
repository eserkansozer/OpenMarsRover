using System;
using TechTalk.SpecFlow;
using MarsRover.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void GivenIHaveEnteredTheInitialPositionAs(string initialPosition)
        {
            ScenarioContext.Current["input"] += initialPosition + "\n";
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
            var output = roverManager.GenerateOutputTrailInfo(input);
            ScenarioContext.Current["output"] = output;
        }
        
        [Then(@"the result should be '(.*)' on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string expectedResult)
        {
            var result = ScenarioContext.Current["output"].ToString();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
