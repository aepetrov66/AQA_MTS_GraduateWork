using Allure.Net.Commons;
using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.StepDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;

namespace CoreProject.Hooks;

[Binding]
public class Hooks
{
    private readonly Browser _browser;

    public Hooks(Browser browser, TestDataSteps testDataSteps)
    {
        _browser = browser;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [BeforeScenario("GUI")]
    public void BeforeGUIScenario()
    {
        _browser.Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [AfterScenario("GUI")]
    public void AfterScenario()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Screenshot screenshot = ((ITakesScreenshot)_browser.Driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
            AllureApi.AddAttachment("data.txt", "text/plain", Encoding.UTF8.GetBytes("This os the file content."));
        }

        _browser.Driver.Quit();
    }
}