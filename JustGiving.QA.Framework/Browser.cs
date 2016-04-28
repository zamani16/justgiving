using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace JustGiving.QA.Framework
{
    public class Browser
    {
        public static IWebDriver driver { get;  set; }

        public static void Initialize()
        {
            driver =  new FirefoxDriver(); 
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(15));
        }

        public static void Close()
        {
            driver.Dispose();
        }
    }

   
}
