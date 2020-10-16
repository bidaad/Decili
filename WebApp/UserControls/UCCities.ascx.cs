using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCCities : System.Web.UI.UserControl
    {
        protected int _provinceCode;
        public int ProvinceCode
        {
            get
            {
                return _provinceCode;
            }
            set
            {
                _provinceCode = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //string strProvinceCode = Request["ProvinceCode"];
            //int ProvinceCode;
            //Int32.TryParse(strProvinceCode, out ProvinceCode);
            if (_provinceCode != 0)
            {
                BOLCities CitiesBOL = new BOLCities();
                rptCities.DataSource = CitiesBOL.GetStateByProvinceCode(ProvinceCode);
                rptCities.DataBind();

                BOLProvinces ProvincesBOL = new BOLProvinces();
                ltrHeader.Text = ProvincesBOL.GetNameByCode(ProvinceCode);
            }

        }
    }
}