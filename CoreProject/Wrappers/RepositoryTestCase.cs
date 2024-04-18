using CoreProject.Helpers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;

namespace CoreProject.Wrappers;

public class RepositoryTestCase
{
    private UIElement _uiElement;

    public RepositoryTestCase(IWebDriver driver, string testCaseTitle)
    {
        UIElement table = new UIElement(driver, By.ClassName("rveQx2"));
        List<UIElement> testCases = new List<UIElement>();
        foreach (var testCase in table.FindUIElements(By.CssSelector("div[class~='tYBglj']")))
        {
            testCases.Add(testCase);
        }
        _uiElement = testCases.Where(element => element.FindUIElement(By.CssSelector("div[class~='t1vo_q']")).Text.Equals(testCaseTitle)).First();
    }

    public string GetTitle()
    {
        var titleElement = _uiElement.FindUIElement(By.CssSelector("div[class~='t1vo_q']"));
        return titleElement.Text;
    }

    public void Choose()
    {
        var checkBox = _uiElement.FindElement(By.CssSelector("input[type='checkbox']"));
        checkBox.Click();
    }
}
