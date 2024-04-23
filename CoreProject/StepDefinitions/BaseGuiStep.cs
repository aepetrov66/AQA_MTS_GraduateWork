using CoreProject.Core;
using NLog;
using OpenQA.Selenium;

namespace CoreProject.StepDefinitions;

public class BaseGuiStep
{
    protected IWebDriver Driver { get; }
    protected ScenarioContext ScenarioContext { get; }
    protected Logger Logger { get; }

    public BaseGuiStep(Browser browser, ScenarioContext scenarioContext)
    {
        Driver = browser.Driver;
        ScenarioContext = scenarioContext;
        Logger = LogManager.GetCurrentClassLogger();
    }
}