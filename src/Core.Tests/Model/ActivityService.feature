Feature: ActivityService
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Log an Activity
	Given I have an instance of ActivityService
	And I have an instance of an Act
	When I log the activity
	Then the activity should be persisted
	And an ActLogged event should be fired

