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
    }
}
