Feature: Submit Investec Form

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

#    Scenario: Submit button should be disabled with blank fields
#        Given I navigate to the Investec form page
#        When I scroll to the submit botton on the form 
#        Then the submit button should be disabled