using Decili.ir.shaparak.pec;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
{
    public partial class UpgradeMembership : System.Web.UI.Page
    {
        protected string FormBody = "";

        public string tranKey = ConfigurationManager.AppSettings["BMITransactionKey"];
        public string CardAcqID = ConfigurationManager.AppSettings["BMIMerchantID"];
        public string TerminalId = ConfigurationManager.AppSettings["BMITerminalID"];
        public string ReturnURL = ConfigurationManager.AppSettings["ReturnURL"];
        public string ServiceURL = ConfigurationManager.AppSettings["BMIServiceURL"];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGold_Click(object sender, EventArgs e)
        {
            StartMembership(4);
        }

        protected void btnSilver_Click(object sender, EventArgs e)
        {
            StartMembership(3);
        }

        protected void btnBronze_Click(object sender, EventArgs e)
        {
            StartMembership(2);
        }

        public void StartMembership(int HCMembershipTypeCode)
        {
            try
            {
                int Amount = 0;
                int UserCode = Convert.ToInt32(Session["UserCode"]);
                int BankCode = Convert.ToInt32(HiddenBankCode.Value); ;
                int MembershipLen = Convert.ToInt32(HiddenMembershipLen.Value);

                switch (HCMembershipTypeCode)
                {
                    case 2:
                        Amount = 100000;
                        break;
                    case 3:
                        Amount = 150000;
                        break;
                    case 4:
                        Amount = 500000;
                        break;
                    default:
                        break;
                }

                if (MembershipLen == 2)
                    Amount = Amount * 3;
                else if (MembershipLen == 3)
                    Amount = Amount * 6;
                else if (MembershipLen == 4)
                    Amount = Amount * 12;


                string UserIP = Request.UserHostAddress;

                BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(UserCode);
                int UserTransactionCode = UserTransactionsBOL.Insert(UserCode, DateTime.Now, 1, 1, UserIP, Amount, 8, null, null, BankCode, HCMembershipTypeCode, MembershipLen);
                long OrderId = Convert.ToInt64(UserTransactionCode);

                #region Melli
                if (BankCode == 4)// Melli
                {
                    try
                    {
                        string AdditionalData = "";
                        string requestKey; // request key

                        Decili.ir.bmi.bmiutility4.MerchantUtility utl = new Decili.ir.bmi.bmiutility4.MerchantUtility();
                        utl.Url = ServiceURL;

                        FormBody = utl.PaymentUtilityAdditionalData(CardAcqID, Amount, OrderId, tranKey, TerminalId, ReturnURL,
                                                                    AdditionalData, out requestKey);
                        bool UpdateResult = UserTransactionsBOL.UpdateRequestKey(UserTransactionCode, requestKey);
                        if (UpdateResult)
                        {
                            FormBody += "</form><script> document.getElementById('paymentUTLfrm').submit();</script>";
                            ((Literal)Master.FindControl("ltrForm")).Text = FormBody;
                        }
                        else
                        {
                            msgMessage.Text = "خطا در برقراری ارتباط با سرور بانک ملی";
                            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                            return;
                        }

                    }
                    catch (Exception err)
                    {
                        msgMessage.Text = "خطا در برقراری ارتباط با سرور بانک ملی" + err.Message;
                        msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                        return;
                    }
                }
                #endregion
                #region Parsian
                else if (BankCode == 2) // Parsian Bank
                {
                    long Authority = 0;
                    byte Status = 1;
                    EShopService ParsianService = new EShopService();
                    ParsianService.PinPaymentRequest(ConfigurationManager.AppSettings["ParsianPin"], Amount, UserTransactionCode, ReturnURL, ref Authority, ref Status);
                    if (Status == 0)
                    {

                        bool UpdateResult = UserTransactionsBOL.UpdateAuthority(UserTransactionCode, Authority.ToString());
                        if (UpdateResult)
                        {
                            Response.Redirect("https://pec.shaparak.ir/pecpaymentgateway/default.aspx?au=" + Authority);
                            return;
                        }
                        else
                        {
                            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                            msgMessage.Text = "خطا ذخیره داده های تراکنش بانک پارسیان" + " کد خطا: " + Status;
                            return;
                        }
                    }
                    else
                    {
                        msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                        msgMessage.Text = "خطا در برقراری ارتباط با بانک پارسیان" + " کد خطا: " + Status;
                        return;
                    }
                }
                #endregion
            }
            catch (Exception errPay)
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgMessage.Text = "خطا در برقراری ارتباط با بانک " + errPay.Message;
                return;

            }
        }
    }
}