﻿using AutomationPracticeDemo.Pages;
using TechTalk.SpecFlow;

namespace AutomationPracticeDemo.StepDefinitions
{
    [Binding]
    public class SummerDressesFeatureSteps : BasePage
    {
        private readonly SummerDressesPage _summerDressPage;
        private readonly ShoppingCartPage _shoppingCartPage;

        public SummerDressesFeatureSteps()
        {
            _summerDressPage  = new SummerDressesPage();
            _shoppingCartPage = new ShoppingCartPage();
        }

        [Given(@"I am on the HomePage")]
        public void GivenIAmOnTheHomePage()
        {
            _summerDressPage.VisitPage();
        }
        
        [Given(@"I am on the Women Summer Dresses page")]
        public void GivenIAmOnTheWomenSummerDressesPage()
        {
            GivenIAmOnTheHomePage();
            _summerDressPage.GotoDressesTab();
        }
        
        [Given(@"I have added a dress to cart")]
        public void GivenIHaveAddedADressToCart()
        {
            _summerDressPage.AddDressToCart();
            _shoppingCartPage.CheckSummary();
        }

        [When(@"I Sign In and proceed to Checkout")]
        public void WhenISignInAndProceedToCheckout()
        {
            _shoppingCartPage.SignIn();
        }

        [When(@"I choose '(.*)'  proceed to end")]
        public void WhenIChooseProceedToEnd(string paymentOption)
        {
            _shoppingCartPage.AddAddressDetails();
            _shoppingCartPage.AddShippingDetails();
            _shoppingCartPage.MakePayment(paymentOption);
            _shoppingCartPage.VerifyConfirmOrderPage(paymentOption);
            _shoppingCartPage.ConfirmOrder();
        }

        [Then(@"I should see the Order Confirmation according to the '(.*)'")]
        public void ThenIShouldSeeTheOrderConfirmationAccordingToThe(string paymentOption)
        {
            _shoppingCartPage.VerifyOrderResultPage(paymentOption);
        }



    }
}
