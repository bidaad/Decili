using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
{
    public partial class AccountCharge : System.Web.UI.Page
    {
        protected string FormBody = "";

        public string tranKey = ConfigurationManager.AppSettings["BMITransactionKey"];
        public string CardAcqID = ConfigurationManager.AppSettings["BMIMerchantID"];
        public string TerminalId = ConfigurationManager.AppSettings["BMITerminalID"];
        public string ReturnURL = ConfigurationManager.AppSettings["ReturnURL"];
        public string ServiceURL = ConfigurationManager.AppSettings["BMIServiceURL"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Security.Check();
            int UserCode = Convert.ToInt32(Session["UserCode"]);

            if (!Page.IsPostBack)
            {

                BOLUsers UsersBOL = new BOLUsers();
                Users CurUser = UsersBOL.GetUserByEmail(Session["Email"].ToString());

                int AccountBalance = UsersBOL.GetBalance(UserCode);
                lblAccountBalance.Text = Tools.FormatCurrency(Tools.ChageEnc(AccountBalance.ToString())) + " ریال ";

            }
        }


        protected void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            object strAddVal = txtAmount.Value;
            int AddAmount;
            Int32.TryParse(strAddVal.ToString(), out AddAmount);
            if (AddAmount == 0)
            {
                msgMessage.Text = "مبلغ معتبر نیست";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }
            else if (AddAmount < 10)
            {
                msgMessage.Text = "مبلغ شارژ نباید كمتر از 10 ریال باشد.";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }
            else if (AddAmount > 100000000)
            {
                msgMessage.Text = "مبلغ شارژ نباید بیشتر از 100000000 ریال باشد.";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }

            int UserCode = Convert.ToInt32(Session["UserCode"]);
            string UserIP = "";

            int BankCode = Convert.ToInt32(ddlBankCode.SelectedValue);

            try
            {
                BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(UserCode);
                int UserTransactionCode = UserTransactionsBOL.Insert(UserCode, DateTime.Now, 1, 1, UserIP, AddAmount, 5, null, null, BankCode);
                long OrderId = Convert.ToInt64(UserTransactionCode);
                string AdditionalData = "";
                string requestKey; // request key
                
                ir.bmi.bmiutility4.MerchantUtility utl = new ir.bmi.bmiutility4.MerchantUtility();
                utl.Url = ServiceURL;

                FormBody = utl.PaymentUtilityAdditionalData(CardAcqID, AddAmount, OrderId, tranKey, TerminalId, ReturnURL,
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

    }
}