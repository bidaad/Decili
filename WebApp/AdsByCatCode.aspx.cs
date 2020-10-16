using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ads_AdsByCatCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strCatCode = Request["CatCode"];
            int CatCode;

            Int32.TryParse(strCatCode, out CatCode);
            if (CatCode != 0)
            {
                int PageNo = 1;
                string strPageNo = Request["PageNo"];
                try
                {
                    PageNo = Convert.ToInt32(strPageNo);
                }
                catch
                {
                }
                if (PageNo == 0)
                    PageNo = 1;
                string strCityCode = Request["CityCode"];
                int CityCode;
                Int32.TryParse(strCityCode, out CityCode);


                AdsList1.ShowAdsByCatCode(CatCode);

                BOLAdvertises AdvertisesBOL = new BOLAdvertises();

                string CatName = AdvertisesBOL.GetCatNameByCode(CatCode);
                CatName = CatName.Replace("-", " ");
                SearchWords1.ShowKeywordByCatCode(CatCode, CatName);
                
                if (CatName != null)
                {
                    if (CityCode == 0)
                    {
                        Page.Title = lblHeader.Text = CatName + " صفحه " + Tools.ChangeEnc(PageNo.ToString());
                        Tools.SetMeta("description", CatName);
                        Tools.SetMeta("keywords", CatName);
                    }
                    else
                    {
                        BOLCities CitiesBOL = new BOLCities();
                        string CityName = CitiesBOL.GetNameByCode(CityCode);
                        Tools.SetMeta("description", CatName + " " + CityName);
                        Tools.SetMeta("keywords", CatName + " " + CityName);

                        Page.Title = lblHeader.Text = CatName + " " + CityName + " صفحه " + Tools.ChangeEnc(PageNo.ToString());
                    }

                }

                int? MasterCatCode = AdvertisesBOL.GetMasterCatCode(CatCode);
                if (MasterCatCode != null)
                {
                    string MasterCatName = AdvertisesBOL.GetCatNameByCode((int)MasterCatCode);
                    SearchWordsParent.ShowKeywordByCatCode((int)MasterCatCode, MasterCatName);

                }
                else
                    SearchWordsParent.Visible = false;

                LatestAds.ShowLatestAds(CatCode);

            }

        }
        catch (Exception e1)
        {
            //Response.Write(e1.Message);
        }
    }
}