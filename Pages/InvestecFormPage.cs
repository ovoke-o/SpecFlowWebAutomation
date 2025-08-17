using InvestecAutomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InvestecAutomation.Pages;

public class InvestecFormPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public InvestecFormPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Navigate()
    {
        _driver.Navigate().GoToUrl("https://www.investec.com/en_za/qa/secondary.html");
    }

    private readonly By _firstNameLocator = By.Name("firstname");
    public IWebElement FirstNameTxt => _driver.FindElement(_firstNameLocator);

    private readonly By _surNameLocator = By.Name("surname");
    public IWebElement SurNameTxt => _driver.FindElement(_surNameLocator);

    private readonly By _businessNameLocator = By.Name("businessname");
    public IWebElement BusinessNameLocatorTxt => _driver.FindElement(_businessNameLocator);

    private readonly By _businessRegistrationLocator = By.Name("BusinessRegistration");
    public IWebElement BusinessRegistrationTxt => _driver.FindElement(_businessRegistrationLocator);

    private readonly By _websiteLocator = By.Name("website");
    public IWebElement WebsiteTxt => _driver.FindElement(_websiteLocator);

    private readonly By _emailLocator = By.Name("email");
    public IWebElement EmailTxt => _driver.FindElement(_emailLocator);

    private readonly By _phoneLocator = By.Name("phone");
    public IWebElement PhoneTxt => _driver.FindElement(_phoneLocator);

    private readonly By _otherInfoFinance = By.Name("otherinfofinance");
    public IWebElement OtherInfoFinanceTxt => _driver.FindElement(_otherInfoFinance);

    private readonly By _annualTurnover = By.Name("annualturnover");
    private readonly By _quantumOfFundingWorkingCapital = By.Name("quantumoffundingworkingcapital");
    private readonly By _quantumOfFundingAssetFinance = By.Name("quantumoffundingassetfinance");
    private readonly By _submit = By.XPath("//button[contains(text(), 'Submit')]");

    public void FillForm(string name, string surname, string businessName, string registrationNumber, string website,
        string email, string phone, string investecService, string assets, string turnover, string workingCapital,
        string assetFinance, string tradingYears, string financialStatementsReady)
    {
        FirstNameTxt.SendKeys(name);
        SurNameTxt.SendKeys(surname);
        BusinessNameLocatorTxt.SendKeys(businessName);
        BusinessRegistrationTxt.SendKeys(registrationNumber);
        WebsiteTxt.SendKeys(website);
        EmailTxt.SendKeys(email);
        PhoneTxt.SendKeys(phone);
        HelperClass.SelectFromDropdown(_driver, By.Name("natureoffinance"), "text", investecService);
        OtherInfoFinanceTxt.SendKeys("Other information about finance");
        HelperClass.SelectFleetAssetRadioOption(_driver, assets);
        HelperClass.SelectFromDropdown(_driver, _annualTurnover, "text", turnover);
        HelperClass.SelectFromDropdown(_driver, _quantumOfFundingWorkingCapital, "text", workingCapital);
        HelperClass.SelectFromDropdown(_driver, _quantumOfFundingAssetFinance, "text", assetFinance);
        HelperClass.SelectFleetAssetRadioOption(_driver, tradingYears);
        HelperClass.ClickSecondRadioByLabelText(_driver, financialStatementsReady);
    }

    public void ClickSubmitButton()
    {
        HelperClass.ClickButton(_driver, _submit);
    }
}