using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace asayer_nunit
{
    class MyTest : AsayerWebDriver
    {

        [Test]
        public void CheckProductPage()
        {
            driver.Navigate().GoToUrl("http://www.asayer.io");
            System.Threading.Thread.Sleep(2000);
            IWebElement productButton = driver.FindElement(By.CssSelector("a[href='product.html']"));
            System.Threading.Thread.Sleep(2000);
            productButton.Click();
            System.Threading.Thread.Sleep(2000);
            Assert.AreEqual("QA-as-a-Service | Asayer", driver.Title);
        }
    }
}
