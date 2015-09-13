using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using System.Threading;

namespace BBCWeather
{
    [TestClass]
    public class UnitTest1
    {

        IWebDriver driver;

        [TestInitialize]
        public void Initalise()
        {
            driver = new FirefoxDriver();
            System.Environment.SetEnvironmentVariable("restart.browser.each.scenario", "false");
        }
        
        public void GotoURL()
        {
            driver.Url = "http://www.bbc.co.uk/";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2000));
            driver.FindElement(By.XPath(".//*[@id='orb-nav-links']/ul/li[3]/a")).Click();
            String CurrentURL = driver.Url;
            Assert.AreEqual("http://www.bbc.co.uk/weather/", CurrentURL);
            driver.FindElement(By.XPath(".//*[@id='locator-form-search']")).SendKeys("Reading, Reading");
            driver.FindElement(By.XPath(".//*[@id='locator-form-submit']")).Click();
            String title = driver.Title;
            Debug.WriteLine("Weather Reading is opened");
            Assert.AreEqual("BBC Weather - Reading", title);
         }

        [TestMethod]
        public void FurtherAhead()
        {
            GotoURL();
            //driver.FindElement(By.XPath(".//*[@id='extended-forecast']/span[2]")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath(".//*[@id='basic-forecast']/span[2]")).Click();
        }
        

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
