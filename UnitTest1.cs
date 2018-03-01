using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleApplication
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        SampleApplicationPage sampleApplicationPage;
        TestUser testUser;

        private static void AssertPage1(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        private static void AssertPageVisible2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            sampleApplicationPage = new SampleApplicationPage(_driver);
            testUser = new TestUser();

            sampleApplicationPage.ClearCookies();
            sampleApplicationPage.GoTo();

            testUser.FirstName = "Hello";
            testUser.LastName = "Macías";
            testUser.GenderType = Gender.Other;
        }

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        public void Sprint1()
        {
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
            AssertPage1(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Fake 2nd test.")]
        public void Sprint2()
        {
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
            AssertPageVisible2(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Validate that when selecting the 'Other' gender type, the from is submitted successfully.")]
        public void Sprint3()
        {
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
            AssertPageVisible2(ultimateQAHomePage);
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
