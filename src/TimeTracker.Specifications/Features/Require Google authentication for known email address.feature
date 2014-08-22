Feature: Require Google authentication for known email address
	In order to keep my time tracking secure
	As a known user
	I want all pages to be require my Google account

Scenario: Not authenticated
	Given I am not authenticated
	When I goto any url
	Then I am redirected to the sign in page

Scenario: Authenticated with known email address
	Given I am authenticated with a known email addresses
	When I goto any url
	Then I can view the requested page

Scenario: Authenticated with unknown email address
	Given I am authenticated with an unknown email addresses
	When I goto any url
	Then I am redirected to the sign in page
	And the sign in page says I am an unknown user

