using CoreProject.Core;
using CoreProject.Pages;
using CoreProject.StepDefinitions.Navigation;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CoreProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : BaseGuiStep
    {
        private LoginPage _loginPage;
        private ProjectsPage _projectsPage;
        private NavigationSteps _navigationSteps;
        public LoginStepDefinitions(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext)
        {
            _navigationSteps = new NavigationSteps(browser, scenarioContext);
        }

        [Given(@"open the LoginPage")]
        public void GivenOpenTheLoginPage()
        {
            _loginPage = _navigationSteps.NavigateToLoginPage();
        }

        [When(@"sign in")]
        public void WhenSignIn()
        {
            _projectsPage = _navigationSteps.SignIn(_loginPage);
        }

        [Then(@"user is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            Assert.That(_projectsPage.IsPageOpened());
        }

        [When(@"incorrect sign in")]
        public void WhenIncorrectSignIn()
        {
            _loginPage = _navigationSteps.NotSignIn(_loginPage);
        }

        [Then(@"assert error message")]
        public void ThenAssertErrorMessage()
        {
            Assert.That(_loginPage.GetErrorLabelText().Contains("does not match format email of type string"));
        }

    }
}
