using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
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
            Response.Redirect("~/Default.aspx?Logout=1");
        }
    }
}