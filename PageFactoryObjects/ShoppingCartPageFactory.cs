using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationPracticeDemo.PageFactoryObjects
{
    public class ShoppingCartPageFactory
    {
        public ShoppingCartPageFactory(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "standard-checkout")]
        public IWebElement ButtonProceedToCheckoutSummary { get; set; }

        [FindsBy (How = How.Id, Using= "email")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy (How = How.Id, Using = "SubmitLogin")]
        public IWebElement ButtonSIgnIn { get; set; }

        [FindsBy(How = How.Name, Using = "processAddress")]
        public IWebElement ButtonProceedToShipping { get; set; }

        [FindsBy (How = How.Id, Using= "cgv")]
        public IWebElement CheckBoxTermsOfService { get; set; }

        [FindsBy(How = How.Name, Using = "processCarrier")]
        public IWebElement ButtonProceedToPayment { get; set; }

        [FindsBy (How = How.ClassName, Using= "bankwire")]
        public IWebElement LinkBankWire { get; set; }

        [FindsBy(How = How.ClassName, Using = "cheque")]
        public IWebElement LinkCheque { get; set; }

        [FindsBy(How = How.ClassName, Using = "page-subheading")]
        public IWebElement SubHeadingOrderSummary { get; set; }

        [FindsBy (How=How.Id, Using = "cart_navigation")]
        public IWebElement CartNavigation { get; set; }

        [FindsBy(How = How.ClassName, Using = "order-confirmation")]
        public IWebElement SubHeadingOrderConfirmation { get; set; }

        [FindsBy(How = How.ClassName, Using = "cheque-indent")]
        public IWebElement SubHeadingOrderConfirmationByWire { get; set; }

        [FindsBy(How = How.ClassName, Using = "alert-success")]
        public IWebElement AlertSuccess { get; set; }

        public IWebElement GetBtnConfirmOrder()
        {
            return CartNavigation.FindElement(By.ClassName("button-medium"));
        }
        public IWebElement GetOrderResultsTextByCheque()
        {
            return SubHeadingOrderConfirmation.FindElement(By.ClassName("page-subheading"));
        }

    }
}
