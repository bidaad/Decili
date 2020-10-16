using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class Cities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCode = Request["Code"];
            int Code;
            Int32.TryParse(strCode, out Code);
            if (Code != 0)
            {
                BOLCities CitiesBOL = new BOLCities();
                rptCities.DataSource = CitiesBOL.GetStateByProvinceCode(Code);
                rptCities.DataBind();

                BOLProvinces ProvincesBOL = new BOLProvinces();
                lblHeader.Text = "شهرهای استان " + ProvincesBOL.GetNameByCode(Code);
            }



        }
    }
}