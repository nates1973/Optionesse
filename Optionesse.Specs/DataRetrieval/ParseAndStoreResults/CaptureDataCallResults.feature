Feature: CaptureDataCallResults
	I want to capture the results of a call to the web service
	So that I can record daily trade data for analysis

Scenario: Capture Data Call Results
	Given I have a properly formatted call to the web service
	When I execute the call
	Then I should get a properly-formatted result

Scenario: Handle Web Service Outage
	Given I have a properly formatted call to the web service
		But The web service is unavailable
	When I execute the call
	Then I should get an empty result
		And the result status should indicate a service outage

