Feature: ProfileLevel
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Get Profile Level
	Given An instance of ProfileService
	When I request a level for 500 points
	Then the result should be level 1

	Given An instance of ProfileService
	When I request a level for 999 points
	Then the result should be level 1

	Given An instance of ProfileService
	When I request a level for 1000 points
	Then the result should be level 2

	Given An instance of ProfileService
	When I request a level for 2000 points
	Then the result should be level 3 
