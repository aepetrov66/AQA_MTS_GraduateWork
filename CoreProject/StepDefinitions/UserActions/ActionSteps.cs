using CoreProject.Core;
using CoreProject.Helpers.Configuration;
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
}
