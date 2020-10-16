using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;

public partial class UserControls_UserTools : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserCode"] != null)
        {
            int UserCode = Convert.ToInt32(Session["UserCode"]);
            BOLUsers UsersBOL = new BOLUsers();
            Users CurUser = ((IBaseBOL<Users>)UsersBOL).GetDetails(UserCode);
            int AccountBalance = 0;
            lblAccountBalance.Text = Tools.FormatCurrency(Tools.ChageEnc(AccountBalance.ToString()));
        }

    }
}
