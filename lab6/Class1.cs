using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        [TearDown]
        public void testend()
        {
            //webDriver.Quit();
        }
    }
}
