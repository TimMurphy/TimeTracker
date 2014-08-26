Feature: CustomerAggregate

Background: 
	Given CreateCustomer command handler is registered with command bus

Scenario: Create customer
	When I send a CreateCustomer command
	Then CustomerAggregate is created
	And CustomerView is created