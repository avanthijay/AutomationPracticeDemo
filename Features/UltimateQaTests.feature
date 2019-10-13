Feature: UltimateQaLogin



@ElementValidation
Scenario Outline: Validate Search box functionality
	Given I am on the landing page
	When I enter '<SearchText>'
	Then I should be navigated to the search '<Result>' page

	Examples: 
	| SearchText | Result |
	| Big        | Big    |
	| #$@%!^&    | No Results Found |


@ElementValidation
Scenario: Validate Contents Widget
	Given I am on the landing page
	When I click on Content hide 
	Then Contents should be hidden
	When I click on COntent show
	Then COntent should be shown
	
@ElementValidation
@EndToEnd
Scenario: Login in to UltimateQA 
	Given I am on the landing page
	And I select to Login automation link
	When I enter valid username and password
	Then I should see the Dashboard