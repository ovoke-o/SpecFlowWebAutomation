using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowWebAutomation.Drivers;

public class WebDriverFactory
{
    public static IWebDriver CreateChromeDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        return new ChromeDriver(options);
    }
}