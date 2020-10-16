using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.Admin.AccessLevel
{
    public partial class UserTransList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int PageSize = 20;

            int PageNo = 1;
            string strPageNo = Request["PageNo"];
            try
            {
                PageNo = Convert.ToInt32(strPageNo);
            }
            catch
            {
            }
            if (PageNo == 0)
                PageNo = 1;

            string ConcatUrl = "";
            BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(1);
            rptUserTransactions.DataSource = UserTransactionsBOL.GetAll(PageNo, PageSize);
            rptUserTransactions.DataBind();

            int ResultCount = UserTransactionsBOL.GetAllCount();

            int PageCount = ResultCount / PageSize;
            if (ResultCount % PageSize > 0)
                PageCount++;

            pgrToolbar.PageNo = PageNo;
            pgrToolbar.PageCount = PageCount;
            pgrToolbar.ConcatUrl = ConcatUrl;
            pgrToolbar.PageBind();

        }
    }
}