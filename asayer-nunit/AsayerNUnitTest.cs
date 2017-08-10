using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;
using System.Configuration;

namespace asayer_nunit
{
    class AsayerNUnitTest
    {
        protected IWebDriver driver;

        public AsayerNUnitTest()
        { }

        [SetUp]
        public void Init()
        {
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities") as NameValueCollection;

            DesiredCapabilities capability = new DesiredCapabilities();

            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }

            string hub = ConfigurationManager.AppSettings.Get("server");
            string name = ConfigurationManager.AppSettings.Get("name");
            string apikey = ConfigurationManager.AppSettings.Get("apikey");
            
            capability.SetCapability("apikey", apikey);
            capability.SetCapability("name", name);
            
            var timeOut = TimeSpan.FromMinutes(1);

            driver = new RemoteWebDriver(new Uri(hub), capability, timeOut);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();

        }
    }
}
