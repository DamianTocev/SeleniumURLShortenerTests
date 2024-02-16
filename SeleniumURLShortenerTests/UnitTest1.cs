using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace URLShortenerTests
{
    public class ShortenerAppTests
    {
        private WebDriver driver;
        //private const string baseUrl = "https://shorturl.damiant4.repl.co/";
        private const string baseUrl = "https://ffc0118f-7304-4d78-aa9e-c1e737c17d20-00-2xqb128crqg88.riker.replit.dev/";

        [SetUp]
        public void OpenBrouser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = baseUrl;
        }

        [TearDown]
        public void CloseBrouser()
        {
            this.driver.Dispose();
        }

        [Test]
        public void Test_CheckHomePageTitle()
        {
            var homeElement = driver.FindElement(By.LinkText("Home"));
            homeElement.Click();
            var expectedTitle = "URL Shortener";
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_CheckShortUrlPageTitle()
        {
            var shortUrlElement = driver.FindElement(By.LinkText("Short URLs"));
            shortUrlElement.Click();
            var expectedTitle = "Short URLs";
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_CheckFirstCellContainsText()
        {
            var shortUrlElement = driver.FindElement(By.LinkText("Short URLs"));
            shortUrlElement.Click();
            var expectedTitle = "Short URLs";

            var firstCell = driver.FindElement(By.LinkText("https://nakov.com"));
            var expectedText = "https://nakov.com";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
            Assert.That(firstCell.Text, Is.EqualTo(expectedText));
        }

        [Test]
        public void Test_CheckFirstAndSecondCellsContainText()
        {
            var shortUrlElement = driver.FindElement(By.LinkText("Short URLs"));
            shortUrlElement.Click();
            var expectedTitle = "Short URLs";

            var firstCell = driver.FindElement(By.LinkText("https://nakov.com"));
            var firstCellText = "https://nakov.com";

            //var secondCell = driver.FindElement(By.LinkText("http://shorturl.damiant4.repl.co/go/nak"));
            var secondCell = driver.FindElement(By.LinkText("http://ffc0118f-7304-4d78-aa9e-c1e737c17d20-00-2xqb128crqg88.riker.replit.dev/go/nak"));
            //var secondCellText = "http://shorturl.damiant4.repl.co/go/nak";
            var secondCellText = "http://ffc0118f-7304-4d78-aa9e-c1e737c17d20-00-2xqb128crqg88.riker.replit.dev/go/nak";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
            Assert.That(firstCell.Text, Is.EqualTo(firstCellText));
            Assert.That(secondCell.Text, Is.EqualTo(secondCellText));
        }

    }
}