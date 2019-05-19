using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SysException
{
  public class ExceptionMessage
  {
    public const string CreditCardInvalidCardNumber = "Sorry the input credit card number is invalid. Please double check your credit card number!";
    public const string CreditCardExpired = "Sorry your credit card is expired!";
    public const string CreditCardInvalidDateFormat = "Sorry the date format is incorrect!";
    public const string CreditCardInvalidSecurityCode = "Sorry the security code should be three digital!";

    public const string FakePayPaymentGatewayInvalidLogin = "Sorry the Fake Pay log in credentials is invalid!";
    public const string FakePayPaymentGatewayRequestPaymentError = "Sorry the Fake Pay request is incorrect!Please try again later";
  }
}
