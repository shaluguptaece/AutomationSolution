Feature: EdwardScadaUIPTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Login scenario for invalid credentials
	Given I opened ADCENTRA url
	When I entered wrong <username> and <password> and clicked login button
	Then error message should display on login page.

	Examples: 
	|  username    | password |
    | testuser_1   | Test@123 |
    | administrator| test123  |
	| testuser_1   | toolkit  |

	               

