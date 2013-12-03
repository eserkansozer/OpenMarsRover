﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18052
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MarsRoverSpecFlowTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GameResultsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GameResults.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GameResults", "In order to know how I did during my game attempt\r\nAs a user\r\nI want to be inform" +
                    "ed about the details of my game", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "GameResults")))
            {
                MarsRoverSpecFlowTests.GameResultsFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Number of rovers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GameResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void NumberOfRovers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Number of rovers", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have entered 3 rovers as input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I press the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("the result should display that I entered 3 rovers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cumulative step count for one rover")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GameResults")]
        public virtual void CumulativeStepCountForOneRover()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cumulative step count for one rover", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matrix",
                        "InitialPosition",
                        "Command"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 N",
                        "MM"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 E",
                        "MMRR"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 S",
                        "MRRMMM"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 W",
                        "RLRM"});
#line 13
 testRunner.Given("I have entered the following inputs", ((string)(null)), table1, "Given ");
#line 19
 testRunner.When("I press the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "stepCount"});
            table2.AddRow(new string[] {
                        "2"});
            table2.AddRow(new string[] {
                        "2"});
            table2.AddRow(new string[] {
                        "4"});
            table2.AddRow(new string[] {
                        "1"});
#line 20
 testRunner.Then("the cumulative step count result for one rover should be as following on the outp" +
                    "ut box", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cumulative step count for 2 rovers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GameResults")]
        public virtual void CumulativeStepCountFor2Rovers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cumulative step count for 2 rovers", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matrix",
                        "InitialPosition1",
                        "Command1",
                        "InitialPosition2",
                        "Command2"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 1 N",
                        "MM",
                        "0 0 N",
                        "M"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 1 E",
                        "MMRR",
                        "3 3 E",
                        "RRM"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 1 S",
                        "MRRMMM",
                        "2 2 W",
                        "MM"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 1 W",
                        "RLRM",
                        "5 5 S",
                        "MRM"});
#line 28
 testRunner.Given("I have entered the following inputs", ((string)(null)), table3, "Given ");
#line 34
 testRunner.When("I press the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "stepCount"});
            table4.AddRow(new string[] {
                        "3"});
            table4.AddRow(new string[] {
                        "3"});
            table4.AddRow(new string[] {
                        "6"});
            table4.AddRow(new string[] {
                        "3"});
#line 35
 testRunner.Then("the cumulative step count result for one rover should be as following on the outp" +
                    "ut box", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
