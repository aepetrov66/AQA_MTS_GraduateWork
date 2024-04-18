using CoreProject.Wrappers.SimpleElements;
using OpenQA.Selenium;

namespace CoreProject.Pages;

public class LoginPage : BasePage
{
    private static string END_POINT = "login";

    // Описание элементов
    private static readonly By EmailInputBy = By.Name("email");
    private static readonly By PswdInputBy = By.Name("password");
    private static readonly By SignInButtonBy = By.CssSelector("button[type=submit]");
    private static readonly By RememberMeBoxBy = By.Name("remember");
    private static readonly By ErrorLabelBy = By.CssSelector("span[class=xtWHgv]");

    // Инициализация класса
    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl) { }
    protected override string GetEndpoint() => END_POINT;
    public override bool IsPageOpened() => EmailInput.Displayed && PswdInput.Displayed;

    // Методы
    // Методы поиска элементов
    private Input EmailInput => new Input(Driver, EmailInputBy);
    private Input PswdInput => new Input(Driver, PswdInputBy);
    private Button SignInButton => new Button(Driver, SignInButtonBy);
    private CheckBox RememberMeBox => new CheckBox(Driver, RememberMeBoxBy);
    private IWebElement ErrorLabel => WaitsHelper.WaitForExists(ErrorLabelBy);

    // Методы действий с элементами
    public void SignInClick() => SignInButton.Click();
    public void EmaiWrite(string email) => EmailInput.SendKeys(email);
    public void PswdWrite(string pswd) => PswdInput.SendKeys(pswd);
    public void RememberMe(bool remember) => RememberMeBox.CheckTheBox(remember);

    // Методы получения свойств
    public string GetErrorLabelText() => ErrorLabel.Text.Trim();
}
