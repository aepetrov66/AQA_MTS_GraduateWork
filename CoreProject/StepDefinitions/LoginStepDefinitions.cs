using Allure.Net.Commons;
using CoreProject.Core;
using CoreProject.Models.Enums;
using CoreProject.Pages;
using CoreProject.StepDefinitions.Navigation;
using CoreProject.StepDefinitions.UserActions;
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

        [When(@"""([^""]*)"" sign in")]
        public void WhenSignIn(string dataTypeString)
        {
            AllureApi.Step($"Выполняем вход с {dataTypeString} userData", () =>
            {
                switch (dataTypeString.ToLower())
                {
                    case "correct":
                        Logger.Info("Позитивный тестовый сценарий");
                        _projectsPage = _navigationSteps.SignIn<ProjectsPage>(_loginPage, TestDataType.Correct);
                        break;
                    case "incorrect":
                        Logger.Info("Негативный тестовый сценарий");
                        _loginPage = _navigationSteps.SignIn<LoginPage>(_loginPage, TestDataType.Incorrect);
                        break;
                }
            });
        }

        [Then(@"user is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            Assert.That(_projectsPage.IsPageOpened());
        }

        [Then(@"assert error message")]
        public void ThenAssertErrorMessage()
        {
            AllureApi.Step($"Проверка сообщения об ошибке", () =>
            {
                Assert.That(_loginPage.GetErrorLabelText().Contains("These credentials do not match our records."));
                Logger.Info($"Ошибка при входе: {_loginPage.GetErrorLabelText()}");
            });
        }

    }
}
