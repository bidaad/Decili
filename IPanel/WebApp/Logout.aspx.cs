using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["Decili"].Expires = DateTime.Now;
            Response.Cookies["Decili"]["DeciliUser"] = "";

            Response.Cookies["Decili"].Expires = DateTime.Now;
            Response.Cookies["Decili"]["DeciliPass"] = "";

            Session.Abandon();
            Response.Redirect("https://www.Decili.ir/Default.aspx?Logout=1");

            Session.Abandon();

            //Response.Redirect("~/");
        }
    }
}