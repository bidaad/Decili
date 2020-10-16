using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class SiteMapTitlesSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int PageNo = 1;
            int PageSize = 25000;

            if (Request["PageNo"] != null)
                PageNo = Convert.ToInt32(Request["PageNo"]);

            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptAdvertises.DataSource = AdvertisesBOL.GetTitles(PageNo, PageSize);
            rptAdvertises.DataBind();
        }

        public string CorrectKey(Object obj)
        {
            string str = obj.ToString();
            str = str.Replace(",", " ");
            str = str.Replace("*", " ");
            str = str.Replace("(", " ");
            str = str.Replace(")", " ");
            str = str.Replace("[", " ");
            str = str.Replace("]", " ");
            str = str.Replace("/", " ");
            str = str.Replace("@", " ");
            str = str.Replace(":", " ");
            str = str.Replace("]", " ");
            int Counter = 0;
            str = str.Trim();
            while (str.IndexOf("  ") > 0 && Counter < 20)
            {
                str = str.Replace("  ", " ");
                Counter++;
            }
            return str;
                
        }
    }
}