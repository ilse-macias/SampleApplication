using System;
using OpenQA.Selenium;
using System.Threading;

namespace SampleApplication
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        // private IWebDriver _driver;

        public SampleApplicationPage(IWebDriver driver) : base(driver) { }
        //{
        //    _driver = driver;
        //}

        public bool IsVisible => Driver.Title.Contains("Sample Application Lifecycle - Sprint 2 - Ultimate QA");
        //{
        //    get
        //    {
        //        return _driver.Title.Contains("Sample Application Lifecycle – Sprint 1");
        //    }
        //    internal set { }
        //}

        internal void ClearCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-2/");
            Driver.Manage().Window.Maximize();
        }

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Click();
            Thread.Sleep(5000);
            return new UltimateQAHomePage(Driver);
        }
    }
}