using OpenQA.Selenium;
using TechTalk.SpecFlow;
using InvestecAutomation.Drivers;

namespace InvestecAutomation.Hooks;

[Binding]
public class TestHooks
{
    private IWebDriver _driver;

    private readonly ScenarioContext _scenarioContext;
    private readonly FeatureContext _featureContext;

    public TestHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _driver = WebDriverFactory.CreateChromeDriver();

        // Register the driver for dependency injection
        _scenarioContext.Set(_driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        //_driver?.Quit();
    }
}