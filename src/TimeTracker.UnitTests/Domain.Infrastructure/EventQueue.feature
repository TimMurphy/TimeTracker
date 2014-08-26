Feature: EventQueue

Background: 
	Given an EventQueue

Scenario: AddAsync(events)
	Given I a collection of events
	When I call AddAsync(events)
	Then the events are added to the queue