using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCommLib
{
    public interface ICustomerComm
    {
        string SendMail();
        string SendSMS();
    }
}