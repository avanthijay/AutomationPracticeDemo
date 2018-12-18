using AutomationPracticeDemo.PageFactoryObjects;

namespace AutomationPracticeDemo.Pages
{
    public class SummerDressesPage : BasePage
    {
        readonly SummerDressesPageFactory _pageFactory;
        public SummerDressesPage()
        {
            _pageFactory = new SummerDressesPageFactory(WebDriver);
        }

        /// <summary>
        /// Go to dresses tab.
        /// </summary>
        public void GotoDressesTab()
        {
            WaitUntilPageReady();
            _pageFactory.DressesTab.Click();
            _pageFactory.SummerDressesTab.Click();
        }

        /// <summary>
        /// Query product list and add first product item to the cart.
        /// </summary>
        public void AddDressToCart()
        {
            var firstProductItem = _pageFactory.GetProductItem(0);
            var buttonAddToCart = _pageFactory.GetBtnAddToCart(firstProductItem);
            buttonAddToCart.Click();

            if(IsElementDisplayed(_pageFactory.GetBtnProceedCheckout()))
                _pageFactory.GetBtnProceedCheckout().Click();
        }

    }
}
