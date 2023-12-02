Feature: PARALLEL
@NUll
Scenario Outline: Open something else
	  Given Multiple browsers at same time "<Browser>"

	    Examples:
      | Browser  |
      | CHROME   |


@Null
Scenario Outline: Open something else again
	  Given Multiple browsers at same time "<Browser>"

	    Examples:
      | Browser  |
      | CHROME   |
