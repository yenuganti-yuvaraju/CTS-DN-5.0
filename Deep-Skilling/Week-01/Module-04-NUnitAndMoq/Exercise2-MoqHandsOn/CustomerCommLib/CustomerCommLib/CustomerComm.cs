using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly ICustomerComm _customerComm;

        public CustomerComm(ICustomerComm customerComm)
        {
            _customerComm = customerComm;
        }

        public string SendMail()
        {
            return _customerComm.SendMail();
        }

        public string SendSMS()
        {
            return _customerComm.SendSMS();
        }
    }
}