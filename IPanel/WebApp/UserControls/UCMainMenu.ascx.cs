using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        public string CityCode;
        public string strCatHirarchy = "";

        public MainMenu()
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();

            string strCatCode = Request["CatCode"];
            CityCode = Request["CityCode"];
            if (!string.IsNullOrEmpty(CityCode))
                CityCode = "_" + CityCode;
            int CatCode;
            Int32.TryParse(strCatCode, out CatCode);
            if (CatCode != 0)
            {

                rptRootCats.DataSource = AdvertisesBOL.GetAdvertiseCatsByMasterCode(CatCode);
                rptRootCats.DataBind();
                GenCatHirarchy(CatCode);
                //AdsCatSubMenu1.MasterCode = CatCode;
                strCatHirarchy += "<li><a href='/'>دسیلی</a></li>";
            }
            else
            {
                rptRootCats.DataSource = AdvertisesBOL.GetAdvertiseCatsByMasterCode(null);
                rptRootCats.DataBind();
                pnlCatHir.Visible = false;
            }

            //AdsCatSubMenu1.Visible = false;



        }


        public void GenCatHirarchy(int? CatCode)
        {
            if(CatCode != null)
            {
                BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                string CatName = AdvertisesBOL.GetCatNameByCode((int)CatCode);
                strCatHirarchy += "<li><a href='" + Page.ResolveUrl("~/Cats_" + CatName + "-" + CatCode + ".html") + "'>" + CatName.Replace("-", " ") + "</a>&nbsp;&nbsp;«&nbsp;&nbsp;</li>";
                int? MasterCatCode = AdvertisesBOL.GetMasterCatCode(CatCode);
                GenCatHirarchy(MasterCatCode);
            }
        }

        public string ShowTitle(Object obj)
        {
            if (obj != null)
            {
                return obj.ToString().Replace("-", " ");
            }
            return "";
        }

        protected void rptWorkGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


    }
}