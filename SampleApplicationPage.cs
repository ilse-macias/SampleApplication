using System;
using OpenQA.Selenium;
using System.Threading;

namespace SampleApplication
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {

        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible => Driver.Title.Contains(_PageTitle);
        private string _PageTitle = "Sample Application Lifecycle - Sprint 3 - Ultimate QA";

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        public IWebElement MaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='male']"));
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));

        internal void ClearCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(Constants.URL_SPRINT3);
            Driver.Manage().Window.Maximize();
        }

        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Click();
            Thread.Sleep(5000);
            return new UltimateQAHomePage(Driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    MaleGenderRadioButton.Click();
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
            }
        }
    }
}