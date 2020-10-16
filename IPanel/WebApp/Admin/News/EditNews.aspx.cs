using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Decili.Code.DAL;


public partial class News_EditNews : EditForm<News>
{
    private string BaseID = "News";
    IBaseBOL<News> BaseBOL;



    protected void Page_Load(object sender, EventArgs e)
    {
        #region Tab Pages

        #endregion
        BOLClass = new BOLNews();
        lblSysName.Text = BOLClass.PageLable;

        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            cboHCNewsCatCode.DataSource = new BOLHardCode().GetHCDataTable("HCNewsCats");

            if (!NewMode)
            {
                LoadData((int)Code);
            }
            else
                dteNewsDate.SelectedDateChristian = DateTime.Now;
        }
    }

    protected void DoSave(object sender, EventArgs e)
    {
        try
        {
            int ReturnCode = SaveControls("~/Main/Default.aspx?BaseID=" + BaseID);
            if (NewMode && ReturnCode != -1)
            {
                NewMode = false;
                Code = ReturnCode;
            }
        }
        catch
        {
        }
    }
}
