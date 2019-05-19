using System;

using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApp1.SysException;

namespace ConsoleApp1.Payment
{
  public class CreditCardInformation: ICreditCardInformation
  {
    public string CardNumber { get; set; }
    public int SecurityCode { get; set; }
    public string ValidToDate { get; set; }
    public string ValidFromDate { get; set; }
    public string IssueNumber { get; set; }

    public CreditCardInformation()
    {
      
    }

    public bool ValidCreditCard(string cardNumber, string validToDate, string backOfCardNumber, string validFromDate = " ", string issueNumber = "-1")
    {
      var result = false;

      //check the card number
      result = ValidateCreditCardNumber(cardNumber);
      if (!result)
        return result;

      //check the security code
      result = ValidateCreditCardSecurityCode(backOfCardNumber);
      if (!result)
        return result;

      //check the valid from date format
      if (!string.IsNullOrEmpty(validFromDate))
      {
        result = ValidateCreditCardDate(validFromDate);
        if (!result)
          return result;
      }

      //check the valid to date format
      result = ValidateCreditCardExpiryDate(validToDate);
      if (!result)
        return result;

      return result;

    }

    public bool ValidateCreditCardNumber(string creditCardNumber)
    {
      var result = false;
      var cardCheck = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");

      if (!cardCheck.IsMatch(creditCardNumber))
      {
        result = false;
        throw new Exception(ExceptionMessage.CreditCardInvalidCardNumber);
      }
      else
      {
        result = true;
      }
      return result;
    }

    public bool ValidateCreditCardSecurityCode(string securityCode)
    {
      var result = false;
      var cvvCheck = new Regex(@"^\d{3}$");
      if (!cvvCheck.IsMatch(securityCode)) // <2>check cvv is valid three digital
      {
        result = false;
        throw new Exception(ExceptionMessage.CreditCardInvalidSecurityCode);
      }
      else
      {
        result = true;
      }

      return result;
    }

    public bool ValidateCreditCardDate(string date)
    {
      var result = false;
      var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
      var yearCheck = new Regex(@"^20[0-9]{2}$");

      var dateParts = date.Split('/');
      if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1]))
      {
        result = false;
        throw new Exception(ExceptionMessage.CreditCardInvalidDateFormat);
      }
      else
      {
        result = true;
      }
      return result;
    }

    public bool ValidateCreditCardExpiryDate(string expiryDate)
    {
      var result = false;

      result = ValidateCreditCardDate(expiryDate);
      if (!result)
        return result;

      var dateParts = expiryDate.Split('/');
     
      var year = int.Parse(dateParts[1]);
      var month = int.Parse(dateParts[0]);
      var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
      var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

      //check expiry greater than today & within next 6 years <7, 8>>
      result = cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6);

      if (!result)
      {
        throw new Exception(ExceptionMessage.CreditCardExpired);
      }
      
      return result;
    }


  }
}
