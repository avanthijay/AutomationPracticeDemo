using System;
using System.Configuration;
using AutomationPracticeDemo.PageFactoryObjects;

namespace AutomationPracticeDemo.Pages
{
    public class SummerDressesPage : BasePage
    {
        public SummerDressesPage()
        {
            BaseUrl = new Uri(ConfigurationManager.AppSettings["BaseURL"] ?? "http://automationpractice.com");
        }

        public void GotoDressesTab()
        {
            var pageFactory = new SummerDressesPageFactory(WebDriver);

            WaitUntilPageReady();
            pageFactory.DressesTab.Click();
            pageFactory.SummerDressesTab.Click();
        }

    }
}
