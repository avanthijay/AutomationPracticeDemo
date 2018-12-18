using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationPracticeDemo.PageFactoryObjects
{
    public class SummerDressesPageFactory
    {
        public SummerDressesPageFactory(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]/a")]
        public IWebElement DressesTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='categories_block_left']/div/ul/li[3]/a")]
        public IWebElement SummerDressesTab { get; set; }
    }
}
