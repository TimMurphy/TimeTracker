Feature: CommandBus

Scenario: SendAsync
	When SendAsync(ICommand command) is called
	Then the command is processed by a registered command handler
	And the events returned by the command handler are added to the event queue
