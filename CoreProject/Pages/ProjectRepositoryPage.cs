using CoreProject.Pages.Dialogs;
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

    // Инициализация класса
    public ProjectRepositoryPage(IWebDriver driver) : base(driver) { }
    protected override string GetEndpoint() => END_POINT+GetProjectCode();
    public override bool IsPageOpened() => Title.Displayed;

    // Методы
    // Методы поиска элементов
    private IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
    private Button CreateSuiteButton => new Button(Driver, CreateSuiteButtonBy);
    private Button CreateCaseButton => new Button(Driver, CreateCaseButtonBy);


    // Методы действий с элементами
    public void CreateSuiteButtonClick() => CreateSuiteButton.Click();
    public CreateNewTestCasePage CreateCaseButtonClick()
    {
        string projectCode = GetProjectCode();
        CreateCaseButton.Click();
        return new CreateNewTestCasePage(Driver, projectCode);
    }

    // Методы получения свойств
    public string GetProjectCode()
    {
        var titleText = WaitsHelper.WaitForExists(TitleBy).Text;
        var projectCode = titleText.Substring(0, titleText.IndexOf(' '));
        return projectCode;
    }
}
