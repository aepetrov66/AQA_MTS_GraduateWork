using CoreProject.Core;
using OpenQA.Selenium;

namespace CoreProject.StepDefinitions;

public class BaseGuiStep
{
    protected IWebDriver Driver { get; }
    protected ScenarioContext ScenarioContext { get; }

    public BaseGuiStep(Browser browser, ScenarioContext scenarioContext)
    {
        Driver = browser.Driver;
        ScenarioContext = scenarioContext;
    }
}