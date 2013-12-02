using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections;
using System.Collections.Generic;
using MarsRoverBusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverSpecFlowTests
{
    [Binding]
    public class MovesTableSteps
    {
        RoverManager _roverManager;

        public MovesTableSteps()
        {
            _roverManager = new RoverManager(new InputParser(), new RoverCommander(), new MarsRoverTest.CannedMarsRoverDbAccessor());
        }

        [Given(@"I have entered the following inputs")]
        public void GivenIHaveEnteredTheFollowingInputs(Table table)
        {
            var inputList = new List<string>();
            foreach(TableRow row in table.Rows)
            {
                var input = String.Format("{0}\n{1}\n{2}", row[0], row[1], row[2]);
                inputList.Add(input);
            }

            ScenarioContext.Current["input"] = inputList;           
        }

        [When]
        public void WhenIPressTheSubmitButton()
        {
            var inputList = (List<String>)ScenarioContext.Current["input"];
            var resultList = new List<string>();
            foreach (var input in inputList)
            {
                var result = _roverManager.GenerateOutputTrailInfo(input);
                resultList.Add(result);
            }

            ScenarioContext.Current["resultList"] = resultList;   
        }


        [Then(@"the result should be as following on the output box")]
        public void ThenTheResultShouldBeAsFollowingOnTheOutputBox(Table table)
        {
            var resultList = (IList<string>) ScenarioContext.Current["resultList"];

            for(int i=0; i < resultList.Count; i++)
            {
                Assert.AreEqual(table.Rows[i][0], resultList[i]);    
            }            
        }

    }
}
