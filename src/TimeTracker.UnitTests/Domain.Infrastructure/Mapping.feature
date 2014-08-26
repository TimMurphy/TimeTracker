Feature: Mapping

Scenario: MapTo - from.Map<To>()
	Given from object has public properties
	And to class has public constructor with zero arguments
	And to class has public constructor with one or more arguments
	When I call from.MapTo<To>
	Then to object is created via public constructor with arguments
