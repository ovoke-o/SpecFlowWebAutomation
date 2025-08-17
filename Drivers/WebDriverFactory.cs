using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowWebAutomation.Drivers;

public class WebDriverFactory
{
    public static IWebDriver CreateChromeDriver()
    {
        var options = new ChromeOptions();

        // Always set a default window size so element locators behave consistently
        options.AddArgument("--window-size=1920,1080");

        // If running in GitHub Actions or another CI system, enable headless
        if (Environment.GetEnvironmentVariable("CI") == "true")
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }
        else
        {
            // Local dev: launch maximized with visible window
            options.AddArgument("--start-maximized");
        }

        return new ChromeDriver(options);
    }
}