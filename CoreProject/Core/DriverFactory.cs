﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace CoreProject.Core;

public class DriverFactory
{
    public IWebDriver? GetChromeDriver()
    {
        var chromeOptions = new ChromeOptions();
        //chromeOptions.AddArguments("--incognito");
        chromeOptions.AddArguments("--disable-gpu");
        chromeOptions.AddArguments("--disable-extensions");
        chromeOptions.AddArguments("--headless");
        chromeOptions.AddArguments("--remote-debugging-pipe");


        chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
        chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);

        new DriverManager().SetUpDriver(new ChromeConfig());
        return new ChromeDriver(chromeOptions);
    }
}