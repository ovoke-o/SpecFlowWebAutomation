using SpecFlowWebAutomation.Pages;
using SpecFlowWebAutomation.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowWebAutomation.StepDefinitions;

[Binding]
public class SubmitInvestecFormSteps
{
    private readonly IWebDriver _driver;
    private readonly InvestecFormPage _formPage;

    public SubmitInvestecFormSteps(ScenarioContext scenarioContext)
    {
        _driver = scenarioContext.Get<IWebDriver>();
        _formPage = new InvestecFormPage(_driver);
    }

    [Given(@"I navigate to the Investec form page")]
    public void GivenINavigateToTheInvestecFormPage()
    {
        _formPage.Navigate();
        HelperClass.DismissCookieBanner(_driver);
    }
    
    [When(
        @"I fill in the form with the following details ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
    public void WhenIFillInTheFormWithTheFollowingDetails(
        string name, string surname, string businessName, string businessRegistrationNumber,
        string website, string emailAddress, string phoneNumber, string investecService,
        string numberOfAssets, string annualTurnover, string workingCapital, string assetFinance,
        string companyTrading3OrMoreYears, string financialStatementsReady)
    {
        // Fill in the form fields with provided details
        _formPage.FillForm(
            name, surname, businessName, businessRegistrationNumber,
            website, emailAddress, phoneNumber, investecService,
            numberOfAssets, annualTurnover, workingCapital, assetFinance,
            companyTrading3OrMoreYears, financialStatementsReady
        );
    }

    [Then(@"the submit button should be enabled")]
    public void ThenTheSubmitButtonShouldBeEnabled()
    {
        Assert.True(HelperClass.IsSubmitEnabled(_driver));
    }

    [Then(@"the submit button should be disabled")]
    public void ThenTheSubmitButtonShouldBeDisabled()
    {
        Assert.False(HelperClass.IsSubmitEnabled(_driver));
    }

    [When(@"I click the submit button")]
    public void WhenIClickTheSubmitButton()
    {
        _formPage.ClickSubmitButton();
    }

    [Then(@"a success message should be displayed")]
    public void ThenASuccessMessageShouldBeDisplayed()
    {
        Assert.True(HelperClass.IsSuccessMessageVisible(_driver));
    }

    [Then(@"I take a screenshot of the success screen")]
    public void ThenITakeAScreenshotOfTheSuccessScreen()
    {
        HelperClass.TakeScreenshot(_driver, "InvestecFormSuccess");
    }
    
}