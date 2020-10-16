using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string FromName = txtFullName.Text;
            string Email = txtEmail.Text;
            string Comment = txtComment.Text;

            if (!RadCaptcha1.IsValid)
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "کد امنیتی اشتباه است.";
                return;
            }

            if (FromName.Trim() == "" || Email.Trim() == "" || Comment.Trim() == "")
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "لطفا همه فیلدهای لازم را تکمیل کنید.";
                return;
            }

            string MailBody = "";
            MailBody = "<b>از طرف:</b>" + FromName + "<BR>";
            MailBody += "<b>متن پیام: </b>" + Comment.Replace("\n", "<br>");

            Tools tools = new Tools();
            bool SendResult = tools.SendEmail(Email + " " + MailBody, "دسیلی - تماس با ما از طرف " + FromName, "info@decili.ir", "info@Decili.ir", "bidaad@gmail.com", "");
            if (SendResult)
            {
                BOLEmails EmailsBOL = new BOLEmails();
                EmailsBOL.Insert(Email, 5, Comment);
                pnlSend.Visible = false;
                msgBox.Text = "پیام شما به مدیر سایت ارسال شد.";
            }
            else
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "بروز خطا در ارسال پیام";
            }


        }
    }
}