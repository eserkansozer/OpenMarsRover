Feature: Moving Rover
	In order to see the progress of the rover based on my commands
	As a user
	I want to see ve shown the final position of the rover

@mytag
Scenario: When you command N it moves north
	Given I have entered the rover MATRIX as '1 1'
	And I have entered the initial position as '0 0 N'
	And I have entered the command as 'M'
	When I press submit button
	Then the result should be '0 1 N' on the screen

Scenario: When you command E it moves east
	Given I have entered the rover MATRIX as '1 1'
	And I have entered the initial position as '0 0 E'
	And I have entered the command as 'M'
	When I press submit button
	Then the result should be '1 0 E' on the screen

Scenario: When you command E it moves south
	Given I have entered the rover MATRIX as '1 1'
	And I have entered the initial position as '1 1 S'
	And I have entered the command as 'M'
	When I press submit button
	Then the result should be '1 0 S' on the screen