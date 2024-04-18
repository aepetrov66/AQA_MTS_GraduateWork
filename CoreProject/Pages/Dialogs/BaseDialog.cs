using CoreProject.Helpers.Configuration;
using CoreProject.Helpers;
using OpenQA.Selenium;

namespace CoreProject.Pages.Dialogs;

public abstract class BaseDialog
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }
    public BaseDialog(IWebDriver driver)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }
    public abstract bool IsDialogActive();
}
