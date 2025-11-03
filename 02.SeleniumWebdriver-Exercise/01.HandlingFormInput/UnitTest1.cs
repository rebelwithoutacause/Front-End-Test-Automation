using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace _01.HandlingFormInput
{
    public class FormFill
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [Test]
        public void Test_RegisterUser()
        {
            //Click the buttons
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();

            //Fill the form
            driver.FindElement(By.CssSelector("input[type='radio'][value='m']")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys("Jason");
            driver.FindElement(By.Name("lastname")).SendKeys("Voorhees");
            driver.FindElement(By.Id("dob")).SendKeys("06/13/1976");

            Random rnd = new Random();
            int num = rnd.Next(1000, 90000);
            String email = "jason.vorhees" + num.ToString() + "@softuni.bg";

            driver.FindElement(By.Name("email_address")).SendKeys(email);
            driver.FindElement(By.Name("company")).SendKeys("Friday13");

            driver.FindElement(By.Name("street_address")).SendKeys("Horror Street");
            driver.FindElement(By.Name("suburb")).SendKeys("Suburb13");
            driver.FindElement(By.Name("postcode")).SendKeys("6666");
            driver.FindElement(By.Name("city")).SendKeys("New York City");
            driver.FindElement(By.Name("state")).SendKeys("Kansas");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("United States");

            driver.FindElement(By.Name("telephone")).SendKeys("088 666 6666");
            driver.FindElement(By.Name("fax")).SendKeys("666");
            driver.FindElement(By.Name("newsletter")).Click();

            driver.FindElement(By.Name("password")).SendKeys("Friday13");
            driver.FindElement(By.Name("confirmation")).SendKeys("Friday13");

            driver.FindElement(By.Id("tdb4")).Submit();

            Assert.That(driver.PageSource, Does.Contain("Your Account Has Been Created!"), "Account creation failed!");

            // Click on Log Off link
            driver.FindElement(By.LinkText("Log Off")).Click();

            // Click on Continue button
            driver.FindElement(By.LinkText("Continue")).Click();

            Console.WriteLine("User Account Created with email: " + email);



        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
