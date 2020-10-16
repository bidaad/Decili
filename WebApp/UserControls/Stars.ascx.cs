using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_Stars : System.Web.UI.UserControl
{
    protected string _starCount;
    public string StarCount
    {
        get
        {
            return _starCount;
        }
        set
        {
            _starCount = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("Num");
        dt.Columns.Add(dc);
        DataRow dr;

        DataTable dt2 = new DataTable();
        DataColumn dc2 = new DataColumn("Num");
        dt2.Columns.Add(dc2);
        DataRow dr2;
        int SCount = Convert.ToInt32(_starCount);

        for (int j = 1; j <= SCount; j++)
        {
            dr = dt.NewRow();
            dr["Num"] = "1";
            dt.Rows.Add(dr);
        }
        rptStars.DataSource = dt;
        rptStars.DataBind();

        for (int j = SCount + 1; j <= 5; j++)
        {
            dr2 = dt2.NewRow();
            dr2["Num"] = "1";
            dt2.Rows.Add(dr2);
        }
        rptOffstars.DataSource = dt2;
        rptOffstars.DataBind();

        
    }
}
