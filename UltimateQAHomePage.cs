using OpenQA.Selenium;

namespace SampleApplication
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }

        public bool IsVisible => Driver.FindElement(By.LinkText("Start learning now")).Displayed;
         //   { get; internal set; }
    }
}