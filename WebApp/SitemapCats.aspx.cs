using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class SitemapCats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptCats.DataSource = AdvertisesBOL.GetAllCats();
            rptCats.DataBind();
        }

        public string ShowTitle(Object obj)
        {
            if (obj != null)
            {
                return obj.ToString().Replace("-", " ");
            }
            return "";
        }
    }
}