Feature: DemoTest

A short summary of the feature
As a tester i want to demo api in current framework


@api
Scenario: Verify that api returns api of the list of books
	Given User pass base url and endpoints
	When User Request a Get method
	Then User Verify the Response
