Feature: ErrorMessages
	In order to know about the errors in my input
	As a user
	I want to be told the a user friendly error message

@mytag
Scenario: When you command a rover out of given matrix you get a specific error message
	Given I have entered the following inputs
	| Matrix | InitialPosition | Command |
	| 1 1    | 1 1 N           | MM      |
	| 5 5    | 4 4 E           | MMM     |
	| 5 5    | 2 2 S           | MMM    |
	| 5 5    | 0 0 W           | MMMM   |
	When I press the submit button
	Then the result should be out of terrain error


Scenario: When you command a rover with an invalid input you get a specific error message
	Given I have entered the following inputs
	| Matrix | InitialPosition | Command |
	| 1 1    | X 1 N           | MM      |
	| 5 X    | 4 4 E           | MMM     |
	| 5      | 2 2 S           | MMM    |
	| 5 5    | 0 0 W           | MMM?   |
	When I press the submit button
	Then the result should be the input parser error

Scenario: When you enter an initial maxtix not bigger than 100 X 100 you get a specific error message
	Given I have entered matrix as 100 100
	When I press submit button
	Then I do not get an error message

Scenario: When you enter an initial maxtix bigger than 100 X 100 you get a specific error message
	Given I have entered matrix as 101 102
	When I press submit button
	Then I the result should be matrix limit exceeded error

Scenario: When you enter more than 5 rovers you get a specific error message
	Given I have entered more than 5 rovers
	When I press submit button
	Then the result should be rover limit exceeded error

Scenario: When you intersect with your trail you get a specific error message
	Given I have entered the rover MATRIX as 5 5
	And I have entered the initial position as '0 0 E'
	And I have entered the command as 'MMRRM'
	When I press submit button
	Then the result should be trail hit error


