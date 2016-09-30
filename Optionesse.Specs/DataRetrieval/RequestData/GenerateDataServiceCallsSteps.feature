Feature: Generate Data Service Calls
	I want to generate a call to a Stock Price Data Web Service
	So that I can retrieve the price data covered by that range for analysis


Scenario: Generate Data Service Call For Previous Trading Day
	Given I have entered the following symbols into the configuration
		| Symbol |
		| AAPL   |
		| FLWS   |
		| MMM    |
		| AHC    |
		| ANF    |
		And I have configured previous day data mode
	When I run the data retrieval process
	Then a properly formatted data call is generated for those parameters

Scenario: Generate Data Service Call For Security History
	Given I have entered security symbol 'AAPL' into the configuration
		And I have configured historical data mode
	When I run the data retrieval process
	Then a properly formatted data call is generated for those parameters

Scenario: Data Service Unavailable

