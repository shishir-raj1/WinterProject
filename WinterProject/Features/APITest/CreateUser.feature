Feature: CreateUser

A short summary of the feature
As A tester I want to make a post request
so can i create a new user in the database/server

@Api
Scenario: Verify I Can Create a User through the API
	Given User pass a base url and enpoint
	When User make a post request
	Then User verify the request got created
