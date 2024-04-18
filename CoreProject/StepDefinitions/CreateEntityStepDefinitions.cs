using CoreProject.Core;
using CoreProject.Pages;
using CoreProject.StepDefinitions.Navigation;
using CoreProject.StepDefinitions.UserActions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CoreProject.StepDefinitions
{
    [Binding]
    public class CreateEntityStepDefinitions : BaseGuiStep
    {
        private ProjectRepositoryPage _projectRepositoryPage;
        private CreateNewTestCasePage _newTestCasePage;
        private NavigationSteps _navigationSteps;
        private ActionSteps _actionSteps;

        public CreateEntityStepDefinitions(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext)
        {
            _navigationSteps = new NavigationSteps(browser, scenarioContext);
            _actionSteps = new ActionSteps(browser, scenarioContext);
        }

        [Given(@"open the Project")]
        public void GivenOpenTheProject()
        {
            _projectRepositoryPage = _navigationSteps.NavigateToProjectRepositoryPage("DDDDDDDDDDDDDDDDDDDDDDDDD");
        }

        [When(@"user clicks CreateTestCaseButton")]
        public void WhenUserClicksCreateTestCaseButton()
        {
            _newTestCasePage = _projectRepositoryPage.CreateCaseButtonClick();
        }

        [When(@"user fill the NewTestCaseTitle")]
        public void AndUserFillTheNewTestCaseTitle()
        {
            _newTestCasePage.PrintNewTestCaseTitle("Smth");
        }

        [When(@"navigate Backward")]
        public void WhenNavigateBackward()
        {
            Driver.Navigate().Back();
        }

        [Then(@"assert the PopUp")]
        public void ThenAssertThePopUp()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("Are you sure you want to leave?"));
            alert.Accept();
            _projectRepositoryPage.IsPageOpened();
        }
    }
}