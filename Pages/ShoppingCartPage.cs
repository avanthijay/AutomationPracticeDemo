using AutomationPracticeDemo.Data;
using AutomationPracticeDemo.PageFactoryObjects;
using NUnit.Framework;

namespace AutomationPracticeDemo.Pages
{
    public class ShoppingCartPage : BasePage
    {
        readonly ShoppingCartPageFactory _pageFactory;

        public ShoppingCartPage()
        {
            _pageFactory = new ShoppingCartPageFactory(WebDriver);
        }

        /// <summary>
        /// Process summary page.
        /// </summary>
        public void CheckSummary()
        {
            _pageFactory.ButtonProceedToCheckoutSummary.Click();
        }

        /// <summary>
        /// Sign in to the system
        /// </summary>
        public void SignIn()
        {
            //Read data from Excel file.
            _pageFactory.EmailAddress.SendKeys(ExcelDataProvider.ExternalData.GetValue("SignInPage", "B2"));
            _pageFactory.Password.SendKeys(ExcelDataProvider.ExternalData.GetValue("SignInPage", "B3"));
            
            // Note: If Excel is not installed in the Test machine , Please Comment first two lines and uncomment below lines
            //_pageFactory.EmailAddress.SendKeys("pubuduhp@gmail.com");
            //_pageFactory.Password.SendKeys("Test@albany");
             
            _pageFactory.ButtonSIgnIn.Click();

        }

        /// <summary>
        /// Add pre populated address fields after signin
        /// </summary>
        public void AddAddressDetails()
        {
            _pageFactory.ButtonProceedToShipping.Click();
        }

        /// <summary>
        /// Add shipping details and accept terms and services.
        /// </summary>
        public void AddShippingDetails()
        {
            if (!_pageFactory.CheckBoxTermsOfService.Selected)
            {
                _pageFactory.CheckBoxTermsOfService.Click();
            }
            _pageFactory.ButtonProceedToPayment.Click();

        }

        /// <summary>
        /// Make payment using cheque or wire.
        /// </summary>
        /// <param name="paymentType"></param>
        public void MakePayment(string paymentType)
        {
            switch (paymentType.ToLower())
            {
                case "cheque":
                    _pageFactory.LinkCheque.Click();
                    break;
                case "wire":
                    _pageFactory.LinkBankWire.Click();
                    break;
                default:
                    _pageFactory.LinkCheque.Click();
                    break;
            }
        }

        /// <summary>
        /// Confirm the order.
        /// </summary>
        public void ConfirmOrder()
        {
            _pageFactory.GetBtnConfirmOrder().Click();
        }

        /// <summary>
        /// Verify confirm order page according to payment type (Cheque or wire)
        /// </summary>
        /// <param name="paymentType"></param>
        public void VerifyConfirmOrderPage(string paymentType)
        {
            switch (paymentType.ToLower())
            {
                case "cheque":
                    Assert.IsTrue(_pageFactory.SubHeadingOrderSummary.Text.Contains(ExcelDataProvider.ExternalData.GetValue("ConfirmOrderPage", "B2")));
                    break;
                case "wire":
                    Assert.IsTrue(_pageFactory.SubHeadingOrderSummary.Text.Contains(ExcelDataProvider.ExternalData.GetValue("ConfirmOrderPage", "B3")));
                    break;
                default:
                    Assert.IsTrue(_pageFactory.SubHeadingOrderSummary.Text.Contains(ExcelDataProvider.ExternalData.GetValue("ConfirmOrderPage", "B2")));
                    break;
            }
        }

        /// <summary>
        /// Verify order confirmation results page according to payment type.
        /// </summary>
        /// <param name="paymentType"></param>
        public void VerifyOrderResultPage(string paymentType)
        {
            switch (paymentType.ToLower())
            {
                case "cheque":
                    Assert.IsTrue(_pageFactory.GetOrderResultsTextByCheque().Text.Contains(ExcelDataProvider.ExternalData.GetValue("ResultPage", "B2")));
                    Assert.IsTrue(_pageFactory.AlertSuccess.Displayed);
                    break;
                case "wire":
                    Assert.IsTrue(
                        _pageFactory.SubHeadingOrderConfirmationByWire.Text.Contains(ExcelDataProvider.ExternalData.GetValue("ResultPage", "B3")));
                    break;
                default:
                    Assert.IsTrue(_pageFactory.SubHeadingOrderConfirmationByWire.Text.Contains(ExcelDataProvider.ExternalData.GetValue("ResultPage", "B3")));
                    break;
            }
        }

    }
}
