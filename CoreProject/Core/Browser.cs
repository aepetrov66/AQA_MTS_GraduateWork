using OpenQA.Selenium;
using CoreProject.Helpers.Configuration;

namespace CoreProject.Core;

public class Browser
{
    public IWebDriver? Driver { get; }

    public Browser()
    {
        Driver = new DriverFactory().GetChromeDriver();

        Driver?.Manage().Window.Maximize();
        Driver?.Manage().Cookies.DeleteAllCookies();
        Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
