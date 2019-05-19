using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Payment
{
  public interface ICreditCardInformation
  {
    bool ValidCreditCard(string cardNumber, string validToDate, string backOfCardNumber, string validFromDate = " ", string issueNumber = "-1");

    bool ValidateCreditCardNumber(string creditCardNumber);

    bool ValidateCreditCardSecurityCode(string securityCode);

    bool ValidateCreditCardDate(string date);

    bool ValidateCreditCardExpiryDate(string expiryDate);

  }
}
