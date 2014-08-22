Feature: HTTPS everywhere
	In order to protect my information
	As a user
	I want all pages to be served with HTTPS

Scenario: Visit HTTP url
	When I go to any HTTP url
	Then I am redirected to the equivalent HTTPS url
