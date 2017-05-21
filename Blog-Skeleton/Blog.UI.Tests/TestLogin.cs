﻿using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.Login;
using Blog.UITests.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class TestLogin
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".jpg";
                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            }
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void ValidLogIn()
        {
            // IWebDriver driver = BrowserHost.Instance.Application.Browser;

            var loginPage = new LoginPage(this.driver);
            LogIn user = new LogIn("Tsvetelina@abv.bg", "123456");
            //var logIn = AccessExcelData.GetTestData("ValidLogin");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInFormHardCode(user);
            loginPage.AssertValidLogIn1(("Hello"));
            loginPage.AssertValidLogIn2("Log off");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInNoEmailAddress()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertNoEmailAddressDetected("The Email field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void ToFail()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertNoEmailAddressDetected("Password");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void ValidLogInToFail()
        {
            // IWebDriver driver = BrowserHost.Instance.Application.Browser;

            var loginPage = new LoginPage(this.driver);
            LogIn user = new LogIn("Tsvetelina@abv.bg", "123456");
            //var logIn = AccessExcelData.GetTestData("ValidLogin");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInFormHardCode(user);
            loginPage.AssertValidLogIn1(("Goodbye"));
            loginPage.AssertValidLogIn2("Log off");
        }

    }
}

