Feature: NaukariLogin

A short summary of the feature
login to Naukari Page

@login
Scenario Outline: Login to Naukari website
	Given User enter "<Url>" and open the login Page
	When User click on Login Button
	And User enter the credential "<Username>" and "<Password>" and click on Login Button
	Then User Login Successfully and verify the "<Title>" of the page
	Examples: 
	| S.No | Url                     | Username                 | Password    | Title																	  |
	| 1    | https://www.naukri.com/ | username@gmail.com | password | Jobs - Recruitment - Job Search - Employment - Job Vacancies - Naukri.com |