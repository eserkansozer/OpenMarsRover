using System;
using TechTalk.SpecFlow;

namespace MarsRoverSpecFlowTests
{
    [Binding]
    public class GameResultsSteps
    {
        [Given]
        public void GivenIHaveEntered_P0_RoversAsInput(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void ThenTheResultShouldDisplayThatIEntered_P0_Rovers(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then]
        public void ThenTheCumulativeStepCountResultForOneRoverShouldBeAsFollowingOnTheOutputBox(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
