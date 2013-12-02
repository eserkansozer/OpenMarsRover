using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MarsRoverSeleniumTests
{
    [TestClass]
    public class AutomatedInputOutputs
    {

        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit(); 
        }

        [TestMethod]
        public void ShouldOutput12NWhen11NandActionM()
        {
            //go to page
            driver.Navigate().GoToUrl("localhost:57327");

            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("Input"));

            // Enter something to search for
            query.SendKeys("5 5\n1 1 N\nM");

            IWebElement ajaxlink = driver.FindElement(By.Id("sbmt"));
            ajaxlink.Click();

            //wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Name("Output")).Text != String.Empty );

            Assert.AreEqual("1 2 N", driver.FindElement(By.Name("Output")).Text);

        }

        [TestMethod]
        public void ShoulOutputErrorWhenWrongInput()
        {
            //go to page
            driver.Navigate().GoToUrl("localhost:57327");

            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("Input"));

            // Enter something to submit
            query.SendKeys("xxx\n1 1 N\nM");

            // Now submit the form. WebDriver will find the form for us from the element
            IWebElement ajaxlink = driver.FindElement(By.Id("sbmt"));
            ajaxlink.Click();

            Assert.AreEqual("Parsing Error... Please check your input!", driver.FindElement(By.Name("Output")).Text);
            
        }        
    }
}
