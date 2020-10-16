using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class Provinces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLProvinces ProvincesBOL = new BOLProvinces();
            rptProvinces.DataSource = ProvincesBOL.GetAll();
            rptProvinces.DataBind();

        }
    }
}