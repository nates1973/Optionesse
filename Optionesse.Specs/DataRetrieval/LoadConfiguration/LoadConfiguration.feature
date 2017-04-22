Feature: LoadConfiguration
	In order to properly connect to the web service
	I want to load the configuration from an external source

Scenario: Load Daily Trade Configuration
Given I have configured daily trades
	And I have entered the following symbols into the configuration
         | Symbol |
         | AAPL   |
         | GOOG   |
	And I have configured to not use date ranges
When I execute the call to the data source
Then the engine should prepare a daily request with the symbols included

Scenario: Load Historical Trade Configuration
Given I have configured historical trades
	And I have entered the following symbols into the configuration
         | Symbol |
         | AAPL   |
         | GOOG   |
	And I have configured to use date ranges
	And I have entered start date 1/1/2011
	And I have entered an end date 12/31/2016
When I execute the call to the data source
Then the engine should prepare a historical request for each of the symbols
	And the request should include the specified date ranges