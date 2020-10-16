using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class FAQ : System.Web.UI.Page
    {
        public int Counter;
        public string strCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Code = Request["Code"];
            if (!string.IsNullOrEmpty(Code))
                strCode = Code.ToString();
            else
                pnlScrollToItem.Visible = false;

            Counter = 1;
            BOLFAQs FAQsBOL = new BOLFAQs();
            rptFAQs.DataSource = FAQsBOL.GetAllFAQs();
            rptFAQs.DataBind();
        }

        protected void rptFAQs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Counter++;
        }
    }
}