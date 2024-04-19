using AngleSharp.Dom;
using CoreProject.Helpers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace CoreProject.Wrappers;

public class RepositoryTestCase
{
    List<UIElement> _testCases;

    public RepositoryTestCase(IWebDriver driver)
    {
        UIElement table = new UIElement(driver, By.ClassName("rveQx2"));
        _testCases = new List<UIElement>();
        foreach (var testCase in table.FindUIElements(By.CssSelector("div[class~='tYBglj']")))
        {
            _testCases.Add(testCase);
        }
        _testCases = _testCases.OrderBy(testcase => GetTestCaseId(testcase)).ToList();
    }

    public int GetTestCaseId(UIElement uIElement)
    {
        Regex regex = new Regex(@"(\d+)$");
        Match match = regex.Match(uIElement.FindElement(By.CssSelector("a[class~='ZAhOK9']")).Text);
        if (match.Success)
        {
            int number = int.Parse(match.Groups[1].Value);
            return number;
        }
        throw new Exception("Не удалось получить TestCase Id");
    }

    public UIElement GetTestCaseById(int id)
    {
        var tc = _testCases.Where(testCase => GetTestCaseId(testCase) == id).First();
        if (tc == null) throw new Exception("No such TestCase");
        return tc;
    }

    public List<int> GetTestCasesIds()
    {
        var intList = new List<int>();
        foreach(var tc in _testCases)
        {
            intList.Add(GetTestCaseId(tc));
        }
        return intList;
    }

    public int GetTheLatestTestCaseId()
    {
        return GetTestCaseId(_testCases[_testCases.Count-1]);
    }


    public string GetTitle(int id)
    {
        var tc = GetTestCaseById(id);
        var titleElement = tc.FindUIElement(By.CssSelector("div[class~='t1vo_q']"));
        return titleElement.Text;
    }

    public void Choose(int id)
    {
        var tc = GetTestCaseById(id);
        var checkBox = tc.FindElement(By.CssSelector("input[type='checkbox']"));
        checkBox.Click();
    }
}
