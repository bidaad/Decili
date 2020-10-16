using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Iran24.UserControls
{
    public partial class NewsBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLNews NewsBOL = new BOLNews();
            rptNews.DataSource = NewsBOL.GetLatestNews(17);
            rptNews.DataSource = NewsBOL.GetRandomNews();
            rptNews.DataBind();
        }
    }
}