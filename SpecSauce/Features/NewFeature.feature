Feature: New Feature wile

Scenario Outline: Run New 
	  Given Launch the browser "<Browser>"
	  When Open the google
	  Then Close the Browser

	  Examples:
	| Browser |
	| CHROME  |
	| EDGE    |