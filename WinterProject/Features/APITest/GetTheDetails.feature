Feature: GetTheDetails

A short summary of the feature

@Api
Scenario: verify the json details
	Given User fetch base url and endpoint
	When User pass the get request
	Then User verify the json
