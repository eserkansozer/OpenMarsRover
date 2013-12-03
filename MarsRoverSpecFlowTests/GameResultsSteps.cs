using System;
using System.Collections.Generic;
using MarsRoverBusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace MarsRoverSpecFlowTests
{
    [Binding]
    public class GameResultsSteps
    {
        RoverManager _roverManager;

        public GameResultsSteps()
        {
            _roverManager = new RoverManager(new InputParser(), new RoverCommander(), new MarsRoverTest.CannedMarsRoverDbAccessor());
        }

        [Given]
        public void GivenIHaveEntered_P0_RoversAsInput(int count)
        {
            var steps = new MovingRoverSteps();
            steps.GivenIHaveEnteredTheRoverMATRIXAs_P0("5 5");
            for (var i = 0; i < count; i++)
            {
                steps.GivenIHaveEnteredTheInitialPositionAs("1 1 N");
                steps.GivenIHaveEnteredTheCommandAs("M\n");
            }
        }

        [Given]
        public void GivenIHaveEnteredTheFollowingMultipleRoverInputs(Table table)
        {
            var inputList = new List<string>();
            foreach (TableRow row in table.Rows)
            {
                var input = String.Format("{0}\n{1}\n{2}\n{3}\n{4}\n", row[0], row[1], row[2], row[3], row[4]);
                inputList.Add(input);
            }

            ScenarioContext.Current["input"] = inputList;   
        }

        [Then]
        public void ThenTheCumulativeStepCountResultForOneRoverShouldBeAsFollowingOnTheOutputBox(Table table)
        {
            var resultList = (List<Dictionary<string, string>>)ScenarioContext.Current["resultList"];
            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(table.Rows[i][0], resultList[i][RoverManager.STEP_COUNT_KEY]);
            }      
        }

        [Then]
        public void ThenTheResultShouldDisplayThatIEntered_P0_Rovers(string count)
        {
            var resultList = ScenarioContext.Current["output"] as Dictionary<string,string>;
            Assert.AreEqual(count, resultList[RoverManager.ROVER_COUNT_KEY]);
        }


    }
}
