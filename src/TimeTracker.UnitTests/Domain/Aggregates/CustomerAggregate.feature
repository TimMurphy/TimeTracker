Feature: CustomerAggregate

Scenario: Create customer
	When I send a CreateCustomer command
	Then CustomerAggregate is created
	And CustomerView is created