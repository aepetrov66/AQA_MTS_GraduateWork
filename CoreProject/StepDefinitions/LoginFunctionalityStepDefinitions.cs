using CoreProject.Core;
using CoreProject.Pages;

namespace CoreProject.StepDefinitions;

[Binding]
public class LoginFunctionalityStepDefinitions : BaseGuiStep
{
    private readonly LoginPage _loginPage;
    public LoginFunctionalityStepDefinitions(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext)
    {
        _loginPage = new LoginPage(Driver);
    }

    [Given(@"open the login page")]
    public void GivenOpenTheLoginPage()
    {
        
    }

    [When(@"user enter ""([^""]*)"" to the email field")]
    public void WhenUserEnterToTheEmailField(string correctUsername)
    {
        _loginPage.EmaiWrite(correctUsername);
    }

    [When(@"user enter ""([^""]*)"" to the password field")]
    public void WhenUserEnterToThePasswordField(string correctPassword)
    {
        _loginPage.PswdWrite(correctPassword);
    }

    [When(@"user clicks the log in button")]
    public void WhenUserClicksTheLogInButton()
    {
        _loginPage.SignInClick();
    }

    [Then(@"user is successfully logged in")]
    public void ThenUserIsSuccessfullyLoggedIn()
    {
        Thread.Sleep(30000);
    }
}
