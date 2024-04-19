using CoreProject.Models;
using CoreProject.Pages.Dialogs;
using CoreProject.Wrappers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;

namespace CoreProject.Pages;

public class CreateTestCasePage : BasePage
{
    private static string END_POINT = "project/" + _projectCode;
    private static string _projectCode;

    // Описание элементов
    private static readonly By TitleBy = By.ClassName("IEC9um");
    private static readonly By NewTestCaseTitleInputBy = By.Id("title");
    private static readonly By StatusBy = By.XPath(".//label[@for='0-status']/following-sibling::div/div/div/input");
    private static readonly By DescriptionBy = By.XPath("//div[@class='ProseMirror toastui-editor-contents']/p");
    private static readonly By SuiteBy = By.XPath(".//label[@for='suite']/following-sibling::div/div/div/input");
    private static readonly By SeverityBy = By.XPath(".//label[@for='0-severity']/following-sibling::div/div/div/input");
    private static readonly By PriorityBy = By.XPath(".//label[@for='0-priority']/following-sibling::div/div/div/input");
    private static readonly By TypeBy = By.XPath(".//label[@for='0-type']/following-sibling::div/div/div/input"); 
    private static readonly By LayerBy = By.XPath(".//label[@for='0-layer']/following-sibling::div/div/div/input");
    private static readonly By IsFlakyBy = By.XPath(".//label[@for='0-is_flaky']/following-sibling::div/div/div/input");
    private static readonly By MilestoneBy = By.XPath(".//label[@for='milestone']/following-sibling::div/div/div/div[2]/input");
    private static readonly By BehaviorBy = By.XPath(".//label[@for='0-behavior']/following-sibling::div/div/div/input");
    private static readonly By AutomationStatusBy = By.XPath(".//label[@for='0-isManual']/following-sibling::div/div/div/input");
    private static readonly By SaveTestCaseButtonBy = By.Id("save-case");

    // Инициализация класса
    public CreateTestCasePage(IWebDriver driver, string projectCode) : base(driver)
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
    private Input Status => new Input(Driver, StatusBy);
    private Input Description => new Input(Driver, DescriptionBy);
    private Input Suite => new Input(Driver, SuiteBy);
    private Input Severity => new Input(Driver, SeverityBy);
    private Input Priority => new Input(Driver, PriorityBy);
    private Input Type => new Input(Driver, TypeBy);
    private Input Layer => new Input(Driver, LayerBy);
    private Input IsFlaky => new Input(Driver, IsFlakyBy);
    private Input Milestone => new Input(Driver, MilestoneBy);
    private Input Behavior => new Input(Driver, BehaviorBy);
    private Input AutomationStatus => new Input(Driver, AutomationStatusBy);
    private Button SaveTestCaseButton => new Button(Driver, SaveTestCaseButtonBy);

    // Методы действий с элементами
    public void FillNewTestCaseTitle(string title)
    {
        NewTestCaseTitleInput.SendKeys(title);
    }

    public ProjectRepositoryPage SaveTestCase()
    {
        SaveTestCaseButton.Click();
        return new ProjectRepositoryPage(Driver);
    }

    public void FillTheNewTestCaseBasic(TestCase testCase)
    {
        FillNewTestCaseTitle(testCase.TestCaseTitle);
        Status.SendKeys(testCase.Status);
        Description.SendKeys(testCase.Description);
        Suite.SendKeys(testCase.Suite);
        Severity.SendKeys(testCase.Severity);
        Priority.SendKeys(testCase.Priority);
        Type.SendKeys(testCase.Type);
        Layer.SendKeys(testCase.Layer);
        IsFlaky.SendKeys(testCase.IsFlaky);
        Milestone.SendKeys(testCase.Milestone);
        Behavior.SendKeys(testCase.Behavior);
        AutomationStatus.SendKeys(testCase.AutomationStatus);
    }
}