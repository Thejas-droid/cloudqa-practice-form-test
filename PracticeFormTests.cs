using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CloudQAAutomation
{
    public class PracticeFormTests
    {
        private IWebDriver driver;


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fname")));
        }


        [Test]
        public void LoadPracticeFormPage()
        {
            string title = driver.Title;
            

        }
        [Test]
        public void FillThreeFieldsWithRobustSelectors()
        {
            
            var firstNameInput = driver.FindElement(By.Id("fname"));
            firstNameInput.Clear();
            firstNameInput.SendKeys("John");

            
            var maleRadio = driver.FindElement(By.Id("male"));
            maleRadio.Click();

            
            var countryInput = driver.FindElement(By.Id("country"));
            countryInput.Clear();
            countryInput.SendKeys("India"); ;

           
            var lastNameInput = driver.FindElement(By.Id("lname"));
            lastNameInput.Clear();
            lastNameInput.SendKeys("Doe");

            
            var mobileInput = driver.FindElement(By.Id("mobile"));
            mobileInput.Clear();
            mobileInput.SendKeys("9876543210");

           
            var emailInput = driver.FindElement(By.Id("email"));
            emailInput.Clear();
            emailInput.SendKeys("john.doe@example.com");

            
            Assert.That(firstNameInput.GetAttribute("value"), Is.EqualTo("John"));
            Assert.That(maleRadio.Selected, Is.True);
            Assert.That(countryInput.GetAttribute("value"), Is.EqualTo("India"));
            Assert.That(lastNameInput.GetAttribute("value"), Is.EqualTo("Doe"));
            Assert.That(mobileInput.GetAttribute("value"), Is.EqualTo("9876543210"));
            Assert.That(emailInput.GetAttribute("value"), Is.EqualTo("john.doe@example.com"));

        }


        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
