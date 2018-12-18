using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Pages
{
    public abstract class BasePage
    {
        public const int DefaultRetryAttempts = 10;
        public const int DefaultWaitSeconds = 3;
        public Uri BaseUrl { get; set; }
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
                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Find element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public IWebElement FindElement(By element)
        {
            for (var i = 0; i < DefaultRetryAttempts; i++)
            {
                var webElement = WebDriver.FindElement(element);
                if (webElement.Displayed)
                {
                    return webElement;
                }

                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            }

            Assert.Fail("Element not found");
            return null;

        }

        /// <summary>
        /// Check if element is present
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Check page title
        /// </summary>
        /// <param name="pageTitle"></param>
        /// <returns></returns>
        public bool CheckPageTitle(string pageTitle)
        {
            for (var i = 0; i < DefaultRetryAttempts; i++)
            {
                if (WebDriver.Title.Contains(pageTitle))
                {
                    return true;
                }

                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            }

            return false;
        }

        /// <summary>
        /// Check value in the page
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CheckValueInThePage(string value)
        {
            for (var i = 0; i < DefaultRetryAttempts; i++)
            {
                if (WebDriver.PageSource.Contains(value))
                {
                    return true;
                }

                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            }

            return false;
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
