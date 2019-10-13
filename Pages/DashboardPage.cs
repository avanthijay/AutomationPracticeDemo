using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.PageFactoryObjects;
using NUnit.Framework;

namespace AutomationPracticeDemo.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly DashboardPageFactory _pageFactory;

        public DashboardPage()
        {
            _pageFactory = new DashboardPageFactory(WebDriver);
        }

        public void VerifyPage()
        {
            Assert.IsTrue(_pageFactory.PageHeader.Text.Contains("UltimateQA"));
        }
    }
}
