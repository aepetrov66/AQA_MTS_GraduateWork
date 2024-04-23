using CoreProject.Clients;
using CoreProject.Core;
using CoreProject.Services;
using NLog;
using OpenQA.Selenium;

namespace CoreProject.StepDefinitions;

[Binding]
public class BaseApiStep
{
    protected ProjectService? ProjectService { get; }
    protected ScenarioContext ScenarioContext { get; }
    protected Logger Logger { get; }

    public BaseApiStep(ScenarioContext scenarioContext, ProjectService projectService)
    {
        ScenarioContext = scenarioContext;
        Logger = LogManager.GetCurrentClassLogger();
        ProjectService = projectService;
    }

    /*[BeforeScenario("API")]
    public void BeforeGUIScenario()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
    }

    [AfterScenario("API")]
    public void AfterScenario()
    {
        ProjectService?.Dispose();
    }*/
}
