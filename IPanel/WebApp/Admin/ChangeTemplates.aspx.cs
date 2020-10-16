using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;

public partial class Admin_ChangeTemplates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadTemplate(1);
        }

    }
    protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SelectedVal = Convert.ToInt32(ddlTemplates.SelectedValue);
        LoadTemplate(SelectedVal);
    }

    private void LoadTemplate(int SelectedVal)
    {
        UtilDataContext dc = new UtilDataContext();
        EmailTemplates CurTemplate = dc.EmailTemplates.SingleOrDefault(p => p.Code.Equals(SelectedVal));
        if (CurTemplate != null)
            txtTemplate.Text = CurTemplate.Template;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int SelectedVal = Convert.ToInt32(ddlTemplates.SelectedValue);
        UtilDataContext dc = new UtilDataContext();
        EmailTemplates CurTemplate = dc.EmailTemplates.SingleOrDefault(p => p.Code.Equals(SelectedVal));
        if (CurTemplate == null)
            CurTemplate = new EmailTemplates();
        CurTemplate.Template = txtTemplate.Text;
        dc.SubmitChanges();

    }
}
