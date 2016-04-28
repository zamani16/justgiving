Feature: JustGivings
    As a user
	In order to make a donation 
	I need to go though the donation workflow
//Background: I have a browser
@JustGivings
Scenario: A user can donate on donation page 2050
	Given A user browse to JustGivings donation page 2050
	When Donation page is loaded
	And user chooses to donate an amount of '50' in 'EUR' currency, enters name 'DonatorName' and 'Donator message' message
	And in the Email Entry Page user enters email 'zamani_b@yahoo.com' 
	And in the Account Creation Page user enters pasword 'passw0rd' 
	And in the Payment Method Page user enters the following card details
	| Card type | Card number		  | Expiry month | Expiry year | Name on card |
	|Visa Debit |  4659104220427633   |   07         |2019         | B ZAMANI     |
	And in the Billing Address Page user enters the following address details
	| Country        | Postcode | Address line 1 | City   |
	| United Kingdom | W3 6YL   | 5 Curtis Drive | London |
	Then user lands on the Donate & Review page where the following details ae displayed
	| Amount | last four digits of the card | Post Code |
	| 50     | 7633                         | W3 6YL    |

