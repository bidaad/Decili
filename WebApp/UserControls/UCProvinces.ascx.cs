using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCProvinces : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLProvinces ProvincesBOL = new BOLProvinces();
            rptProvinces.DataSource = ProvincesBOL.GetAll();
            rptProvinces.DataBind();

        }
    }
}