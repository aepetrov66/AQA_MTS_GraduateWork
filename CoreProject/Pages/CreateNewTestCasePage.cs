using CoreProject.Pages.Dialogs;
using CoreProject.Wrappers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;

namespace CoreProject.Pages;

public class CreateNewTestCasePage : BasePage
{
    private static string END_POINT = "project/" + _projectCode;
    private static string _projectCode;

    // Описание элементов
    private static readonly By TitleBy = By.ClassName("IEC9um");
    private static readonly By NewTestCaseTitleInputBy = By.Id("title");

    // Инициализация класса
    public CreateNewTestCasePage(IWebDriver driver, string projectCode) : base(driver)
    {
        _projectCode = projectCode;
    }
    protected override string GetEndpoint() => END_POINT;
    public string GetProjectCode() => _projectCode;
    public override bool IsPageOpened() => Title.Displayed && Title.Text.Contains("Create test case");

    // Методы
    // Методы поиска элементов
    private IWebElement Title => WaitsHelper.WaitForVisibilityLocatedBy(TitleBy);
    private Input NewTestCaseTitleInput => new Input(Driver, NewTestCaseTitleInputBy);

    // Методы действий с элементами
    public void PrintNewTestCaseTitle(string title)
    {
        NewTestCaseTitleInput.SendKeys(title);
    }

    // Методы получения свойств

}