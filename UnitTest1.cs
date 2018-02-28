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
        }

        [TestMethod]
        //[TestCategory("SampleApplicationOne")]
        public void Sprint1()
        {
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
            
        }

        [TestMethod]
        //[TestCategory("SampleApplicationOne")]
        public void Sprint2()
        {
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
