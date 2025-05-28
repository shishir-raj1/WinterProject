Feature: Update Profile

A short summary of the feature
login to Naukari Page

@update
Scenario Outline: Login to Naukari website and update the profile
	Given User enter "<Url>" and open the login Page
	When User click on Login Button
	And User enter the credential "<Username>" and "<Password>" and click on Login Button
	And User Login Successfully and verify the "<Title>" of the page in Naukari
	And User click on view profile button
	And User click on edit profile button
	And User click on current salary box and enter the "<Text>" in the box
	Then User click on save button
	Examples: 
	| S.No | Url                     | Username                 | Password    | Title                                                                     | Text |
	| 1    | https://www.naukri.com/ | username@gmail.com | password | Jobs - Recruitment - Job Search - Employment - Job Vacancies - Naukri.com | 0    |
