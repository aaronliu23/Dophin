using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using ConsoleApp1.Payment;
using ConsoleApp1.DataAccess;
using ConsoleApp1.SysException;

namespace ConsoleApp1.Business
{
  public static class PaymentHandler
  {

    public static bool MakePayment(decimal amount, string cardnumber, string validToDate, int backOfCardNumber, string validFromDate = " ", string issueNumber = "-1")
    {
      var result = true;
    
        //create payment gateway
        var g = new FakePayPaymentGateway();
        g.Login("username", "pa$$word1234");

        //create card 
        CreditCardInformation card = new CreditCardInformation();

        //valid card
        var isCardValid= card.ValidCreditCard(cardnumber, validToDate, backOfCardNumber.ToString(), validFromDate, issueNumber);

        //create card
        if (isCardValid)
        {
          card.CardNumber = cardnumber;
          card.SecurityCode = backOfCardNumber;
          card.IssueNumber = issueNumber;
          card.ValidToDate = validToDate;

          if (issueNumber != "-1")
          {
            card.ValidFromDate = validFromDate;
          }
         
        }

        //make payment
        string invoiceReference = g.RequestPayment(amount, card);

      try
      {
        //insert record
        var sqlConnectionStr = ConfigurationSettings.AppSettings["ConnectionString"].ToString();

        var sqlAdapter = new SqlAdapter(sqlConnectionStr);
        var sqlCommend = "INSERT INTO [dbo].[Invoices] (InvoiceNumber, Amount, Card, TransactionDate) VALUES (@InvoiceNumber, @Amount, @Card, @TransactionDate)";
        var sqlParams = new Dictionary<string, object>();

        sqlParams.Add("@InvoiceNumber", invoiceReference);
        sqlParams.Add("@Amount", amount.ToString());
        sqlParams.Add("@Card", string.Format("************{0}", card.CardNumber.Substring(12, 4)));
        sqlParams.Add("@TransactionDate", DateTime.Now.ToString());

        sqlAdapter.ExcuteSQLCommand(sqlCommend, sqlParams);

        result = true;
        return result;
      }
      catch (Exception ex)
      {
        result = false;
        return result;
      }

    }
  }
}
