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
    [TechTalk.SpecRun.FeatureAttribute("Moves Table", Description="In order to see the progress of the rover based on my commands\r\nAs a user\r\nI want" +
        " to see ve shown the final position of the rover", SourceFile="MovesTableFeature.feature", SourceLine=0)]
    public partial class MovesTableFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MovesTableFeature.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Moves Table", "In order to see the progress of the rover based on my commands\r\nAs a user\r\nI want" +
                    " to see ve shown the final position of the rover", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
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
        
        [TechTalk.SpecRun.ScenarioAttribute("When you command a rover with one move it moves one step in the correct direction" +
            "", new string[] {
                "mytag"}, SourceLine=6)]
        public virtual void WhenYouCommandARoverWithOneMoveItMovesOneStepInTheCorrectDirection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When you command a rover with one move it moves one step in the correct direction" +
                    "", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matrix",
                        "InitialPosition",
                        "Command"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 N",
                        "M"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 E",
                        "M"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 S",
                        "M"});
            table1.AddRow(new string[] {
                        "5 5",
                        "1 1 W",
                        "M"});
#line 8
 testRunner.Given("I have entered the following inputs", ((string)(null)), table1, "Given ");
#line 14
 testRunner.When("I press the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "output"});
            table2.AddRow(new string[] {
                        "1 2 N"});
            table2.AddRow(new string[] {
                        "2 1 E"});
            table2.AddRow(new string[] {
                        "1 0 S"});
            table2.AddRow(new string[] {
                        "0 1 W"});
#line 15
 testRunner.Then("the result should be as following on the output box", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When you command a rover with multiple moves it moves few steps in the correct di" +
            "rection", SourceLine=21)]
        public virtual void WhenYouCommandARoverWithMultipleMovesItMovesFewStepsInTheCorrectDirection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When you command a rover with multiple moves it moves few steps in the correct di" +
                    "rection", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Matrix",
                        "InitialPosition",
                        "Command"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 1 N",
                        "MM"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 1 E",
                        "MMM"});
            table3.AddRow(new string[] {
                        "5 5",
                        "1 4 S",
                        "MMM"});
            table3.AddRow(new string[] {
                        "5 5",
                        "4 0 W",
                        "MMMM"});
#line 23
 testRunner.Given("I have entered the following inputs", ((string)(null)), table3, "Given ");
#line 29
 testRunner.When("I press the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "output"});
            table4.AddRow(new string[] {
                        "1 3 N"});
            table4.AddRow(new string[] {
                        "4 1 E"});
            table4.AddRow(new string[] {
                        "1 1 S"});
            table4.AddRow(new string[] {
                        "0 0 W"});
#line 30
 testRunner.Then("the result should be as following on the output box", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
