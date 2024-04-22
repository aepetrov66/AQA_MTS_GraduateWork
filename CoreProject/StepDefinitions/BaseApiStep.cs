using CoreProject.Clients;
using CoreProject.Core;
using CoreProject.Services;
using OpenQA.Selenium;

namespace CoreProject.StepDefinitions;

[Binding]
public class BaseApiStep
{
    protected ProjectService? ProjectService;

    [BeforeScenario("API")]
    public void BeforeGUIScenario()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
    }

    [AfterScenario("API")]
    public void AfterScenario()
    {
        ProjectService?.Dispose();
    }
}
