using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace lab6
{
    public class Class1
    {
        IWebDriver webDriver = new ChromeDriver();

        [TestCase]
        public void title()
        {
            webDriver.Url = "https://www.youtube.com";
            Assert.AreEqual("YouTube", webDriver.Title);
            //webDriver.Close();
        }

        [TestCase]
        public void string_test()
        {
            webDriver.Url = "https://www.youtube.com";
            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"search\"]"));
            search.SendKeys("BTS-Boy with luv");

            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath("//*[@id=\"search-icon-legacy\"]"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            //если элемент стал видим, получение ссылки и эмуляция клика //*[@id="search-icon-legacy"]
            IWebElement button =
             webDriver.FindElement(By.XPath("//*[@id=\"search-icon-legacy\"]"));
            button.Click();

        
        }

        [TearDown]
        public void testend()
        {
            //webDriver.Quit();
        }
    }
}
