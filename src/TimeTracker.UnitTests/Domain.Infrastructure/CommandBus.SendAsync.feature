Feature: CommandBus.SendAsync

Scenario: Send command that has registered handler
	Given command handler has been registered
	When SendAsync(command) is called
	Then the command is processed by registered command handler
	And the events returned by the command handler are added to the event queue

Scenario: Send command that does not have registered handler
	When SendAsync(command) is called
	Then CommandHandlerNotFoundException is thrown