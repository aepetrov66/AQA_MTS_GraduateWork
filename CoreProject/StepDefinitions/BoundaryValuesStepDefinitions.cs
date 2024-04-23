using CoreProject.Core;
using CoreProject.Helpers;
using CoreProject.Models.Enums;
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
        private TestDataSteps _testDataSteps;

        public BoundaryValuesStepDefinitions(Browser browser, ScenarioContext scenarioContext) : base(browser, scenarioContext)
        {
            _navigationSteps = new NavigationSteps(browser, scenarioContext);
            _actionSteps = new ActionSteps(browser, scenarioContext);
            _testDataSteps = new TestDataSteps();
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

        [When(@"creates a ""([^""]*)"" project")]
        public void WhenCreatesAProject(string dataTypeString)
        {
            switch (dataTypeString.ToLower())
            {
                case "correct":
                    Logger.Info("Позитивный тестовый сценарий");
                    _repositoryPage = _actionSteps.CreateNewProject<ProjectRepositoryPage>(_projectsPage, TestDataType.Correct);
                    break;
                case "incorrect":
                    Logger.Info("Негативный тестовый сценарий");
                    _projectsPage = _actionSteps.CreateNewProject<ProjectsPage>(_projectsPage, TestDataType.Incorrect);
                    break;
            }
        }

        [Then(@"enter a new Project repository")]
        public void WhenEnterToTheProjectNameField1()
        {
            Assert.That(_repositoryPage.IsPageOpened() && _repositoryPage.GetProjectCode().Equals(TestData.CorrectProject.Code));
            _testDataSteps.DeleteTestProject();
        }

        [Then(@"Project is not created")]
        public void ThenAssert()
        {
            Assert.That(_projectsPage.GetErrorText().Equals("Data is invalid."));
            Logger.Info($"Ошибка при создании проекта: {_projectsPage.GetErrorText()}");
        }
    }
}
