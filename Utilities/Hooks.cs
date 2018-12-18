using System;
using System.Configuration;
using AutomationPracticeDemo.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AutomationPracticeDemo.Utilities
{
    [Binding]
    public class Hooks: BasePage
    {
        private static WebDriverWait _driverWait = null;

        [BeforeScenario]
        public void BeforeScenario()
        {
            switch (ConfigurationManager.AppSettings["WebBrowser"].ToLower())
            {
                case "internetexplorer":
                    WebDriver = new InternetExplorerDriver();
                    break;
                default:
                    WebDriver = new ChromeDriver();
                    break;
            }

            _driverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.Quit();
        }

    }
}
