Feature: EventQueue

Background: 
	Given an EventQueue

Scenario: AddAsync(events)
	Given a collection of events
	When AddAsync(events) is called
	Then the events are added to the queue

Scenario: ProcessAsync()
	Given a collection of events
	And the events are added to the queue
	And an event handler has been registered
	When ProcessAsync() is called
	Then EventStore.SaveEvents(events) is called
	And registered event handler is called