using NUnit.Framework;

namespace Blog.UI.Tests.Pages.HomePage
{
    public static class HomePageAsserter
    {
        public static void AssertBlogLogoText(this HomePage page)
        {
            Assert.AreEqual("SOFTUNI BLOG", page.blogLogo.Text);
        }

        public static void AssertGuestUserLogIn(this HomePage page)
        {
            Assert.IsTrue(page.LogInButton.Displayed);
            Assert.IsTrue(page.RegisterButton.Displayed);
        }
    }
}