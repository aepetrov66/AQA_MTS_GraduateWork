using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.StepDefinitions;

namespace CoreProject.Hooks;

[Binding]
public class EntityHooks
{
    private readonly Browser _browser;
    private readonly TestDataSteps _testDataSteps;

    public EntityHooks(Browser browser, TestDataSteps testDataSteps)
    {
        _browser = browser;
        _testDataSteps = testDataSteps;
    }

    [BeforeScenario("ENTITY")]
    public void BeforeGUIScenario()
    {
        _browser.Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);

        _testDataSteps.CreateTestProject();
        _testDataSteps.CreateTestCase();
        _testDataSteps.CreateTestCase();
    }

    [AfterScenario("ENTITY")]
    public void AfterScenario()
    {
        _testDataSteps.DeleteTestProject();
        _browser.Driver.Quit();
    }
}
