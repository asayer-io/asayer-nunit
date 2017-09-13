using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace asayer_nunit
{
    class Test : AsayerNUnitTest
    {

        [Test]
        public void ProductFeatures()
        {
            driver.Navigate().GoToUrl("http://www.asayer.io");
            System.Threading.Thread.Sleep(5000);
            IWebElement videoButton = driver.FindElement(By.Id("wistia_14.thumb_container"));
            System.Threading.Thread.Sleep(5000);
            videoButton.Click();
            System.Threading.Thread.Sleep(5000);
            IWebElement video = driver.FindElement(By.Id("wistia_simple_video_34"));
            Assert.IsTrue(video.Displayed);
            Assert.AreEqual("QA-as-a-Service | Asayer", driver.Title);
        }
    }
}
