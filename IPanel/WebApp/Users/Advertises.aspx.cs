using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Advertises : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserCode"] == null)
            Response.Redirect("~/Users/Login.aspx");


        int UserCode = Convert.ToInt32(Session["UserCode"]);
        BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        rptAdvertises.DataSource = AdvertisesBOL.GetAdverByUserCode(UserCode);
        rptAdvertises.DataBind();

        if (rptAdvertises.Items.Count == 0)
            rptAdvertises.Visible = false;

    }
}