using System;
using System.Configuration;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Pages
{
    public abstract class BasePage
    {
        public const int DefaultRetryAttempts = 10;
        public Uri BaseUrl = new Uri(ConfigurationManager.AppSettings["BaseURL"] ?? "http://automationpractice.com");
        public static IWebDriver WebDriver;

        /// <summary>
        /// Visit page
        /// </summary>
        /// <param name="urlAppender"></param>
        /// <returns></returns>
        public bool VisitPage(string urlAppender = "")
        {
            try
            {
                Uri url = BaseUrl;
                if (!string.IsNullOrWhiteSpace(urlAppender))
                {
                    url = new Uri(url + urlAppender);
                }
                WebDriver.Navigate().GoToUrl(url);
                WaitUntilPageReady();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if element displayed. Try default wait attempts and wait until it appears.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                for (var i = 0; i < DefaultRetryAttempts; i++)
                {
                    if (element.Displayed)
                    {
                        return true;
                    }

                    WaitUntilPageReady();
                }

                Assert.Fail("Element not displayed");
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Wait until page ready. This used when dynamic pages and check all components are loaded.
        /// </summary>
        public static void WaitUntilPageReady()
        {
            try
            {
                long numBusyItems = 0;
                do
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor) WebDriver;
                    String documentStatus = (String) js.ExecuteScript("return document.readyState;");
                    var activeJqueryCount = Convert.ToInt16(js.ExecuteScript("return jQuery.active"));
                    var animationCount = Convert.ToInt16(js.ExecuteScript("return $(\":animated\").length;"));
                    var documentState = Convert.ToInt16(((documentStatus.Equals("complete")) ? 0 : 1));
                    numBusyItems = documentState + activeJqueryCount + animationCount;

                    Thread.Sleep(500);
                } while (numBusyItems > 1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
