using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;


namespace JustGiving.QA.Framework.Pages
{
    public static class Pages
    {

        public static class HomePage
        {
            public static void GoToWebPage(string webPage)
            {

                Browser.driver.Navigate().GoToUrl(webPage);

            }

            public static void WaitForPageToLoad()
            {
                WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(15));
                wait.Until<IWebElement>((d) =>
                {
                    IWebElement elem = d.FindElement(By.CssSelector("a[data-bind*='donate-now']"));
                    if (elem.Displayed &&
                        elem.Enabled)
                    {
                        return elem;
                    }
                    return null;
                });
            }
   
        }

        public static class AmountPage
        {
            public static void SelectAmount(int amount)
            {
              
               string xpathStr = "//label[contains(.,'" + amount + "')]";
               Browser.driver.FindElement(By.XPath(xpathStr)).Click();
              
            }

            public static void SelectCurrency(string ccy)
            {
                SelectElement selectCcy =
                    new SelectElement(
                        Browser.driver.FindElement(By.CssSelector("select[data-bind *= 'value: SelectedCurrency']")));
                selectCcy.SelectByText(ccy);
            }

            public static void VerifyFiveMerchantsDisplayed(int numOfMerchants)
            {
                ReadOnlyCollection<IWebElement> offers = Browser.driver.FindElements(By.CssSelector("tr[ng-repeat ^='o in vm.product.offerItems']"));
                Assert.IsTrue
                    (offers.Count == numOfMerchants);
            }

        
        }

        public static class Footer
        {
            public static void ClickContinue()
            {
                Browser.driver.FindElement(By.LinkText("Continue")).Click();
            }
        }

        public static class EmailEntryPage
        {
            public static void EnterEmail(string email)
            {
                Browser.driver.FindElement(By.Name("Identity.EmailAddress")).SendKeys(email);
                Footer.ClickContinue();
            }
        }
        public static class AccountCreationPage
        {
            public static void EnterPassword(string password)
            {
                Browser.driver.FindElement(By.Name("Authentication.Password")).SendKeys(password);
                Footer.ClickContinue();
            }
        }

        public static class PaymentMethodPage
        {
            public static void SelectCardType(string cardType)
            {
                SelectElement cardTypeSelect = new SelectElement(Browser.driver.FindElement(By.Id("Payment_CardType")));
                cardTypeSelect.SelectByText(cardType);
            }

            public static void EnterCardNumber(string cardNumber)
            {
                Browser.driver.FindElement(By.Id("Payment_CardNumber")).SendKeys(cardNumber);
            }

            public static void SelectExpiryMonth(string month)
            {
                SelectElement cardExpiryMonth = new SelectElement(Browser.driver.FindElement(By.Id("Payment_ExpiryDatePart_Month")));
                cardExpiryMonth.SelectByText(month);

            }

            public static void SelectExpiryYear(string year)
            {
                SelectElement cardExpiryYear = new SelectElement(Browser.driver.FindElement(By.Id("Payment_ExpiryDatePart_Year")));
                cardExpiryYear.SelectByText(year);
            }

            public static void EnterNameOnCard(string name)
            {
                Browser.driver.FindElement(By.Id("Payment_NameOnCard")).SendKeys(name);
            }
        }

        public static class BillingAddressPage
        {
            public static void EnterPostCode(string postcode)
            {
             Browser.driver.FindElement(By.Id("Payment_BillingAddress_Postcode")).SendKeys(postcode);
            }

            public static void SelectCountry(string country)
            {
                SelectElement countrySelect = new SelectElement(Browser.driver.FindElement(By.Id("Payment_BillingAddress_Country")));
                countrySelect.SelectByText(country);
            }

            public static void SelectFirstLine(string fline)
            {
                SelectElement firstLineSelect = new SelectElement(Browser.driver.FindElement(By.Id("first-line-selector")));
                firstLineSelect.SelectByText(fline);

            }
        }

        public static class ReviewDonatePage
        {
            public static void VerifyAmount(string amount)
            {
                Assert.True(Browser.driver.FindElement(By.CssSelector("span.donation:nth-last-child(2)")).Text.Contains(amount));
            }
        }
    }
}
