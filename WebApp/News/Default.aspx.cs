using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.NewsFolder
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConcatUrl = "";
            int PageNo = 1;
            int PageSize = 20;

            string strPageNo = Request["PageNo"];
            if (strPageNo != "" && strPageNo != null)
                PageNo = Convert.ToInt32(strPageNo);

            BOLNews NewsBOL = new BOLNews();
            int PageCount = NewsBOL.GetNewsCount() / PageSize;

            rptNews.DataSource = NewsBOL.GetLatestNews(PageNo, PageSize);
            rptNews.DataBind();

            pgrToolbar.PageNo = PageNo;
            pgrToolbar.PageCount = PageCount;
            pgrToolbar.ConcatUrl = ConcatUrl;
            pgrToolbar.PageBind();
        }

        public string ShowDate(Object objDate)
        {
            string Result = "";
            if (objDate != null)
            {
                DateTimeMethods dtm = new DateTimeMethods();
                Result = dtm.GetPersianDate((DateTime)objDate);
            }
            return Result;
        }
    }
}