Feature: CommandBus

Scenario: RegisterCommandHandler(commandHandler) - Command handler has not been registered
	When RegisterCommandHandler(commandHandler) is called
	Then the command handler is added to list of command handlers

Scenario: RegisterCommandHandler(commandHandler) - Command handler has been registered
	Given command handler has been registered
	When RegisterCommandHandler(commandHandler) is called for a second time
	Then DuplicateCommandHandlerException is thrown
	
Scenario: SendAsync(command) - Send command that has registered handler
	Given command handler has been registered
	When SendAsync(command) is called
	Then the command is processed by registered command handler
	And the events returned by the command handler are added to the event queue

Scenario: SendAsync(command) - Send command that does not have registered handler
	When SendAsync(command) is called
	Then CommandHandlerNotFoundException is thrown