using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class AdsCatSubMenu : System.Web.UI.UserControl
    {
        protected int _masterCode;
        public int MasterCode
        {
            get
            {
                return _masterCode;
            }
            set
            {
                _masterCode = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptMenuItems.DataSource = AdvertisesBOL.GetAdvertiseCatsByMasterCode(_masterCode);
            rptMenuItems.DataBind();
        }
    }
}