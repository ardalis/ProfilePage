Feature: ProfileLevel
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Get Profile Level
	Given An instance of ProfileService
	When I request a level for 500 points
	Then the result should be level 1
