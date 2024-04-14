using OpenQA.Selenium;

namespace CoreProject.Wrappers.SimpleElements;

public class CheckBox
{
    private UIElement _uiElement;
    public CheckBox(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
    }
    public CheckBox(IWebDriver webDriver, IWebElement webElement)
    {
        _uiElement = new UIElement(webDriver, webElement);
    }

    public void CheckTheBox()
    {
        if (!_uiElement.Selected)
        {
            _uiElement.Click();
        }
    }
}
