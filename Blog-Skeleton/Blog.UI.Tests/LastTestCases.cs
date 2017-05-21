using Blog.UI.Tests.Pages.HomePage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class LastTestCases
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [Test, Property("Priority", 1)]
        [Author("Gergana_Suvandzhieva")]
        public void GuestUserTriesToLogIn()
        {
            HomePage home = new HomePage(this.driver);
            home.NavigateTo();
            home.AssertGuestUserLogIn();

        }

    }
}
