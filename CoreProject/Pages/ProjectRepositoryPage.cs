using CoreProject.Pages.Dialogs;
using CoreProject.Wrappers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Pages;

public class ProjectRepositoryPage : BasePage
{
    private static string END_POINT = "projects/";

    // Описание элементов
    private static readonly By TitleBy = By.XPath(".//h1[@class='pOpqJc']");
    private static readonly By CreateSuiteButtonBy = By.Id("create-suite-button");
    private static readonly By CreateCaseButtonBy = By.Id("create-case-button");
    private static readonly By DeleteButtonBy = By.CssSelector("#application-content > div > div.ko5Gzq > div > div.d-flex.VyDjOX > button.btn.btn-secondary.me-2");
    private static readonly By ConfirmInputBy = By.CssSelector("input[name=confirm]");
    private static readonly By ConfirmButtonBy = By.CssSelector("button[type=submit]");

    // Инициализация класса
    public ProjectRepositoryPage(IWebDriver driver) : base(driver) { }
    protected override string GetEndpoint() => END_POINT+GetProjectCode();
    public override bool IsPageOpened() => Title.Displayed;

    // Методы
    // Методы поиска элементов
    private IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
    private Button CreateSuiteButton => new Button(Driver, CreateSuiteButtonBy);
    private Button CreateCaseButton => new Button(Driver, CreateCaseButtonBy);
    private Button DeleteButton => new Button(Driver, DeleteButtonBy);
    private Input ConfirmInput => new Input(Driver, ConfirmInputBy);
    private Button ConfirmButton => new Button(Driver, ConfirmButtonBy);


    // Методы действий с элементами
    public void CreateSuiteButtonClick() => CreateSuiteButton.Click();
    public void DeleteClick() => DeleteButton.Click();
    public CreateTestCasePage CreateCaseButtonClick()
    {
        string projectCode = GetProjectCode();
        CreateCaseButton.Click();
        return new CreateTestCasePage(Driver, projectCode);
    }
    public void ChooseTestCase(string title)
    {
        RepositoryTestCase testCase = new RepositoryTestCase(Driver, title);
        testCase.Choose();
    }
    public void Confirm()
    {
        ConfirmInput.SendKeys("CONFIRM");
    }
    public ProjectRepositoryPage ConfirmButtonClick()
    {
        ConfirmButton.Click();
        return new ProjectRepositoryPage(Driver);
    }

    // Методы получения свойств
    public string GetProjectCode()
    {
        var titleText = WaitsHelper.WaitForExists(TitleBy).Text;
        var projectCode = titleText.Substring(0, titleText.IndexOf(' '));
        return projectCode;
    }

    public bool TestCaseExists(string title)
    {
        RepositoryTestCase testCase = new RepositoryTestCase(Driver, title);
        if(testCase.GetTitle().Equals(title)) return true;
        else return false;
    }
}
