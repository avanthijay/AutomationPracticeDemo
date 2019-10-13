using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationPracticeDemo.PageFactoryObjects
{
    public class DashboardPageFactory 
    {

        public DashboardPageFactory(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "img-responsive")]
        public IWebElement PageHeader { get; set; }

    }
}
