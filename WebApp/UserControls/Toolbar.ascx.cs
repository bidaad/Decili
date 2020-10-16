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

public partial class UserControls_Toolbar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnEmail_Click(object sender, ImageClickEventArgs e)
    {
        string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        //lblToolbarMessage.Text = CurrentUrl;
        pnlSendEmail.Visible = true;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        string FromName = txtFrom.Text;
        string ToName = txtTo.Text;

        string FromEmail = txtFromEmail.Text;
        string ToEmail = txtToEmail.Text;

        string Message = txtMessage.Text;
        string Subject = "لینک جالب از طرف " + FromName ;
        string Body = @"با سلام" + "<br>"
        +   " دوست عزیز " + ToName + "<br> فکر میکنم لینک زیر برایت جالب باشد:" + "<br>"
        + CurrentUrl + "<br>"
        + Message + "<br><br>"
        + "پورتال جامع پارسی" + "<br>"
        + "<a href='https://www.decili.ir'>Decili.ir</a>";

        Tools tools = new Tools();
        bool SendResult = tools.SendEmail(Body, Subject, FromEmail, ToEmail,"", "");
        if (SendResult)
        {
            lblMessage.Text = "پیام شما با موفقیت ارسال شد.";
        }
        else
        {
            lblMessage.Text = "متاسفانه در ارسال پیام شما خطایی رخ داده است.";
        }
        pnlMessage.Visible = true;
        pnlSendEmail.Visible = false;
    }

    protected void btnCloseWin_Click(object sender, ImageClickEventArgs e)
    {
        pnlSendEmail.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSendEmail.Visible = false;
    }
}
