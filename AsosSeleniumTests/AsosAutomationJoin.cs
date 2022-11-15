using OpenQA.Selenium;

namespace AsosSeleniumTests
{
    public class Tests
    {
        private WebDriver WebDriver { get; set; }
        public string BaseUrl { get; set; } = "http://www.asos.com";

        public string BrowserName = "chrome";

        public InitDriver initDriver = new InitDriver();

        public Common common = new Common();

        [SetUp]
        public void Setup()
        {
            WebDriver = initDriver.DriverFactory(BrowserName);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void HappyFlow()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = RandomString(10) + "@gmail.com",
                FirstName = "testFirst",
                LastName = "testLast",
                Password = "Aa1234567890"
            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseDates(WebDriver);

            common.ChooseGender(WebDriver);

            var checkBox = WebDriver.FindElements(By.XPath("//span[@class='checkmark']"));
            checkBox[GetRundomNumber()].Click();

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            try
            {
                bool isElementDisplayed = WebDriver.FindElement(By.Id("chrome-header")).Displayed;

                Assert.IsTrue(isElementDisplayed);
            }
            catch
            {
                string title = WebDriver.Title;
                string titleToCheck = "Access Denied";

                Assert.That(title, Is.EqualTo(titleToCheck));
            }
        }

        [Test]
        public void AllJoinigOption()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            bool isElementDisplayedGoogle = WebDriver.FindElement(By.Id("signup-google")).Displayed;
            bool isElementDisplayedApple = WebDriver.FindElement(By.Id("signup-google")).Displayed;
            bool isElementDisplayedFaceBook = WebDriver.FindElement(By.Id("signup-google")).Displayed;

            Assert.IsTrue(isElementDisplayedGoogle);
            Assert.IsTrue(isElementDisplayedApple);
            Assert.IsTrue(isElementDisplayedFaceBook);
        }

        [Test]
        public void NoDates()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = RandomString(10) + "@gmail.com",
                FirstName = "testFirst",
                LastName = "testLast",
                Password = "Aa1234567890"
            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseGender(WebDriver);

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            bool isElementDisplayed = WebDriver.FindElement(By.XPath("//span[@id='BirthYear-error']")).Displayed;

            Assert.IsTrue(isElementDisplayed);
        }

        [Test]
        public void PasswordError()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = RandomString(10) + "@gmail.com",
                FirstName = "testFirst",
                LastName = "testLast",
                Password = "Aa123456"
            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseDates(WebDriver);

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            bool isElementDisplayed = WebDriver.FindElement(By.XPath("//span[@id='Password-error']")).Displayed;

            Assert.IsTrue(isElementDisplayed);
        }

        [Test]
        public void NoPassword()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = RandomString(10) + "@gmail.com",
                FirstName = "testFirst",
                LastName = "testLast",
                Password = ""
            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseDates(WebDriver);

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            bool isElementDisplayed = WebDriver.FindElement(By.XPath("//span[@id='Password-error']")).Displayed;

            Assert.IsTrue(isElementDisplayed);
        }

        [Test]
        public void NoEmail()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = "",
                FirstName = "testFirst",
                LastName = "testLast",
                Password = "Aa1234567890"
            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseDates(WebDriver);

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            bool isElementDisplayed = WebDriver.FindElement(By.XPath("//span[@id='Email-error']")).Displayed;

            Assert.IsTrue(isElementDisplayed);
        }

        [Test]
        public void NoFirstName()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = RandomString(10) + "@gmail.com",
                FirstName = "",
                LastName = "testLast",
                Password = "Aa1234567890"
            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseDates(WebDriver);

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            bool isElementDisplayed = WebDriver.FindElement(By.XPath("//span[@id='FirstName-error']")).Displayed;

            Assert.IsTrue(isElementDisplayed);
        }

        [Test]
        public void NoLastName()
        {
            WebDriver = common.AsosGoToJoin(WebDriver, BaseUrl);

            PersonalInformationModel personalInformationModel = new PersonalInformationModel()
            {
                Email = RandomString(10) + "@gmail.com",
                FirstName = "testFirst",
                LastName = "",
                Password = "Aa1234567890"

            };

            common.PersonalInformation(WebDriver, personalInformationModel);

            common.ChooseDates(WebDriver);

            WebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();

            bool isElementDisplayed = WebDriver.FindElement(By.XPath("//span[@id='LastName-error']")).Displayed;

            Assert.IsTrue(isElementDisplayed);
        }

        private int GetRundomNumber()
        {
            Random random = new Random();
            return random.Next(0, 3);
        }

        private string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}