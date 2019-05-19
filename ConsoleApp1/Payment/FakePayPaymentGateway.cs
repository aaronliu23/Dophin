using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApp1.SysException;

namespace ConsoleApp1.Payment
{
  public class FakePayPaymentGateway : IFakePayPaymentGateway
  {
    public FakePayPaymentGateway()
    {
    }

    public bool Login(string user, string password)
    {
      //TO DO payment log in process
      var result = false;
      try
      {

        result = true;
        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ExceptionMessage.FakePayPaymentGatewayInvalidLogin);
      }
    }


    public string RequestPayment(decimal amount, CreditCardInformation card)
    {
      //TO DO request payment pforcess
      string result = "";
      try
      {
        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ExceptionMessage.FakePayPaymentGatewayRequestPaymentError);
      }
      
    }

  }
}
