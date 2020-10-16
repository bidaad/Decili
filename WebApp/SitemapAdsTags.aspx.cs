using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class SitemapAdsTags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int PageNo = 1;
            int PageSize = 50000;

            if (Request["PageNo"] != null)
                PageNo = Convert.ToInt32(Request["PageNo"]);

            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptAdvertises.DataSource = AdvertisesBOL.GetTags(PageNo, PageSize);
            rptAdvertises.DataBind();
        }
    }
}