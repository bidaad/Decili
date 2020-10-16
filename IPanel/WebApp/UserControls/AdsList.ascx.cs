using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_AdsList : System.Web.UI.UserControl
{
    public string strPageNo;
    int PageNo = 1;
    string ConcatUrl;
    string AdClassName = "AdsList";
    int PageSize = 36;
    public string CityCodeParam = "";

    protected string _keyword;


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

    public void ShowTopAds()
    {
        try
        {
            string strCityCode = Request["CityCode"];
            int CityCode;
            Int32.TryParse(strCityCode, out CityCode);
            if (CityCode != 0)
                CityCodeParam = "?CityCode=" + CityCode;

            string strProvinceCode = Request["ProvinceCode"];
            int ProvinceCode;
            Int32.TryParse(strProvinceCode, out ProvinceCode);


            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            if (CityCode != 0 || ProvinceCode != 0)
                dtlAds.DataSource = AdvertisesBOL.GetActiveAdsByNewest(30, CityCode, ProvinceCode);
            else
                dtlAds.DataSource = AdvertisesBOL.GetRatedActiveAds(30, CityCode, ProvinceCode);
            dtlAds.DataBind();
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAdList::ShowTopAds");
        }

    }

    public string ShowBrief(Object obj)
    {
        if (obj != null)
        {
            string Desc = obj.ToString();
            if (Desc.Length > 200)
                return Desc.Substring(0, 200) + "...";
            else
                return Desc;
        }
        else
            return "";
    }

    public string ShowText(Object obj)
    {
        try
        {

            if (obj != null)
            {
                string str = obj.ToString();
                try
                {

                    if (!string.IsNullOrEmpty(_keyword))
                    {
                        string FirstKeyword = _keyword;
                        if (_keyword.IndexOf(" ") != -1)
                        {
                            string[] KeywordArray = _keyword.Split(' ');
                            FirstKeyword = KeywordArray[0];
                        }
                        int FirstKeywordIndex = str.IndexOf(FirstKeyword);
                        if (FirstKeywordIndex > 300)
                        {
                            int StartIndex = FirstKeywordIndex - 150;
                            int StopIndex = FirstKeywordIndex + 150;
                            if (StopIndex > str.Length)
                                StopIndex = str.Length;
                            int CutLen = StopIndex - StartIndex;
                            str = "..." + str.Substring(StartIndex, CutLen) + "...";
                        }
                    }
                }
                catch
                {
                }

                if (str.Length > 300)
                    str = str.Substring(0, 300) + "...";

                if (!string.IsNullOrEmpty(_keyword))
                {
                    _keyword = _keyword.Trim();
                    string[] KeywordArray = _keyword.Split(' ');
                    for (int i = 0; i < KeywordArray.Length; i++)
                    {
                        if (KeywordArray[i].Length > 1)
                            str = str.Replace(KeywordArray[i], "<span class=keyworditem>" + KeywordArray[i] + "</span>");
                    }
                    return str;
                }
                else
                    return str;
            }
            else
                return "";
        }
        catch
        {
            return obj.ToString();
        }

    }


    public void ShowAdsByKeywordCode(int KeywordCode, string Keyword)
    {
        try
        {
            _keyword = Keyword;
            int PageSize = 33;

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
            dtlAds.DataSource = AdvertisesBOL.GetByKeywordCode(KeywordCode, PageNo, PageSize);
            dtlAds.DataBind();

            int ResultCount = AdvertisesBOL.GetByKeywordCodeCount(KeywordCode);

            int PageCount = ResultCount / PageSize;
            if (ResultCount % PageSize > 0)
                PageCount++;

            ConcatUrl += "&Code=" + KeywordCode;

            pgrToolbar.PageNo = PageNo;
            pgrToolbar.PageCount = PageCount;
            pgrToolbar.ConcatUrl = ConcatUrl;
            pgrToolbar.PageBind();
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAdList::ShowAdsByKeyword");
        }

    }
    public void ShowAdsByCatCode(int CatCode)
    {
        try
        {
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

            if (CityCode != 0)
                CityCodeParam = "?CityCode=" + CityCode;

            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            dtlAds.DataSource = AdvertisesBOL.GetByCatCode(CatCode, CityCode, PageNo, PageSize);
            dtlAds.DataBind();

            int ResultCount = AdvertisesBOL.GetByCatCodeCount(CatCode, CityCode);
            if (ResultCount > 0)
            {
                int PageCount = ResultCount / PageSize;
                if (ResultCount % PageSize > 0)
                    PageCount++;

                ConcatUrl = ConcatUrl + "&CatCode=" + CatCode + "&CityCode=" + CityCode;
                StaticPagerToolbar1.PageName = "AdsByCatCode.aspx";
                StaticPagerToolbar1.PagePattern = "~/Cats_P[PageNo]-CC" + CatCode + "-C" + CityCode + ".html";

                StaticPagerToolbar1.PageNo = PageNo;
                StaticPagerToolbar1.PageCount = PageCount;
                StaticPagerToolbar1.ConcatUrl = ConcatUrl;
                StaticPagerToolbar1.PageBind();
            }
            else
                lblMessage.Text = "هنوز هیج آگهی در این گروه قرار نگرفته است.";
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAdList::ShowAdsByCatCode");
        }

    }

    public void ShowAdsByUserCode(int UserCode)
    {
        try
        {
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
            string strID = Request["ID"];

            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            dtlAds.DataSource = AdvertisesBOL.GetByUserCode(UserCode, PageNo, PageSize);
            dtlAds.DataBind();

            int ResultCount = AdvertisesBOL.GetByUserCodeCount(UserCode);
            if (ResultCount > 0)
            {
                int PageCount = ResultCount / PageSize;
                if (ResultCount % PageSize > 0)
                    PageCount++;

                ConcatUrl = ConcatUrl + "&CatCode=" + UserCode;
                StaticPagerToolbar1.PageName = "AdverByUserCode.aspx";
                StaticPagerToolbar1.PagePattern = "~/Users/P[PageNo]-" + strID + ".html";

                StaticPagerToolbar1.PageNo = PageNo;
                StaticPagerToolbar1.PageCount = PageCount;
                StaticPagerToolbar1.ConcatUrl = ConcatUrl;
                StaticPagerToolbar1.PageBind();
            }
            else
                lblMessage.Text = "هنوز هیج آگهی در این گروه قرار نگرفته است.";
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAdList::ShowAdsByCatCode");
        }

    }


    public string ShowDeci(Object obj)
    {
        string Result = "";
        if (obj != null)
        {
            int DeciCount = Convert.ToInt32(obj);
            if (DeciCount > 0)
            {
                Result = "<div class=\"fa fa-diamond DeciIconAds\">&nbsp;<span>" + Tools.ChangeEnc(obj.ToString()) + "</span></div>";
            }
        }
        return Result;
    }

    public void ShowAdsByNewsCode(int NewsCode)
    {
        try
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
            dtlAds.DataSource = AdvertisesBOL.GetRelatedNews(NewsCode, PageNo, PageSize);
            dtlAds.DataBind();

            int ResultCount = AdvertisesBOL.GetByKeywordCodeCount(NewsCode);

            int PageCount = ResultCount / PageSize;
            if (ResultCount % PageSize > 0)
                PageCount++;

            pgrToolbar.PageNo = PageNo;
            pgrToolbar.PageCount = PageCount;
            pgrToolbar.ConcatUrl = ConcatUrl;
            pgrToolbar.PageBind();

            AdClassName = "AdsListSmall";
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAdList::ShowAdsByNewsCode");
        }


    }
    public string ShowAdClass()
    {
        return AdClassName;
    }

    public void SearchAds(string Keyword, out int? SuggestedCatCode)
    {
        _keyword = Keyword;
        SuggestedCatCode = null;
        try
        {
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
            int ResultCount = 0;
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            dtlAds.DataSource = AdvertisesBOL.DoSearch(PageSize, 1, Keyword, out ResultCount, out SuggestedCatCode);
            dtlAds.DataBind();

            //        int ResultCount = AdvertisesBOL.GetSearchCount(Keyword);
            if (ResultCount > 0)
            {
                Page.Title = Keyword;

                StaticPagerToolbar1.PageName = "Search.aspx";
                StaticPagerToolbar1.PagePattern = "~/s[PageNo]-" + Keyword + ".html";
                int PageCount = ResultCount / PageSize;
                if (ResultCount % PageSize > 0)
                    PageCount++;
                StaticPagerToolbar1.PageNo = PageNo;
                StaticPagerToolbar1.PageCount = PageCount;
                StaticPagerToolbar1.ConcatUrl = ConcatUrl;
                StaticPagerToolbar1.PageBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SwitchToList", "$(document).ready(function () {        $('.listbtn').click();});", true);
            }
            else
            {
                msg.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Warning;
                msg.Text = "هیچ نتیجه‌ای برای " + Keyword + " پیدا نشد.";
            }

            string UserAgent = HttpContext.Current.Request.UserAgent;

            if (!Tools.GetCrawelerUserAgents().Contains(UserAgent))
            {
                BOLKeywords KeywordsBOL = new BOLKeywords();
                KeywordsBOL.AddToSearchedKeywords(Keyword, ResultCount);
            }

        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAdList::SearchAds");
        }

    }

    public string ShowUrl(Object obj)
    {
        string strUrl = obj.ToString();
        if (!string.IsNullOrEmpty(_keyword))
        {
            strUrl += "?Keyword=" + _keyword;
            return strUrl;
        }
        else
            return strUrl;
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
                case 1:
                    Result = "FreeAd";
                    break;
                case 10:
                    Result = "SpAd";
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
                    Result = "FreeAd";
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