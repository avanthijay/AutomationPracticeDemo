﻿Feature: SummerDressesFeature
	

@SmokeTest
@BasicFlow
Scenario: Navigate to HomePage
	Given I am on the HomePage



@SmokeTest
@BasicFlow
Scenario Outline: Summer Dress purchase
	Given I am on the Women Summer Dresses page
	And I have added a dress to cart
	When I Sign In and proceed to Checkout  
	And I choose '<PaymentOption>'  proceed to end
	Then I should see the Order Confirmation

	Examples: 
	| PaymentOption |
	| Wire          |
	| Check         |