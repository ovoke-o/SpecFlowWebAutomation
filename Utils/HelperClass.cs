using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace InvestecAutomation.Utils;

public static class HelperClass
{
    private static readonly string ScreenshotsDir = "Screenshots";

    public static void SelectFromDropdown(IWebDriver driver, By locator, string selectionType, string selectionValue)
    {
        var element = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv => drv.FindElement(locator));
        var selectElement = new SelectElement(element);

        switch (selectionType.ToLower())
        {
            case "text":
                selectElement.SelectByText(selectionValue);
                break;
            case "value":
                selectElement.SelectByValue(selectionValue);
                break;
            case "index":
                if (int.TryParse(selectionValue, out var index))
                    selectElement.SelectByIndex(index);
                else
                    throw new ArgumentException("Selection type is 'index' but the value is not a valid number.");
                break;
            default:
                throw new ArgumentException("Invalid selection type. Use 'text', 'value', or 'index'.");
        }
    }

    public static void SelectFleetAssetRadioOption(IWebDriver driver, string value)
    {
        var xpath = $"//label[contains(normalize-space(), '{value}')]";

        try
        {
            var radioLabel = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(drv => drv.FindElement(By.XPath(xpath)));

            radioLabel.Click();
        }
        catch (WebDriverTimeoutException)
        {
            throw new Exception($"Radio button with label '{value}' not found.");
        }
    }

    public static void ClickSecondRadioByLabelText(IWebDriver driver, string visibleText)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        var labels = wait.Until(driver =>
            driver.FindElements(By.XPath($"//label[contains(., '{visibleText}')]"))
        );

        if (labels.Count < 2)
            throw new Exception($"Less than two labels with text '{visibleText}' were found.");

        var secondLabel = labels[1];
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", secondLabel);
    }

    public static void SelectDropdown(IWebDriver driver, string elementId, string visibleText)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var dropdown = new SelectElement(wait.Until(ExpectedConditions.ElementIsVisible(By.Id(elementId))));
        dropdown.SelectByText(visibleText);
    }

    public static bool IsSubmitEnabled(IWebDriver driver)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var submitButton =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Submit')]")));

            Console.WriteLine("Submit button - Enabled: " + submitButton.Enabled);
            Console.WriteLine("Submit button - Displayed: " + submitButton.Displayed);
            Console.WriteLine("Submit button - Text: " + submitButton.Text);

            return submitButton.Enabled && submitButton.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Timeout: Submit button not clickable.");
            return false;
        }
    }

    public static void ClickButton(IWebDriver driver, By locator)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var submit = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        submit.Click();
    }
    
    public static bool IsSuccessMessageVisible(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        try
        {
            var successMessage = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//*[contains(normalize-space(text()), 'Thank you')]")));

            Console.WriteLine("Success message found. Displayed: " + successMessage.Displayed);
            return successMessage.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Timeout: Success message containing 'Thank you' was not visible within 10 seconds.");

            return false;
        }
    }


    public static void TakeScreenshot(IWebDriver driver, string name)
    {
        // Optional: save screenshot for debugging
        try
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //screenshot.SaveAsFile($"SuccessMessageNotFound_{timestamp}.png", ScreenshotImageFormat.Png);
            Console.WriteLine($"Screenshot saved: SuccessMessageNotFound_{timestamp}.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
        }
    }

    public static void DismissCookieBanner(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        try
        {
            var acceptButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button#onetrust-accept-btn-handler")));

            acceptButton.Click();

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.CssSelector(".onetrust-pc-dark-filter")));
        }
        catch (WebDriverTimeoutException)
        {
            // Banner not present
        }
    }

    public static void ScrollToBottom(IWebDriver driver)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
    }

    public static void ScrollToElement(IWebDriver driver, IWebElement element)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
}