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
    }
}
