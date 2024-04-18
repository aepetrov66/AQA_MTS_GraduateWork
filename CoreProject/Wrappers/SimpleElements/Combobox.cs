using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreProject.Wrappers.SimpleElements;

public class Combobox
{
    private UIElement _uiElement;
    private SelectElement _selectElement;
    public Combobox(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
        _selectElement = new SelectElement(_uiElement);
    }
    public void SelectByText(string text)
    {
        _selectElement.SelectByText(text);
    }
    public string GetSelectedOptionText()
    {
        return _selectElement.SelectedOption.Text;
    }
    public string[] GetAllOptionsTexts()
    {
        return _selectElement.Options.Select(o => o.Text).ToArray();
    }
}