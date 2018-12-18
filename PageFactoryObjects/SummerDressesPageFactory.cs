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

        [FindsBy(How = How.ClassName, Using = "product_list")]
        public IWebElement ProductList { get; set; }

        [FindsBy(How = How.Id, Using = "layer_cart")]
        public IWebElement CartDetails { get; set; }

        public IWebElement GetProductItem(int id)
        {
          return  ProductList.FindElements(By.ClassName("product-container"))[id];
        }
        public IWebElement GetBtnAddToCart(IWebElement webElement)
        {
            return webElement.FindElement(By.ClassName("ajax_add_to_cart_button"));
        }
        public IWebElement GetBtnProceedCheckout()
        {
            return CartDetails.FindElement(By.ClassName("button-medium"));
        }
    }
}
