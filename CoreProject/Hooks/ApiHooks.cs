using CoreProject.Clients;
using CoreProject.Core;
using CoreProject.Services;
using CoreProject.StepDefinitions;
using NLog;

namespace CoreProject.Hooks;

[Binding]
public class ApiHooks
{
    protected ProjectService? ProjectService;
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private TestDataSteps _testDataSteps;

    public ApiHooks(TestDataSteps testDataSteps)
    {
        _testDataSteps = testDataSteps;
    }

    [BeforeScenario("API")]
    public void BeforeGUIScenario()
    {
        _testDataSteps.CreateTestProject();
        _testDataSteps.CreateTestCase();
        _testDataSteps.CreateTestCase();
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
    }

    [AfterScenario("API")]
    public void AfterScenario()
    {

        _testDataSteps.DeleteTestProject();
        ProjectService?.Dispose();
    }
}
