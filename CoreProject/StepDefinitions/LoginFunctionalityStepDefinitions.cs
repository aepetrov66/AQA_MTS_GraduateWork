using System;
using TechTalk.SpecFlow;

namespace CoreProject.StepDefinitions
{
    [Binding]
    public class LoginFunctionalityStepDefinitions
    {
        [Given(@"open the login page")]
        public void GivenOpenTheLoginPage()
        {
            throw new PendingStepException();
        }

        [When(@"user enter ""([^""]*)"" to the email field")]
        public void WhenUserEnterToTheEmailField(string correctUsername)
        {
            throw new PendingStepException();
        }

        [When(@"user enter ""([^""]*)"" to the password field")]
        public void WhenUserEnterToThePasswordField(string correctPassword)
        {
            throw new PendingStepException();
        }

        [When(@"user clicks the log in button")]
        public void WhenUserClicksTheLogInButton()
        {
            throw new PendingStepException();
        }

        [Then(@"user is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            throw new PendingStepException();
        }
    }
}
