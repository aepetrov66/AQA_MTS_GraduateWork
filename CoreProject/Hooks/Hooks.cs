﻿using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.StepDefinitions;

namespace CoreProject.Hooks;

[Binding]
public class Hooks
{
    private readonly Browser _browser;
    private TestDataSteps _testDataSteps;

    public Hooks(Browser browser, TestDataSteps testDataSteps)
    {
        _browser = browser;
        _testDataSteps = testDataSteps;
    }

    [BeforeScenario("GUI")]
    public void BeforeGUIScenario()
    {
        _browser.Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [AfterScenario("GUI")]
    public void AfterScenario()
    {
        _browser.Driver.Quit();
    }
}