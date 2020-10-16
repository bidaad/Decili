using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_MessageBox : System.Web.UI.UserControl
{
    public string Text
    {
        get
        {
            return lblMessage.Text;
        }
        set
        {
            try
            {
                this.Visible = true;
                lblMessage.Text = value;
                //ltrScript.Text = "<script type=\"text/javascript\">alert(111);</script>";
                ((UpdatePanel)Page.FindControl("UpdatePanel1")).Update();
            }
            catch
            {
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (lblMessage.Text == "")
            this.Visible = false;
    }
}
