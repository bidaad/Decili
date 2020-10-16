using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserControls_SuggestToFriend : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtToEmail.Text.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "ایمیل دوست شما معتبر نمیباشد";
            return;
        }
        EmailTools emailTools  = new EmailTools();
        string ToEmail = txtToEmail.Text;
        string FromEmail = txtFromEmail.Text;
        if (!emailTools.IsValidEmail(ToEmail))
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "ایمیل دوست شما معتبر نمیباشد";
            return;
        }
        if (!emailTools.IsValidEmail(FromEmail))
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "ایمیل شما معتبر نمیباشد";
            return;
        }
        
        Tools tools = new Tools();
        string EmailTemplate = emailTools.LoadTemplate("Recommend");//Suggest
        EmailTemplate = EmailTemplate.Replace("[MyName]", txtYourName.Text);

        bool SendSellResult = tools.SendEmail(EmailTemplate, " معرفی سایت جالب از طرف " + txtYourName.Text, FromEmail, ToEmail, "admin@Decili.ir", "");
        if (SendSellResult)
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
            msgBox.Text = "ایمیل با موفقیت ارسال شد.";
        }

    }
}
