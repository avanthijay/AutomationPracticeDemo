using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.Data;
using AutomationPracticeDemo.PageFactoryObjects;

namespace AutomationPracticeDemo.Pages
{
    public class LoginPage : BasePage
    {
        private readonly LoginPageFactory _pageFactory;

        public LoginPage()
        {
            _pageFactory = new LoginPageFactory(WebDriver);
        }

        public void LogIn()
        {
            _pageFactory.Email.SendKeys(ExcelDataProvider.ExternalData.GetValue("SignInPage", "B2"));
            _pageFactory.Password.SendKeys(ExcelDataProvider.ExternalData.GetValue("SignInPage","B3"));

            _pageFactory.ButtonSignIn.Click();
        }

    }
}
