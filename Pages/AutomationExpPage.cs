using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.PageFactoryObjects;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeDemo.Pages
{
    public class AutomationExpPage : BasePage
    {
        private readonly AutomationExpPageFactory _pageFactory;

        public AutomationExpPage()
        {
            _pageFactory = new AutomationExpPageFactory(WebDriver);
        }

        public void GoToAutomationLogin()
        {
            //WaitUntilPageReady();
            if (IsElementDisplayed(_pageFactory.LinkLoginAutomation))
                _pageFactory.LinkLoginAutomation.Click();
        }

        public void Search(string text)
        {
            if(IsElementDisplayed(_pageFactory.TextSearch))
                _pageFactory.TextSearch.SendKeys(text);
                _pageFactory.ButtonSearch.Click();
        }

        public void ActionContents(string action)
        {
          Thread.Sleep(500);
            if (action == _pageFactory.ToggleHide.Text.ToString())
            {
               
                _pageFactory.ToggleHide.Click();
            }
            else
            {
                
                    _pageFactory.ToggleShow.Click(); 
            }
        }

        public void VerifyContents(string result)
        {
            Thread.Sleep(500);
            if (result == "shown")
            {
               
                Assert.IsTrue(_pageFactory.ListContents.GetCssValue("display").ToString() == "block");
            }
            else
            { 
                Assert.IsTrue(_pageFactory.ListContents.GetCssValue("display").ToString() == "none");
            }
            

        }
    }
}
