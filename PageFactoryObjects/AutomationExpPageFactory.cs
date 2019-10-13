using  OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationPracticeDemo.PageFactoryObjects
{
    public class AutomationExpPageFactory
    {
        public AutomationExpPageFactory(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Login automation")]
        public IWebElement LinkLoginAutomation { get; set; }

        [FindsBy(How = How.Id, Using = "s")]
        public IWebElement  TextSearch { get; set; }

        [FindsBy(How = How.Id, Using = "searchsubmit")]
        public IWebElement ButtonSearch { get; set; }

        [FindsBy(How = How.ClassName, Using = "lwptoc_toggle_label")]
        public IWebElement ToggleHide { get; set; }

        [FindsBy(How = How.ClassName, Using = "lwptoc_toggle_label")]
        public IWebElement ToggleShow { get; set; }

        [FindsBy(How = How.ClassName, Using = "lwptoc_items")]
        public IWebElement ListContents { get; set; }

       

    }
}
