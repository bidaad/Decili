using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;

public partial class UserControls_ColAds : System.Web.UI.UserControl
{
    public string strPageNo;
    int PageNo = 1;
    string ConcatUrl;
    int PageSize = 20;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string ShowTel(Object obj)
    {
        if (obj != null)
        {
            string Tel = obj.ToString();
            if (!string.IsNullOrEmpty(Tel))
            {
                return "تلفن: " + Tools.ChangeEnc(Tel);
            }
        }
        return "";
    }

    public string ShowName(Object obj)
    {
        if (obj != null)
        {
            return "نام: " + obj.ToString();
        }
        return "";
    }

    public void ShowAdsByUser(int UserCode, int CurAdsCode)
    {
        try{
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
        dtlAds.DataSource = AdvertisesBOL.GetByUserCode(UserCode, 3, PageNo, PageSize, CurAdsCode);
        dtlAds.DataBind();

        if (dtlAds.Items.Count == 0)
        {
            this.Visible = false;
            return;
        }

        int ResultCount = AdvertisesBOL.GetByUserCodeCount(UserCode);

        int PageCount = ResultCount / PageSize;
        if (ResultCount % PageSize > 0)
            PageCount++;

        BOLUsers UsersBOL = new BOLUsers();
        Users CurAdsUser = ((IBaseBOL<Users>)UsersBOL).GetDetails(UserCode);
        hplColHeader.Text = "آگهی های دیگر " + CurAdsUser.FirstName + " " + CurAdsUser.LastName;
        hplColHeader.NavigateUrl = "~/Users/P1-" + CurAdsUser.ID + ".html";
        if (dtlAds.Items.Count == 0)
            this.Visible = false;
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCColAds::ShowAdsByUser");
        }



    }
    public void ShowRelatedAds(int AdsCode)
    {
        try{
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
        dtlAds.DataSource = AdvertisesBOL.ShowRelatedAds(AdsCode, 5);
        dtlAds.DataBind();

        int ResultCount = 10;// AdvertisesBOL.ShowRelatedAdsCount(AdsCode);

        int PageCount = ResultCount / PageSize;
        if (ResultCount % PageSize > 0)
            PageCount++;

        hplColHeader.Text = "آگهی های مرتبط ";
        if (dtlAds.Items.Count == 0)
            this.Visible = false;
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCColAds::ShowRelatedAds");
        }


    }

    public void ShowLatestAds(int? CatCode)
    {
        try{
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

        string strCityCode = Request["CityCode"];
        int CityCode;
        Int32.TryParse(strCityCode, out CityCode);



        BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        dtlAds.DataSource = AdvertisesBOL.GetLatestFreeAds(CatCode, 10, CityCode);
        dtlAds.DataBind();

        int ResultCount = 20;

        int PageCount = ResultCount / PageSize;
        if (ResultCount % PageSize > 0)
            PageCount++;

        hplColHeader.Text = "جدیدترین آگهی ها";
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCColAds::ShowLatestAds");
        }



    }


    public string ShowRateClass(object objRate)
    {
        string Result = "";
        try
        {
            if (objRate == null)
                return "";
            int Rate;
            Int32.TryParse(objRate.ToString(), out Rate);
            switch (Rate)
            {
                case 10:
                    Result = "NoStars";
                    break;
                case 20:
                    Result = "Star1";
                    break;
                case 30:
                    Result = "Stars2";
                    break;
                case 40:
                    Result = "Stars3";
                    break;
                case 50:
                    Result = "Stars4";
                    break;
                case 60:
                    Result = "Stars5";
                    break;
                case 70:
                    Result = "Stars6";
                    break;
                case 80:
                    Result = "Stars7";
                    break;
                default:
                    Result = "NoStars";
                    break;
            }
            return Result;

        }
        catch
        {
            return "";
        }
    }

}