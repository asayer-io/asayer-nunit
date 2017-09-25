using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;
using NUnit.Framework.Interfaces;

namespace asayer_nunit
{
    class AsayerNUnitTest
    {
        protected IWebDriver driver;
        protected string sessionId { get; set; }
        protected string apikey;

        public AsayerNUnitTest()
        { }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/settings") as NameValueCollection;
            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }

            string hub = ConfigurationManager.AppSettings.Get("server");
            string name = ConfigurationManager.AppSettings.Get("name");
            string apikey = ConfigurationManager.AppSettings.Get("apikey");
            string tunnelId = ConfigurationManager.AppSettings.Get("tunnelId");
            string build = ConfigurationManager.AppSettings.Get("build");

            capability.SetCapability("apikey", apikey);
            this.apikey = apikey;
            capability.SetCapability("name", name);

            if (build != null && build.Length > 0)
            {
                capability.SetCapability("build", build);
            }

            if (tunnelId != null && tunnelId.Length > 0)
            {
                capability.SetCapability("tunnelId", tunnelId);
            }

            NameValueCollection flags = ConfigurationManager.GetSection("capabilities/flags") as NameValueCollection;
            if (flags != null)
            {
                List<string> flagsList = new List<string>();
                foreach (string key in flags.AllKeys)
                {
                    flagsList.Add(key + (flags[key].ToLower() != "true" && flags[key] != "" ? "=" + flags[key] : ""));
                }
                if (flagsList.Count > 0) { capability.SetCapability("flags", flagsList); }
            }
            var timeOut = TimeSpan.FromMinutes(1);

            this.driver = new RemoteWebDriver(new Uri(hub), capability, timeOut);
            this.sessionId = ((RemoteWebDriver)driver).SessionId.ToString();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                this.markTest("Passed");
            }
            else
            {
                this.markTest("Failed");
            }

        }
        public void markTest(string state)
        {
            Console.WriteLine("sessionId: " + this.sessionId);
            if (this.sessionId != null && this.sessionId.Length > 0)
            {
                try
                {
                    string reqString = "{\"sessionID\":\"" + this.sessionId + "\", \"sessionStatus\":\"" + state + "\",\"apiKey\":\"" + this.apikey + "\"}";
                    byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                    Uri myUri = new Uri(string.Format("https://dashboard.asayer.io/sessions/mark_test"));
                    WebRequest myWebRequest = HttpWebRequest.Create(myUri);
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                    myWebRequest.ContentType = "application/json";
                    myWebRequest.Method = "POST";
                    myWebRequest.ContentLength = requestData.Length;
                    using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);

                    myWebRequest.GetResponse().Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    Console.WriteLine("Asayer: Something went wrong in marking the session state.");
                }
            }
            else
            {
                Console.WriteLine("Asayer: You have to initiate the AsayerDriver first in order to call markTestState.");
            }
        }
    }
}
