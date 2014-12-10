Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered <num1> into the calculator
	And I have entered <num2> into the calculator
	When I press add
	Then the result should be <result> on the screen
	And the error message <shouldOrShouldNot> be shown
Examples:
	| num1 | num2 | result | shouldOrShouldNot |
	| 50   | 70   | 120    | should not        |
	| 60   | 70   | 110    | should            |
