using System;
using TechTalk.SpecFlow;
using JustGiving.QA.Framework;
using JustGiving.QA.Framework.Pages;
using JustGiving.QA.Web.Tests;

namespace Bookatable.Neptune.QA.Web.Tests
{

    [Binding]
    public class JustGivingsSteps: BaseTest
    {
        [Given(@"A user browse to JustGivings donation page 2050")]
        public void GivenAUserBrowseToJustGivingsHomepage()
        {
            Pages.HomePage.GoToWebPage("https://www.justgiving.com/4w350m3/donation/direct/charity/2050");
        }
        
        [When(@"Donation page is loaded")]
        public void WhenHomepageIsLoaded()
        {
            Pages.HomePage.WaitForPageToLoad();
        }

        [When(@"user chooses to donate an amount of '(.*)' in '(.*)' currency, enters name '(.*)' and '(.*)' message")]
        public void WhenUserChoosesToDonateAnAmountOfInCurrencyEntersNameAndMessage(int amount, string currency, string name, string message)
        {
            Pages.AmountPage.SelectCurrency(currency);
            Pages.AmountPage.SelectAmount(amount);
            Pages.Footer.ClickContinue();
        }

        [When(@"in the Email Entry Page user enters email '(.*)'")]
        public void WhenInTheEmailEntryPageUserEntersEmail(string email)
        {
            Pages.EmailEntryPage.EnterEmail("zamani_b@yahoo.com");
        }

        [When(@"in the Account Creation Page user enters pasword '(.*)'")]
        public void WhenInTheAccountCreationPageUserEntersPasword(string p0)
        {
            Pages.AccountCreationPage.EnterPassword("Passw0rd");
        }

        [When(@"in the Payment Method Page user enters the following card details")]
        public void WhenInThePaymentMethodPageUserEntersTheFollowingCardDetails(Table table)
        {
            Pages.PaymentMethodPage.SelectCardType(table.Rows[0][0]);
            Pages.PaymentMethodPage.EnterCardNumber(table.Rows[0][1]);
            Pages.PaymentMethodPage.SelectExpiryMonth(table.Rows[0][2]);
            Pages.PaymentMethodPage.SelectExpiryYear(table.Rows[0][3]);
            Pages.PaymentMethodPage.EnterNameOnCard(table.Rows[0][4]);
            Pages.Footer.ClickContinue();
        }

        [When(@"in the Billing Address Page user enters the following address details")]
        public void WhenInTheBillingAddressPageUserEntersTheFollowingAddressDetails(Table table)
        {
            Pages.BillingAddressPage.SelectCountry(table.Rows[0][0]);
            Pages.BillingAddressPage.EnterPostCode(table.Rows[0][1]);
            Pages.Footer.ClickContinue();
            Pages.BillingAddressPage.SelectFirstLine(table.Rows[0][2]);
            Pages.Footer.ClickContinue();
        }

        [Then(@"user lands on the Donate & Review page where the following details ae displayed")]
        public void ThenUserLandsOnTheDonateReviewPageWhereTheFollowingDetailsAeDisplayed(Table table)
        {
            Pages.ReviewDonatePage.VerifyAmount(table.Rows[0][0]);
        }

    }
}
