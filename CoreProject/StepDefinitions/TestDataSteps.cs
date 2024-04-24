using Allure.Net.Commons;
using CoreProject.Clients;
using CoreProject.Helpers;
using CoreProject.Services;
using NLog;
using RestSharp;

namespace CoreProject.StepDefinitions;

public class TestDataSteps
{
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public void DeleteTestProject()
    {
        AllureApi.Step($"Удалить тестовый проект");

        var restClient = new RestClientExtended();
        var projectService = new ProjectService(restClient);
        var response = projectService.DeleteProject(TestData.CorrectProject.Code.ToUpper());
        Logger.Info($"Удаление тестового проекта, статус код: {response}");
        projectService?.Dispose();
    }

    public void CreateTestProject()
    {
        AllureApi.Step($"Создать тестовый проект");
        var restClient = new RestClientExtended();
        var projectService = new ProjectService(restClient);

        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("title", TestData.CorrectProject.Title);
        json.Add("code", TestData.CorrectProject.Code);

        var response = projectService!.AddProject(json);

        Logger.Info($"Создание тестового проекта, статус код: {response.Status}");
        projectService?.Dispose();
    }

    public void DeleteTestCase()
    {
        AllureApi.Step($"Удалить тестовый случай");
        var restClient = new RestClientExtended();
        var testCaseService = new TestCaseService(restClient);
        var response = testCaseService.DeleteProject(TestData.CorrectProject.Code.ToUpper(), 1);
        Logger.Info($"Удаление тесткейса, статус код: {response}");
        testCaseService?.Dispose();
    }

    public void CreateTestCase()
    {
        AllureApi.Step($"Создать тестовый случай");
        var restClient = new RestClientExtended();
        var testCaseService = new TestCaseService(restClient);

        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("title", TestData.TestCase.TestCaseTitle);
        json.Add("description", TestData.TestCase.Description);

        var response = testCaseService!.AddTestCase(TestData.CorrectProject.Code.ToUpper(), json);

        Logger.Info($"Создание тесткейса, статус код: {response}");
        testCaseService?.Dispose();
    }

}

