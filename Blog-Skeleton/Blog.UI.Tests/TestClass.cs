using NUnit.Framework;
using OpenQA.Selenium;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void CheckLogo()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;

            driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            var blogLogo = driver.FindElement(By.ClassName("navbar-brand"));

            Assert.AreEqual("SOFTUNI BLOG", blogLogo.Text);
        }
    }
}
