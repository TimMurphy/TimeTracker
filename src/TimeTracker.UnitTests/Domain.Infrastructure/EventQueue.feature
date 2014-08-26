Feature: EventQueue

Background: 
	Given an EventQueue

Scenario: AddAsync(events)
	Given a collection of events
	When AddAsync(events) is called
	Then the events are added to the queue