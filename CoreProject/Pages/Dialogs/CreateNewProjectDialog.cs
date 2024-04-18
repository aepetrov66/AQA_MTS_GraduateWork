using CoreProject.Helpers;
using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace CoreProject.Pages.Dialogs;

public class CreateNewProjectDialog : BaseDialog
{
    // Описание элементов
    private static readonly By TitleBy = By.ClassName("iXHPjR");
    private static readonly By ProjectNameInputBy = By.Id("project-name");
    private static readonly By ProjectCodeInputBy = By.Id("project-code");
    private static readonly By DescriptionInputBy = By.Id("description-area");
    private static readonly By RadioButtonsBy = By.CssSelector("input[type=radio]");
    private static readonly By CreateProjectButtonBy = By.CssSelector("button[type=submit]");
    // Инициализация класса
    public CreateNewProjectDialog(IWebDriver driver) : base(driver) { }
    public override bool IsDialogActive() => Title.Displayed && Title.Text.Equals("Create new project");

    // Методы
    // Методы поиска элементов
    private IWebElement Title => WaitsHelper.WaitForVisibilityLocatedBy(TitleBy);
    private Input ProjectNameInput => new Input(Driver, ProjectNameInputBy);
    private Input ProjectCodeInput => new Input(Driver, ProjectCodeInputBy);
    private Input DescriptionInput => new Input(Driver, DescriptionInputBy);
    private Button CreateProjectButton => new Button(Driver, CreateProjectButtonBy);
    private List<RadioButton> RadioButtons => WaitsHelper.WaitForPresenceOfAllRadioButtonsLocatedBy(RadioButtonsBy);
    

    // Методы действий с элементами
    public void ProjectName(string projectName) => ProjectNameInput.SendKeys(projectName);
    public void ProjectCodeClear() => ProjectCodeInput.Clear();
    public void ProjectCode(string projectCode) => ProjectCodeInput.SendKeys(projectCode);
    public void Description(string description) => DescriptionInput.SendKeys(description);
    public void RadioButtonSelect(string value)
    {
        foreach(var radioButton in RadioButtons)
        {
            if (radioButton.GetAttribute("value").Equals(value))
            {
                radioButton.Click();
                break;
            }
        }
    }
    public ProjectRepositoryPage CreateProgectClick()
    {
        CreateProjectButton.Click();
        return new ProjectRepositoryPage(Driver);
    }
    // Методы получения свойств
}
