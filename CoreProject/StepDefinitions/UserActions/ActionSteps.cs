using CoreProject.Clients;
using CoreProject.Core;
using CoreProject.Helpers;
using CoreProject.Helpers.Configuration;
using CoreProject.Models;
using CoreProject.Models.Enums;
using CoreProject.Pages;
using CoreProject.Services;

namespace CoreProject.StepDefinitions.UserActions;

public class ActionSteps : BaseGuiStep
{
    private ProjectService? ProjectService;
    public ActionSteps(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext)
    {
        var restClient = new RestClientExtended();
        var projectService = new ProjectService(restClient);
    }

    public T CreateNewProject<T>(ProjectsPage projectsPage, TestDataType testDataType) where T : BasePage
    {
        Project project;
        switch (testDataType)
        {
            case TestDataType.Correct:
                project = TestData.CorrectProject ?? throw new InvalidOperationException();
                break;
            case TestDataType.Incorrect:
                project = TestData.IncorrectProject ?? throw new InvalidOperationException();
                break;
            default: Logger.Error($"Тестовые данные не найдены");
                throw new InvalidOperationException();
        }
        projectsPage.CreateNewProjectDialog.ProjectNameClear();
        projectsPage.CreateNewProjectDialog.ProjectName(project.Title!);
        projectsPage.CreateNewProjectDialog.ProjectCodeClear();
        projectsPage.CreateNewProjectDialog.ProjectCode(project.Code!);
        projectsPage.CreateNewProjectDialog.Description("Some description.");
        projectsPage.CreateNewProjectDialog.RadioButtonSelect("public");
        return projectsPage.CreateNewProjectDialog.CreateProgectClick<T>();
    }

    public ProjectRepositoryPage CreateNewTestCase(CreateTestCasePage createNewTestCasePage, TestCase testCase)
    {
        createNewTestCasePage.FillTheNewTestCaseBasic(testCase);
        return createNewTestCasePage.SaveTestCase();
    }

    public ProjectRepositoryPage DeleteTestCase(ProjectRepositoryPage projectRepositoryPage)
    {
        projectRepositoryPage.ChooseTestcase(1);
        projectRepositoryPage.DeleteClick();
        projectRepositoryPage.Confirm();
        return projectRepositoryPage.ConfirmButtonClick();
    }
}
