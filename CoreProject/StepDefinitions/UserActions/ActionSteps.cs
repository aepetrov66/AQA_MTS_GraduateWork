using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.Models;
using CoreProject.Pages;

namespace CoreProject.StepDefinitions.UserActions;

public class ActionSteps : BaseGuiStep
{
    public ActionSteps(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext) { }

    public ProjectRepositoryPage CreateNewProject(ProjectsPage projectsPage)
    {
        projectsPage.CreateNewProjectDialog.ProjectName("aaaaaaaaaaaaaaaaaaaaaaaaa");
        projectsPage.CreateNewProjectDialog.ProjectCodeClear();
        projectsPage.CreateNewProjectDialog.ProjectCode("bbbbbbbbbb");
        projectsPage.CreateNewProjectDialog.Description("Description");
        projectsPage.CreateNewProjectDialog.RadioButtonSelect("public");
        return projectsPage.CreateNewProjectDialog.CreateProgectClick();
    }

    public void CreateNewIncorrectProject(ProjectsPage projectsPage)
    {
        projectsPage.CreateNewProjectDialog.ProjectName("aaaaaaaaaaaaaaaaaaaaaaaaa");
        projectsPage.CreateNewProjectDialog.ProjectCodeClear();
        projectsPage.CreateNewProjectDialog.ProjectCode("bbbbbbbbbbB");
        projectsPage.CreateNewProjectDialog.Description("Description");
        projectsPage.CreateNewProjectDialog.RadioButtonSelect("public");
        projectsPage.CreateNewProjectDialog.CreateProgectClick();
    }

    public ProjectRepositoryPage CreateNewTestCase(CreateTestCasePage createNewTestCasePage, TestCase testCase)
    {
        createNewTestCasePage.FillTheNewTestCaseBasic(testCase);
        return createNewTestCasePage.SaveTestCase();
    }

    public ProjectRepositoryPage DeleteTestCase(ProjectRepositoryPage projectRepositoryPage)
    {
        projectRepositoryPage.ChooseTestcase(3);
        projectRepositoryPage.DeleteClick();
        projectRepositoryPage.Confirm();
        return projectRepositoryPage.ConfirmButtonClick();
    }
}
