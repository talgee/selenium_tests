using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Common
    {
        public void ChooseDates(WebDriver WebDriver) 
        {
            var day = WebDriver.FindElement(By.Id("BirthDay"));
            var selectElementDay = new SelectElement(day);
            selectElementDay.SelectByValue("16");

            var month = WebDriver.FindElement(By.Id("BirthMonth"));
            var selectElementMonth = new SelectElement(month);
            selectElementMonth.SelectByValue("12");

            var year = WebDriver.FindElement(By.Id("BirthYear"));
            var selectElementYear = new SelectElement(year);
            selectElementYear.SelectByValue("1987");
        }

        public void PersonalInformation(WebDriver WebDriver, PersonalInformationModel personalInformationModel) 
        {
            WebDriver.FindElement(By.Id("Email")).SendKeys(personalInformationModel.Email);
            WebDriver.FindElement(By.Id("FirstName")).SendKeys(personalInformationModel.FirstName);
            WebDriver.FindElement(By.Id("LastName")).SendKeys(personalInformationModel.LastName);
            WebDriver.FindElement(By.Id("Password")).SendKeys(personalInformationModel.Password);
        }

        public void ChooseGender(WebDriver webDriver) 
        {
            var gender = webDriver.FindElement(By.XPath("//div[@class='field gender ']"));
            var genderList = gender.FindElements(By.XPath("//fieldset"));
            genderList[2].Click();
            genderList[2].FindElement(By.XPath("//label[@for='male']")).Click();
        }

        public WebDriver AsosGoToJoin(WebDriver WebDriver, string BaseUrl)
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("att_lightbox_close")));
                WebDriver.FindElement(By.Id("att_lightbox_close")).Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@type='accountUnfilled']")));
                WebDriver.FindElement(By.XPath("//span[@type='accountUnfilled']")).Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-testid='signup-link']")));
                WebDriver.FindElement(By.XPath("//a[@data-testid='signup-link']")).Click();
            }
            catch
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@type='accountUnfilled']")));
                WebDriver.FindElement(By.XPath("//span[@type='accountUnfilled']")).Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-testid='signup-link']")));
                WebDriver.FindElement(By.XPath("//a[@data-testid='signup-link']")).Click();
            }

            return WebDriver;
        }
    }
}
