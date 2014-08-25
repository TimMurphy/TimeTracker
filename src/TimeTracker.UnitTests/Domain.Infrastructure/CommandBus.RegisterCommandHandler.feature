Feature: CommandBus.RegisterCommandHandler

Scenario: Command handler has not been registered
	When RegisterCommandHandler(commandHandler) is called
	Then the command handler is added to list of command handlers

Scenario: Command handler has been registered
	Given command handler has been registered
	When RegisterCommandHandler(commandHandler) is called for a second time
	Then DuplicateCommandHandlerException is thrown