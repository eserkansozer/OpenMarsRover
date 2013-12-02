Feature: Moves Table
	In order to see the progress of the rover based on my commands
	As a user
	I want to see ve shown the final position of the rover

@mytag
Scenario: When you command a rover with one move it moves one step in the correct direction
	Given I have entered the following inputs
	| Matrix | InitialPosition | Command |
	| 5 5    | 1 1 N           | M       |
	| 5 5    | 1 1 E           | M       |
	| 5 5    | 1 1 S           | M       |
	| 5 5    | 1 1 W           | M       |
	When I press the submit button
	Then the result should be as following on the output box
	| output |
	| 1 2 N  |
	| 2 1 E  |
	| 1 0 S  |
	| 0 1 W  |

Scenario: When you command a rover with multiple moves it moves few steps in the correct direction
	Given I have entered the following inputs
	| Matrix | InitialPosition | Command |
	| 5 5    | 1 1 N           | MM      |
	| 5 5    | 1 1 E           | MMM     |
	| 5 5    | 1 4 S           | MMM    |
	| 5 5    | 4 0 W           | MMMM   |
	When I press the submit button
	Then the result should be as following on the output box
	| output |
	| 1 3 N  |
	| 4 1 E  |
	| 1 1 S  |
	| 0 0 W  |
