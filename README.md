#SpecFlow BDD Automation Framework

This is a UI test automation framework using **C#**, **SpecFlow**, **Cucumber**, and **Allure Reports** to validate a New User Form on the [Investec Quality Assurance Page](https://www.investec.com/en_za/qa/secondary.html).

---

## 🧰 Tech Stack

- DotNet 8
- Microsoft.NET.Test.Sdk" Version="17.8.0"
- Selenium.WebDriver" Version="4.34.0
- xunit" Version="2.5.3"
- xunit.runner.visualstudio" Version="2.5.3"
- SpecFlow" Version="3.9.8"
- SpecFlow.xUnit" Version="3.9.8"
- Selenium.Support" Version="4.34.0"
- Cucumber (Gherkin BDD)
- Allure Reporting
- Selenium.WebDriver.ChromeDriver" Version="138.0.7204.18300
- Rider IDE

---

## 📦 Installation Instructions

### 1. Prerequisites

- [Notnet 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed and configured in system `PATH`
- SpecFlow for  CLI installation and setu
- Internet connection to download SpecFlow plugins

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/ovoke-o/SpecFlowWebAutomation.git
cd SpecFlowWebAutomation
```

### 2. Install Playwright CLI & Browsers

```bash
dotnet add package SpecFlow
dotnet add package SpecFlow.xUnit
dotnet add package SpecFlow.Tools.MsBuild.Generation
dotnet add package Microsoft.NET.Test.Sdk
```

---

## 🧪 Running Tests

### Run All Tests via xUnit

```bash
dotnet test
```

---

## 🗂 Project Structure

```

SpecFlowWebAutomation
 ├─ Drivers/
 │   └─ WebDriverFactory.cs
 ├─ Pages/                                    # Page Object classes
 │   ├─ InvestecFormPage.cs
 ├─ Steps/                                    # Step Definitions for Cucumber
 │   └─ SubmitInvestecFormSteps.cs
 ├─ Hooks/                                    # Hooks for setup/teardown                                                                                                                                                              
 │   └─ TestHooks.cs
 ├─ Features/                                 # Gherkin .feature files
 │   └─ SubmitInvestecForm.feature                  
 ├─ Utilities/                                # Specflow, Screenshot & re                                                                                                                                                            
 │   └─ HelperClass.cs
 └─ SpecFlowWebAutomation.csproj

```

---

## 🧾 Example Scenario

```gherkin
   Scenario Outline: Fill and submit Investec form successfully
        Given I navigate to the Investec form page
        When I fill in the form with the following details "<Name>", "<Surname>", "<BusinessName>", "<BusinessRegistrationNumber>", "<Website>", "<EmailAddress>", "<PhoneNumber>", "<InvestecService>", "<NumberOfAssets>", "<AnnualTurnover>", "<WorkingCapital>", "<AssetFinance>", "<CompanyTrading3OrMoreYears>", "<financialStatementsReady>"
        Then the submit button should be enabled
        When I click the submit button
        Then a success message should be displayed
        Then I take a screenshot of the success screen

        Examples:
          | Name  | Surname | BusinessName | BusinessRegistrationNumber | Website      | EmailAddress            | PhoneNumber | InvestecService  | NumberOfAssets | AnnualTurnover | WorkingCapital | AssetFinance | CompanyTrading3OrMoreYears | financialStatementsReady |
          | John  | Doe     | ABC Corp     | AB1234                     | www.test.com | john.doe@example.com    | 1234567890  | Trade and import | 0-15           | 0 - 10mil      | 0 - 5mil       | 1 - 5mil     | Yes                        | Yes                      |
          | Alice | Smith   | XYZ Ltd      | XY9876                     | www.test.com | alice.smith@example.com | 0987654321  | Trade and import | 0-15           | 0 - 10mil      | 0 - 5mil       | 1 - 5mil     | Yes                        | Yes                      |

```
