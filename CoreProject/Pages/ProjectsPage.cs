using CoreProject.Helpers;
using CoreProject.Pages.Dialogs;
using CoreProject.Wrappers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;

namespace CoreProject.Pages;
public class ProjectsPage : BasePage
{
    private static string END_POINT = "projects";

    // Описание элементов
    public CreateNewProjectDialog CreateNewProjectDialog;
    private static readonly By TitleBy = By.ClassName("uA6zAY");
    private static readonly By CreateProjectButtonBy = By.ClassName("TKsrzo");
    private static readonly By TableBy = By.CssSelector("table[class=P3tqoY]");

    // Инициализация класса
    public ProjectsPage(IWebDriver driver) : base(driver) { }
    protected override string GetEndpoint() => END_POINT;
    public override bool IsPageOpened() => Title.Displayed && Title.Text.Equals("Projects");

    // Методы
    // Методы поиска элементов
    private IWebElement Title => WaitsHelper.WaitForVisibilityLocatedBy(TitleBy);
    private Button CreateProjectButton => new Button(Driver, CreateProjectButtonBy);
    private ProjectsTable Table => new ProjectsTable(Driver, TableBy);
    
    // Методы действий с элементами
    public void CreateProjectButtonClick() 
    { 
        CreateProjectButton.Click(); 
        CreateNewProjectDialog = new CreateNewProjectDialog(Driver); 
    }

    public ProjectRepositoryPage OpenProjectRepository(string projectName)
    {
        Table.GetProjectCell(projectName).Click();
        return new ProjectRepositoryPage(Driver);
    }

    // Методы получения свойств

}
