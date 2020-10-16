using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace IPanel.Decili.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginUser_Shouldbe_Successful()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://ipanel.decili.ir/");
            driver.Manage().Window.Maximize();

            IWebElement Username = driver.FindElement(By.Id("CP1_ctl00_txtEmail"));
            IWebElement Password = driver.FindElement(By.Id("CP1_ctl00_txtPassword"));
            IWebElement LoginButton = driver.FindElement(By.Id("CP1_ctl00_btnSubmit"));

            Username.SendKeys("bidaad@gmail.com");
            Password.SendKeys("shetab12#$");
            LoginButton.Click();

            var DivContainer = driver.FindElement(By.ClassName("SingleAdver"));
            var FirstADLink = DivContainer.FindElement(By.TagName("A"));
            FirstADLink.Click();

            IWebElement ADTitle = driver.FindElement(By.Id("CP1_txtTitle"));
            ADTitle.SendKeys(OpenQA.Selenium.Keys.End + "1111");
            IWebElement SaveADButton = driver.FindElement(By.Id("CP1_btnEditAds"));
            SaveADButton.Click();

            bool Message = driver.PageSource.Contains("آگهی شما با موفقیت اصلاح شد. پس از تایید در لیست آگهی ها قرار میگیرد.");
            Assert.IsTrue(Message);

        }
    }
}
