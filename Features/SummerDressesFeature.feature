Feature: SummerDressesFeature

@SmokeTest
@BasicFlow
Scenario Outline: Summer Dress purchase
	Given I am on the HomePage
	And I am on the Women Summer Dresses page
	And I have added a dress to cart
	When I Sign In and proceed to Checkout  
	And I choose '<PaymentOption>'  proceed to end
	Then I should see the Order Confirmation according to the '<PaymentOption>'

	Examples: 
	| PaymentOption |
	| Wire          |
	| cheque         |