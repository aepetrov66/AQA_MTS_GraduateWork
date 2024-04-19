using CoreProject.Core;
using CoreProject.Pages;
using CoreProject.StepDefinitions.Navigation;
using CoreProject.StepDefinitions.UserActions;
using NUnit.Framework;

namespace CoreProject.StepDefinitions
{
    [Binding]
    public class BoundaryValuesStepDefinitions : BaseGuiStep
    {
        private ProjectRepositoryPage _repositoryPage;
        private ProjectsPage _projectsPage;
        private NavigationSteps _navigationSteps;
        private ActionSteps _actionSteps;
        public BoundaryValuesStepDefinitions(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext)
        {
            _navigationSteps = new NavigationSteps(browser, scenarioContext);
            _actionSteps = new ActionSteps(browser, scenarioContext);
        }

        [Given(@"open the ProjectsPage")]
        public void GivenOpenTheProjectsPage()
        {
            _projectsPage = _navigationSteps.NavigateToProjectPage();
        }

        [When(@"user clicks Create new project")]
        public void WhenUserClicksCreateNewProject()
        {
            _projectsPage.CreateProjectButtonClick();
        }

        [When(@"fills the form")]
        public void WhenEnterToTheProjectNameField()
        {
            _repositoryPage = _actionSteps.CreateNewProject(_projectsPage);
        }

        [Then(@"enter a new Project repository")]
        public void WhenEnterToTheProjectNameField1()
        {
            Assert.That(_repositoryPage.IsPageOpened() && _repositoryPage.GetProjectCode().Equals("BBBBBBBBBB"));
        }

        [When(@"incorrect fills the form")]
        public void WhenIncorrectFillsTheForm()
        {
            _repositoryPage = _actionSteps.CreateNewProject(_projectsPage);
        }

        [Then(@"assert")]
        public void ThenAssert()
        {
            Assert.That(_projectsPage.GetErrorText().Equals("Data is invalid."));
        }

    }
}
