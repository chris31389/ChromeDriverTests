using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ChromeDriverTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // https://automatetheplanet.com/webdriver-dotnetcore2/
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://automatetheplanet.com/multiple-files-page-objects-item-templates/");
                var link = driver.FindElement(By.PartialLinkText("TFS Test API"));
                var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
                ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
                var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("TFS Test API")));
                clickableElement.Click();
            }
        }
    }
}
