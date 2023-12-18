Feature: PARALLEL
@Parallel
Scenario Outline: Open something else
	  Given Multiple browsers at same time "<Browser>"

	    Examples:
      | Browser  |
      | CHROME   |
	  | AMIT     |
	  | SUNNY   |
