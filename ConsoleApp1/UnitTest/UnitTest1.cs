using System;

using ConsoleApp1.DataAccess;
using ConsoleApp1.Payment;
using ConsoleApp1.Business;

using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  public class UnitTest1
  {

    [TestCase("1231231231231231", true)]
    [TestCase("1111222233334444", false)]
    public void ValidateCreditCardNumber(string cardNumber, bool expectedResult)
    {
      var card = new ConsoleApp1.Payment.CreditCardInformation();
      var result = card.ValidateCreditCardNumber(cardNumber);
      Assert.AreEqual(result, expectedResult);

    }

    [TestCase("12323", false)]
    [TestCase("111", true)]
    public void ValidateCreditCardSecurityCode(string cvv, bool expectedResult)
    {
      var card = new ConsoleApp1.Payment.CreditCardInformation();
      var result = card.ValidateCreditCardSecurityCode(cvv);
      Assert.AreEqual(result, expectedResult);
    }

    [TestCase("12/2020", true)]
    [TestCase("231/123123", false)]
    public void ValidateCreditCardDate(string date, bool expectedResult)
    {
      var card = new ConsoleApp1.Payment.CreditCardInformation();
      var result = card.ValidateCreditCardDate(date);
      Assert.AreEqual(result, expectedResult);
    }

    [TestCase("12/2016", false)]
    [TestCase("231/123123", false)]
    [TestCase("23/2020", true)]
    [TestCase("23/3020", false)]
    public void ValidateCreditCardExpiryDate(string date, bool expectedResult)
    {
      var card = new ConsoleApp1.Payment.CreditCardInformation();
      var result = card.ValidateCreditCardExpiryDate(date);
      Assert.AreEqual(result, expectedResult);
    }



    [TestCase("xx233334444", "11/2019", "123", "11/2016", "-1", false)]
    [TestCase("1111222233334444", "11/2019", "123", "11/2018", "-1", false)]
    [TestCase("1111222233334444", "11/2019", "123d", "11/2018", "-1", false)]
    [TestCase("1111222233334444", "11/2018", "123", "11/2019", "-1", false)]
    public void ValidCreditCard(string cardNumber, string validToDate, string backOfCardNumber, string validFromDate , string issueNumber, bool expectedResult)
    {
      var card = new ConsoleApp1.Payment.CreditCardInformation();
      var result = card.ValidCreditCard(cardNumber, validToDate, backOfCardNumber, validFromDate, issueNumber);
      Assert.AreEqual(result, expectedResult);
    }




  }
}
