Feature: GameResults
	In order to know how I did during my game attempt
	As a user
	I want to be informed about the details of my game

@mytag
Scenario: Number of rovers
	Given I have entered 3 rovers as input
	When I press the submit button
	Then the result should display that I entered 3 rovers

Scenario: Cumulative step count for one rover
	Given I have entered the following inputs
	| Matrix | InitialPosition | Command |
	| 5 5    | 1 1 N           | MM       |
	| 5 5    | 1 1 E           | MMRR     |
	| 5 5    | 1 1 S           | MRRMMM   |
	| 5 5    | 1 1 W           | RLRM     |
	When I press the submit button
	Then the cumulative step count result for one rover should be as following on the output box
	| stepCount |
	| 2  |
	| 2  |
	| 4  |
	| 1  |

Scenario: Cumulative step count for 2 rovers
	Given I have entered the following inputs
	| Matrix | InitialPosition1 | Command1 | InitialPosition2 | Command2 |
	| 5 5    | 1 1 N            | MM       | 0 0 N            | M        |
	| 5 5    | 1 1 E            | MMRR     | 3 3 E            | RRM      |
	| 5 5    | 1 1 S            | MRRMMM   | 2 2 W            | MM       |
	| 5 5    | 1 1 W            | RLRM     | 5 5 S            | MRM      |
	When I press the submit button
	Then the cumulative step count result for one rover should be as following on the output box
	| stepCount |
	| 3  |
	| 3  |
	| 6  |
	| 3  |