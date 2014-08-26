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
	Then events are added to the event store
	And registered event handler is called after the events have been added to the event store