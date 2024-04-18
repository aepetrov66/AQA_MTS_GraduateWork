using AngleSharp.Dom;
using CoreProject.Helpers;
using OpenQA.Selenium;

namespace CoreProject.Wrappers.SimpleElements;

public class RadioButton
{
    private UIElement _uiElement;
    public RadioButton(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
    }
    public RadioButton(IWebDriver webDriver, IWebElement webElement)
    {
        _uiElement = new UIElement(webDriver, webElement);
    }
    public string GetAttribute(string attribue)
    {
        return _uiElement.GetAttribute(attribue);
    }
    public void Click()
    {
        _uiElement.Click();
    }
}
