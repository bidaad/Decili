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

public partial class ajxDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string BaseID = Request["BaseID"];
        string Code = Request["Code"];
        string MasterCode = Request["MasterCode"];
        try
        {
            if (Code != null)
            {
                IBaseBOL BOLClass;
                BOLClass = Tools.GetBOLClass(BaseID, Convert.ToInt32(MasterCode));

                BOLClass.DeleteRecord(Code);
                Response.Write("Success");
            }
        }
        catch (Exception e1)
        {
            Response.Write(e1.Message);
        }
    }
}
