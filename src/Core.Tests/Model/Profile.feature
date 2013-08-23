Feature: Profile
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: New Profile
	Given A user has created a new public profile
	When The profile has been created
	Then The profile should begin with zero points

	Given A user has created a new public profile
	When The profile has been created
	Then The profile should have a unique identifier 

