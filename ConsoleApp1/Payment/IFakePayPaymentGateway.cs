using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Payment
{
  public interface IFakePayPaymentGateway
  {
    bool Login(string user, string password);
    string RequestPayment(decimal amount, CreditCardInformation card);
  }
}
