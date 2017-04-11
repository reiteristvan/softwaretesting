using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo
{
    public class GoogleTest
    {
        private ChromeDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [Test]
        public void CheckIfGoogleIsThere()
        {
            _driver.Url = "https://google.com";

            Assert.AreEqual(_driver.Title, "Google");
        }

        [Test]
        public void SearchForGoogleWithGoogle()
        {
            const string searchText = "Google";
            const string searchInputId = "lst-ib";

            _driver.Url = "https://google.com";

            IWebElement searchInput = _driver.FindElementById(searchInputId);
            searchInput.SendKeys(searchText);
            searchInput.Submit();
        }
    }
}
