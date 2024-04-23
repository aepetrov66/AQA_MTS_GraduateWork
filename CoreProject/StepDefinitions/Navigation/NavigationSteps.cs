using CoreProject.Core;
using CoreProject.Helpers;
using CoreProject.Helpers.Configuration;
using CoreProject.Models.Enums;
using CoreProject.Models;
using CoreProject.Pages;

namespace CoreProject.StepDefinitions.Navigation;
public class NavigationSteps : BaseGuiStep
{
    public NavigationSteps(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext) { }

    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver, true);
    }

    public T SignIn<T>(LoginPage loginPage, TestDataType testDataType) where T: BasePage
    {
        User user;
        switch (testDataType)
        {
            case TestDataType.Correct:
                user = Configurator.CorrectUser ?? throw new InvalidOperationException();
                break;
            case TestDataType.Incorrect:
                user = Configurator.IncorrectUser ?? throw new InvalidOperationException();
                break;
            default:
                Logger.Error($"Тестовые данные не найдены");
                throw new InvalidOperationException();
        }
        loginPage.EmaiWrite(user.Username);
        loginPage.PswdWrite(user.Password);
        loginPage.RememberMe(false);
        return loginPage.SignInClick<T>();
    }

    public ProjectsPage NavigateToProjectPage()
    {
        LoginPage loginPage = NavigateToLoginPage();
        return SignIn<ProjectsPage>(loginPage, TestDataType.Correct);
    }

    public ProjectRepositoryPage NavigateToProjectRepositoryPage(string projectName)
    {
        ProjectsPage projectsPage = NavigateToProjectPage();
        return projectsPage.OpenProjectRepository(projectName);
    }
}
