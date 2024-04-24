﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CoreProject.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("BoundaryValues")]
    [NUnit.Framework.CategoryAttribute("allure.label.epic:GUI")]
    [NUnit.Framework.CategoryAttribute("allure.label.suite:GUI")]
    [NUnit.Framework.CategoryAttribute("allure.label.subSuite:BoundaryValues")]
    public partial class BoundaryValuesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "allure.label.epic:GUI",
                "allure.label.suite:GUI",
                "allure.label.subSuite:BoundaryValues"};
        
#line 1 "BoundaryValues.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "BoundaryValues", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CreateProjectWithIncorrectCode")]
        [NUnit.Framework.CategoryAttribute("allure.label.story:BoundaryValues")]
        [NUnit.Framework.CategoryAttribute("allure.label.severity:critical")]
        [NUnit.Framework.CategoryAttribute("allure.label.owner:JohnDoe")]
        [NUnit.Framework.CategoryAttribute("link:https://dev.example.com/")]
        [NUnit.Framework.CategoryAttribute("issue:AUTH-123")]
        [NUnit.Framework.CategoryAttribute("tms:TMS-456")]
        [NUnit.Framework.CategoryAttribute("allure.label.package:org.example")]
        [NUnit.Framework.CategoryAttribute("allure.label.testClass:TestMyWebsite")]
        [NUnit.Framework.CategoryAttribute("allure.label.testMethod:TestLabels()")]
        [NUnit.Framework.CategoryAttribute("GUI")]
        public void CreateProjectWithIncorrectCode()
        {
            string[] tagsOfScenario = new string[] {
                    "allure.label.story:BoundaryValues",
                    "allure.label.severity:critical",
                    "allure.label.owner:JohnDoe",
                    "link:https://dev.example.com/",
                    "issue:AUTH-123",
                    "tms:TMS-456",
                    "allure.label.package:org.example",
                    "allure.label.testClass:TestMyWebsite",
                    "allure.label.testMethod:TestLabels()",
                    "GUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateProjectWithIncorrectCode", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 17
 testRunner.Given("open the ProjectsPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 18
 testRunner.When("user clicks Create new project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
 testRunner.And("creates a \"Incorrect\" project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
 testRunner.Then("Project is not created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CreateProject")]
        [NUnit.Framework.CategoryAttribute("allure.label.story:BoundaryValues")]
        [NUnit.Framework.CategoryAttribute("allure.label.severity:critical")]
        [NUnit.Framework.CategoryAttribute("allure.label.owner:JohnDoe")]
        [NUnit.Framework.CategoryAttribute("link:https://dev.example.com/")]
        [NUnit.Framework.CategoryAttribute("issue:AUTH-1234")]
        [NUnit.Framework.CategoryAttribute("tms:TMS-457")]
        [NUnit.Framework.CategoryAttribute("allure.label.package:org.example")]
        [NUnit.Framework.CategoryAttribute("allure.label.testClass:TestMyWebsite")]
        [NUnit.Framework.CategoryAttribute("allure.label.testMethod:TestLabels()")]
        [NUnit.Framework.CategoryAttribute("GUI")]
        public void CreateProject()
        {
            string[] tagsOfScenario = new string[] {
                    "allure.label.story:BoundaryValues",
                    "allure.label.severity:critical",
                    "allure.label.owner:JohnDoe",
                    "link:https://dev.example.com/",
                    "issue:AUTH-1234",
                    "tms:TMS-457",
                    "allure.label.package:org.example",
                    "allure.label.testClass:TestMyWebsite",
                    "allure.label.testMethod:TestLabels()",
                    "GUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateProject", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 32
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 33
 testRunner.Given("open the ProjectsPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
 testRunner.When("user clicks Create new project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 35
 testRunner.And("creates a \"Correct\" project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.Then("enter a new Project repository", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion