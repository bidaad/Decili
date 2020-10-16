using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Decili.Code.Common
{
    public class SMSHelper
    {
        string SMSUsername = ConfigurationManager.AppSettings["SMSUsername"];
        string SMSPassword = ConfigurationManager.AppSettings["SMSPassword"];

        public bool SendSingleSMS(long ToCellPhone, string SMSContent)
        {
            //ir.sms.n.SendReceive ws = new ir.sms.n.SendReceive();
            //string message = string.Empty;

            //List<ir.sms.n.WebServiceSmsSend> sendDetails = new List<ir.sms.n.WebServiceSmsSend>();
            //sendDetails.Add(new ir.sms.n.WebServiceSmsSend()
            //{
            //    IsFlash = false,
            //    MessageBody = SMSContent,
            //    MobileNo = ToCellPhone
            //});

            //int smsLineID = 29742;
    
            //long[] result = ws.SendMessage(SMSUsername, SMSPassword, sendDetails.ToArray(), smsLineID, null, ref message);
            //if (!string.IsNullOrWhiteSpace(message))
            //    return false;
            //else
                return true;

        }
    }
}