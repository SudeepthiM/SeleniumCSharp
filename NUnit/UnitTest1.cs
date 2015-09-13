using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using System.Threading;

namespace NUnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver _driver;
        String currentUrl;

        [SetUp]
        public void GotoBbcWeather()
        {
            _driver = new FirefoxDriver();
            _driver.Url = "http://www.bbc.co.uk/";
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2000));
            _driver.FindElement(By.XPath(".//*[@id='orb-nav-links']/ul/li[3]/a")).Click();
            currentUrl = _driver.Url;
            _driver.FindElement(By.XPath(".//*[@id='locator-form-search']")).SendKeys("Reading, Reading");
            _driver.FindElement(By.XPath(".//*[@id='locator-form-submit']")).Click();
            
        }

        [Test]
        public void CheckWethereOnReadingOrNot()
        {
            
            Assert.AreEqual("http://www.bbc.co.uk/weather/", currentUrl);
            String title = _driver.Title;
            Debug.WriteLine("Weather Reading is opened");
            Assert.AreEqual("BBC Weather - Reading", title);
        }

        [Test]
        public void FurtherAhead()
        {
            
            _driver.FindElement(By.XPath(".//*[@id='extended-forecast']/span[2]")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(".//*[@id='basic-forecast']/span[2]")).Click();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}
