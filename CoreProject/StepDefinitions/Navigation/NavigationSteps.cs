using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.Pages;

namespace CoreProject.StepDefinitions.Navigation;
public class NavigationSteps : BaseGuiStep
{
    public NavigationSteps(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext) { }

    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver, true);
    }

    public ProjectsPage SignIn(LoginPage loginPage) 
    {
        loginPage.EmaiWrite(Configurator.AppSettings.Username);
        loginPage.PswdWrite(Configurator.AppSettings.Password);
        loginPage.RememberMe(false);
        loginPage.SignInClick();
        return new ProjectsPage(Driver);
    }

    public LoginPage NotSignIn(LoginPage loginPage)
    {
        loginPage.EmaiWrite("asdfas");
        loginPage.PswdWrite("adfasd");
        loginPage.RememberMe(true);
        loginPage.SignInClick();
        return new LoginPage(Driver, false);
    }

    public ProjectsPage NavigateToProjectPage()
    {
        LoginPage loginPage = NavigateToLoginPage();
        return SignIn(loginPage);
    }

    public ProjectRepositoryPage NavigateToProjectRepositoryPage(string projectName)
    {
        ProjectsPage projectsPage = NavigateToProjectPage();
        return projectsPage.OpenProjectRepository(projectName);
    }
}
