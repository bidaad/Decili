using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SmallAdsList : System.Web.UI.UserControl
{
    public string strPageNo;
    int PageNo = 1;
    string ConcatUrl;
    int PageCount = 20;
    int PageSize = 36;
    string AdClassName = "ColSmallAdsList";
    public string CityCodeParam = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string ShowAdClass()
    {
        return AdClassName;
    }
    public void ShowAdsByCatCode(int CatCode, int AdsCode, int? AdsCityCode)
    {
        try
        {
            strPageNo = Request["PageNo"];

            PageNo = Convert.ToInt32(strPageNo);

            if (PageNo == 0)
                PageNo = 1;
            string strCityCode = Request["CityCode"];
            int CityCode;
            Int32.TryParse(strCityCode, out CityCode);
            if (CityCode != 0)
                CityCodeParam = "?CityCode=" + CityCode;

            if (CityCode == 0)
            {
                if(AdsCityCode != null)
                    CityCode = (int)AdsCityCode;
            }

            string strID = Request["ID"];

            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptAds.DataSource = AdvertisesBOL.GetLatestFreeAds(CatCode, PageNo, PageSize, AdsCode, CityCode);
            rptAds.DataBind();
            if (rptAds.Items.Count == 0)
                this.Visible = false;

            int ResultCount = AdvertisesBOL.GetLatestFreeAdsCount(CatCode, AdsCode, CityCode);

            PageCount = ResultCount / PageSize;
            if (ResultCount % PageSize > 0)
                PageCount++;

            ConcatUrl = ConcatUrl + "&ID=" + strID + "&CityCode=" + CityCode; ;
            StaticPagerToolbar1.PageName = "ShowAds.aspx";
            StaticPagerToolbar1.PagePattern = "~/P[PageNo]-C" + CityCode + "-ID" + strID + ".html";

            StaticPagerToolbar1.PageNo = PageNo;
            StaticPagerToolbar1.PageCount = PageCount;
            StaticPagerToolbar1.ConcatUrl = ConcatUrl;
            StaticPagerToolbar1.PageBind();

            //BOLHardCode HardCodeBOL = new BOLHardCode();
            //HardCodeBOL.TableOrViewName = "HCAdvertiseCats";
            //string CatName = HardCodeBOL.GetNameByCode(CatCode);

            string CatName = AdvertisesBOL.GetCatNameByCode(CatCode);
            if (string.IsNullOrEmpty(CatName))
                lblColHeader.Text = "";
            else
            {
                lblColHeader.Text = "آگهی های " + CatName.Replace("-", " ");
                if (CityCode != 0)
                {
                    BOLCities CitiesBOL = new BOLCities();
                    lblColHeader.Text += " " + CitiesBOL.GetNameByCode(CityCode);
                }
            }
        }
        catch (Exception err)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(err.Message, DateTime.Now, Request.Url.AbsolutePath, "UCSmallAdsList::ShowAdsByCatCode");
        }
    }

    public string ShowDeci(Object objRate)
    {
        string Result = "";
        if (objRate != null)
        {
            int DeciCount = Convert.ToInt32(objRate);
            if (DeciCount > 0)
            {
                Result = @"<div class=""fa fa-diamond DecilIcon2"">&nbsp;<span class=""DeciCount"">" + Tools.ChangeEnc(DeciCount.ToString()) + "</span></div>&nbsp;";
            }
        }

        return Result;
    }

    public string ShowPrettyDate(Object obj)
    {
        string Result = "";
        if (obj != null)
        {
            DateTime dt = Convert.ToDateTime(obj);
            Result = Tools.GetPrettyDate(dt);
            Result = Tools.ChangeEnc(Result);
        }
        return Result;
    }

    public void ShowAdsByNewsCode(int NewsCode)
    {
        int PageSize = 20;

        strPageNo = Request["PageNo"];
        try
        {
            PageNo = Convert.ToInt32(strPageNo);
        }
        catch
        {
        }
        if (PageNo == 0)
            PageNo = 1;
        BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        rptAds.DataSource = AdvertisesBOL.GetRelatedNews(NewsCode, PageNo, PageSize);
        rptAds.DataBind();

        int ResultCount = AdvertisesBOL.GetByKeywordCodeCount(NewsCode);

        int PageCount = ResultCount / PageSize;
        if (ResultCount % PageSize > 0)
            PageCount++;

        pgrToolbar.PageNo = PageNo;
        pgrToolbar.PageCount = PageCount;
        pgrToolbar.ConcatUrl = ConcatUrl;
        pgrToolbar.PageBind();

        AdClassName = "ColSmallAdsListNews";

    }

}