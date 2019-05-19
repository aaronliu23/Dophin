using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      Business.PaymentHandler.MakePayment(100, "1111222233334444", "11/2019", 123);
    }
  }
}
