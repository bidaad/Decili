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

public partial class HardCode_HardCodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ResourceName = Request["ResourceName"];
        BOLResources ReourseBOL = new BOLResources();
        int? ResourceCode = ReourseBOL.GetCodeByEngName(ResourceName);
        if (ResourceCode != null)
        {
            dlHardCodes.DataSource = ReourseBOL.GetByMasterCode((int)ResourceCode);
            dlHardCodes.DataBind();
        }
    }
}
