using CoreProject.Core;
using CoreProject.Helpers;
using CoreProject.Models;
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
        private CreateTestCasePage _newTestCasePage;
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
            _projectRepositoryPage = _navigationSteps.NavigateToProjectRepositoryPage(TestData.CorrectProject.Title);
        }

        [When(@"user clicks CreateTestCaseButton")]
        public void WhenUserClicksCreateTestCaseButton()
        {
            _newTestCasePage = _projectRepositoryPage.CreateCaseButtonClick();
        }

        [When(@"user fills the TestCaseBasic")]
        public void WhenUserFillsTheTestCaseBasic()
        {
            _projectRepositoryPage = _actionSteps.CreateNewTestCase(_newTestCasePage, TestData.TestCase);
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
            Logger.Info($"Текст всплывающего сообщения: {alert.Text}");
            alert.Accept();
            _projectRepositoryPage.IsPageOpened();
        }

        [Then(@"assert the ProjectRepository page is open")]
        public void ThenAssertTheProjectRepositoryPageIsOpen()
        {
            Assert.That(_projectRepositoryPage.IsPageOpened());
        }

        [Then(@"new testCase is created")]
        public void ThenNewTestCaseIsCreated()
        {
            Assert.That(_projectRepositoryPage.LatestTestCaseTitleAssert(TestData.TestCase.TestCaseTitle));
        }

        [When(@"user delete TestCase")]
        public void WhenUserDeleteTestCase()
        {
            _projectRepositoryPage = _actionSteps.DeleteTestCase(_projectRepositoryPage);
        }

        [Then(@"there is no such testCase")]
        public void ThenThereIsNoSuchTestCase()
        {
            Driver.Navigate().Refresh();
            var list = _projectRepositoryPage.GetTescasesIds();
            Assert.That(!list.Contains(1));
        }

        [When(@"user fill the NewTestCaseTitle")]
        public void WhenUserFillTheNewTestCaseTitle()
        {
            _newTestCasePage.FillNewTestCaseTitle("afsdfasdf");
        }

        [When(@"user uploads file")]
        public void WhenUserUploadsFile()
        {
            _newTestCasePage.AddAttachment("Dobby.jpg");
        }

        [Then(@"assert the file")]
        public void ThenAsserTheFile()
        {
            Assert.That(_newTestCasePage.ImgExists());
        }
    }
}