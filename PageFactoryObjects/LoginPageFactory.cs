using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationPracticeDemo.PageFactoryObjects
{
    public class LoginPageFactory
    {
        public LoginPageFactory(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "user[email]")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "user[password]")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "g-recaptcha")]
        public IWebElement ButtonSignIn { get; set; }

        [FindsBy(How = How.Id, Using = "user[remember_me]")]
        public IWebElement RememberMe { get; set; }


    }
}
