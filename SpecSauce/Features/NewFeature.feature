Feature: New Feature wile

@AMIT
Scenario Outline: Run New 
	 Given Launch the browser "<Browser>"
	 When Open the google
	 When Input values 
	 When Perform Login
	 Then Close the Browser


	  Examples:
	| Browser |
	| CHROME  |