using OpenQA.Selenium;

namespace CoreProject.Wrappers.SimpleElements;

public class Input
{
    private UIElement _uiElement;
    public Input(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
    }
    public Input(IWebDriver webDriver, IWebElement webElement)
    {
        _uiElement = new UIElement(webDriver, webElement);
    }
    public void SendKeys(string str)
    {
        _uiElement.SendKeys(str);
    }

    public void Clear()
    {
        _uiElement.Clear();
    }
    public bool Displayed => _uiElement.Displayed;
}
