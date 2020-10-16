using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;

namespace Decili.Admin.Email
{
    public partial class MngEmails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnSave_Click(object sender, EventArgs e)
        {
            string EmailContent = txtEmailContent.Text;
            string EmailCount = txtEmailCount.Text;
            int TakeCount = Convert.ToInt32(txtEmailCount.Text);

            string MailBody = EmailContent;
            EmailDataContext dc = new EmailDataContext();
            IQueryable<EmailList> objEmailList = dc.EmailLists.Where(p => p.Sent.Equals(false)).OrderBy(p => p.Code).Take(TakeCount);

            string ToEmail = "";
            string strCCEmails = "";
            int Counter = 0;
            string CodeList = "";
            Tools tools = new Tools();
            int SentCount = 0;
            foreach (var item in objEmailList)
            {
                if (CodeList == "")
                    CodeList = item.Code.ToString();
                else
                    CodeList = CodeList + "," + item.Code.ToString();
                if (Counter == 0)
                    ToEmail = item.Email;
                if (Counter > 0)
                {
                    if (strCCEmails == "")
                        strCCEmails = item.Email;
                    else
                        strCCEmails = strCCEmails + "," + item.Email;
                }
                Counter++;

                if (Counter == 50)
                {
                    ToEmail = ToEmail.Replace(" ", "");
                    strCCEmails = strCCEmails.Replace(" ", "");
                    bool SendResult = tools.SendEmail(MailBody, " عرضه محصولات اورجینال " , "adver@Decili.ir", ToEmail, strCCEmails, "");
                    if (SendResult)
                        SentCount += 51;
                    dc.spMarkSent(CodeList);
                    Counter = 0;
                    strCCEmails = "";
                    ToEmail = "";
                    CodeList = "";
                }

            }
            if (SentCount > 0)
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
                msgBox.Text = SentCount + " ایمیل ارسال شد.";
            }
            else
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "خطا در ارسال ایمیل";
            }

        }
    }
}