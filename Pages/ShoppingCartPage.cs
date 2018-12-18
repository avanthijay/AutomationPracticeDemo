using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.PageFactoryObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationPracticeDemo.Pages
{
    public class ShoppingCartPage : BasePage
    {
        readonly ShoppingCartPageFactory _pageFactory;

        public ShoppingCartPage()
        {
            _pageFactory = new ShoppingCartPageFactory(WebDriver);
        }

        public void ProceedToSignIn()
        {
            _pageFactory.ButtonProceedToCheckoutSummary.Click();
        }
    }
}
