using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCSupport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            string Tel = txtTel.Text;
            string Email = txtEmail.Text;
            string Comment = txtComment.Text;

            if (!RadCaptcha1.IsValid)
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "کد امنیتی اشتباه است.";
                return;
            }

            if (Tel.Trim() == "" || Email.Trim() == "" || Comment.Trim() == "")
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "لطفا همه فیلدهای لازم را تکمیل کنید.";
                return;
            }
            if (Comment.Length > 240)
                Comment = Comment.Substring(0, 240);

            try
            {
                //string FromNumber = "30004968";
                string SMSText = Tel + "<br>" + Email + "<br>" + Comment;
                //long[] rec = null;
                //byte[] status = null;
                //Decili.com.panelesms.www.Send SmsPanel = new Decili.com.panelesms.www.Send();
                //ReqUtils Req = new ReqUtils();
                //string strCellPhone = "9394212088";//"9394212088";
                //string Url = @"http://panelesms.com/post/sendSMS.ashx?username=ip2502&password=25900&to=" + strCellPhone + "&text=" + SMSText + "&from=30004968";
                //Req.GetHTML(Url, System.Text.Encoding.UTF8);

                string MainBody = SMSText;
                bool SendResult = tools.SendEmail(MainBody, " تماس از دسیلی", Email, "sales@diamondgermany.com", "bidaad@gmail.com", "");

                if (SendResult)
                {
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
                    msgBox.Text = "پیام شما ارسال شد";
                    btnSend.Visible = false;
                }
                else
                {
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgBox.Text = "بروز خطا در ارسال پیام";
                }
            }
            catch (Exception errSMS)
            {
                string errMailBody = errSMS.Message;
                bool SendErrResult = tools.SendEmail(errMailBody, " خطا در  دسیلی ", "admin@Decili.ir", "bidaad@gmail.com", "", "");
            }


        }
    }
}