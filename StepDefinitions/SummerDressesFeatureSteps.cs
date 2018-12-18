using AutomationPracticeDemo.Pages;
using TechTalk.SpecFlow;

namespace AutomationPracticeDemo.StepDefinitions
{
    [Binding]
    public class SummerDressesFeatureSteps : BasePage
    {
        private readonly SummerDressesPage _summerDressPage;

        public SummerDressesFeatureSteps()
        {
            _summerDressPage  = new SummerDressesPage();
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
            //Pending
        }

        [When(@"I Sign In and proceed to Checkout")]
        public void WhenISignInAndProceedToCheckout()
        {
            //Pending
        }

        [When(@"I choose '(.*)'  proceed to end")]
        public void WhenIChooseProceedToEnd(string p0)
        {
            //Pending
        }


        [Then(@"I should see the Order Confirmation")]
        public void ThenIShouldSeeTheOrderConfirmation()
        {
            //Pending
        }
    }
}
