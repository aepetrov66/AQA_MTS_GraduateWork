using Allure.Net.Commons;
using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.StepDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;

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
        AllureApi.Step($"Открываем {Configurator.AppSettings.URL}");
        _browser.Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);

        _testDataSteps.CreateTestProject();
        _testDataSteps.CreateTestCase();
        _testDataSteps.CreateTestCase();
    }

    [AfterScenario("ENTITY")]
    public void AfterScenario()
    {
        AllureApi.Step($"Удаление Тестовых данных");
        _testDataSteps.DeleteTestProject();
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
