using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using Decili.Code.DAL;
using System.Data.Linq;


public class BOLAdvertises : BaseBOLAdvertises, IBaseBOL<Advertises>
{
    public IList CheckBusinessRules()
    {
        var messages = new List<string>();

        #region Business Rules

        #endregion
        return messages;
    }


    public int? InsertAdvertise(int UserCode, string Title, string Description, string Name, string Tel, int CatCode, int HCDurationCode, int? HCStateCode, string Price, string SmallPic, string LargePic, bool ShowContactAdvetiserWin, string Address, int? CityCode, string Link)
    {
        try
        {
            if (Description.Length > 8000)
                Description = Description.Substring(0, 8000);

            Advertises NewAd = new Advertises();
            NewAd.Title = Title;
            NewAd.Description = Description;
            NewAd.Name = Name;
            NewAd.Tel = Tel;
            NewAd.CatCode = CatCode;
            NewAd.HCAdvertiseStatusCode = HCAdvertiseStatusCode;
            NewAd.HCDurationCode = HCDurationCode;
            NewAd.CreateDate = DateTime.Now;
            NewAd.UserCode = UserCode;
            NewAd.Price = Price;
            NewAd.SmallPicFile = SmallPic;
            NewAd.LargePicFile = LargePic;
            NewAd.ViewCount = 0;
            NewAd.ShowContactAdvetiserWin = ShowContactAdvetiserWin;
            NewAd.Address = Address;
            NewAd.CityCode = CityCode;
            NewAd.UpdateDate = DateTime.Now;
            NewAd.Link = Link;
            NewAd.LinkActivated = false;

            int AddDay = 0;
            switch (HCDurationCode)
            {
                case 1:
                    AddDay = 7;
                    break;
                case 2:
                    AddDay = 30;
                    break;
                case 3:
                    AddDay = 60;
                    break;
                case 4:
                    AddDay = 10000;
                    break;
                default:
                    break;
            }
            NewAd.ExpDate = DateTime.Now.AddDays(AddDay);
            NewAd.HCAdvertiseStatusCode = 1;
            Tools tools = new Tools();
            NewAd.ID = Tools.GetRandID();

            dataContext.Advertises.InsertOnSubmit(NewAd);
            dataContext.SubmitChanges();
            return NewAd.Code;
        }
        catch
        {
            return null;
        }
    }

    public object GetAdvertiseCatsByMasterCode(int? MasterCode)
    {
        string strConcatCode = "";
        if (MasterCode == null)
            strConcatCode = "";
        else
            strConcatCode = MasterCode.ToString();

        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetAdvertiseCatsByMasterCode" + strConcatCode] == null)
        {
            IQueryable<AdvertiseCats> Result;
            if (MasterCode == null)
                Result = dataContext.AdvertiseCats.Where(p => p.MasterCode == null).OrderBy(p => p.ShowOrder);
            else
                Result = dataContext.AdvertiseCats.Where(p => p.MasterCode.Equals(MasterCode));
            context.Cache.Insert("GetAdvertiseCatsByMasterCode" + strConcatCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<AdvertiseCats>)context.Cache["GetAdvertiseCatsByMasterCode" + strConcatCode];

        //if (MasterCode == null)
        //    return dataContext.AdvertiseCats.Where(p => p.MasterCode == null).OrderBy(p => p.ShowOrder);
        //else
        //    return dataContext.AdvertiseCats.Where(p => p.MasterCode.Equals(MasterCode));
    }

    internal int GetAdsCountByUserCode(int Code)
    {
        return dataContext.Advertises.Where(p => p.UserCode.Equals(Code)).Count();
    }

    public bool EditAdvertise(int AdsCode, string Title, string Description, string Name, string Tel, int CatCode, int HCDurationCode, int? HCStateCode, string Price, string SmallPic, string LargePic, bool ShowContactAdvetiserWin, int? CityCode, string Address, string Link)
    {
        try
        {
            Advertises CurrentAd = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(AdsCode));
            if (CurrentAd == null)
                return false;
            CurrentAd.Title = Title;
            CurrentAd.Description = Description;
            CurrentAd.Name = Name;
            CurrentAd.Tel = Tel;
            CurrentAd.CatCode = CatCode;
            CurrentAd.HCAdvertiseStatusCode = HCAdvertiseStatusCode;
            CurrentAd.HCDurationCode = HCDurationCode;
            CurrentAd.Price = Price;
            CurrentAd.SmallPicFile = SmallPic;
            CurrentAd.LargePicFile = LargePic;
            CurrentAd.ShowContactAdvetiserWin = ShowContactAdvetiserWin;
            CurrentAd.CityCode = CityCode;
            CurrentAd.Address = Address;
            CurrentAd.Link = Link;

            CurrentAd.HCAdvertiseStatusCode = 4;//اصلاح شده - منتظر تایید

            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public object GetAdverByUserCode(int UserCode)
    {
        return dataContext.vAdvertises.Where(p => p.UserCode.Equals(UserCode)).OrderByDescending(p => p.UpdateDate);
    }

    public List<string> GetAdverKeywords(int Code)
    {
        List<String> KeyList = new List<String>();

        var KeywordList = dataContext.vAdvertiseKeywords.Where(p => p.AdvertiseCode.Equals(Code));
        foreach (var item in KeywordList)
        {
            KeyList.Add(item.Keyword);
        }
        return KeyList;
    }

    internal void InsertUpdate(int Code)
    {
        try
        {
            AdvertiseUpdateLogs NewLog = new AdvertiseUpdateLogs();
            NewLog.AdvertiseCode = Code;
            NewLog.UpdateDate = DateTime.Now;
            dataContext.AdvertiseUpdateLogs.InsertOnSubmit(NewLog);
            dataContext.SubmitChanges();
        }
        catch
        {
        }
    }

    public IQueryable<vAdvertiseKeywords> GetAdverKeywordsFull(int Code)
    {

        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetAdverKeywordsFull" + Code] == null)
        {
            IQueryable<vAdvertiseKeywords> Result = dataContext.vAdvertiseKeywords.Where(p => p.AdvertiseCode.Equals(Code)).OrderBy(p => p.Keyword.Length);
            context.Cache.Insert("GetAdverKeywordsFull" + Code, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<vAdvertiseKeywords>)context.Cache["GetAdverKeywordsFull" + Code];

        //IQueryable<vAdvertiseKeywords> KeywordList = dataContext.vAdvertiseKeywords.Where(p => p.AdvertiseCode.Equals(Code)).OrderBy(p => p.Keyword.Length);
        //return KeywordList;
    }

    public object GetActiveAdsByRate(int TakeCount)
    {
        return dataContext.vActiveAdvertises.OrderByDescending(p => p.Rate).Take(TakeCount);
    }

    public object GetActiveAdsByNewest(int TakeCount, int CityCode, int ProvinceCode)
    {

        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetActiveAdsByNewest" + TakeCount + "-" + CityCode + "-" + ProvinceCode] == null)
        {
            IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises;
            if (CityCode != 0)
                Result = Result.Where(p => p.CityCode.Equals(CityCode));
            if (ProvinceCode != 0)
                Result = Result.Where(p => p.ProvinceCode.Equals(ProvinceCode));
            Result = Result.OrderByDescending(p => p.Code).Take(TakeCount);

            context.Cache.Insert("GetActiveAdsByNewest" + TakeCount + "-" + CityCode + "-" + ProvinceCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<vActiveAdvertises>)context.Cache["GetActiveAdsByNewest" + TakeCount + "-" + CityCode + "-" + ProvinceCode];


        //IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises;
        //if(CityCode != 0)
        //    Result = Result.Where(p => p.CityCode.Equals(CityCode));
        //if (ProvinceCode != 0)
        //    Result = Result.Where(p => p.ProvinceCode.Equals(ProvinceCode));
        //Result = Result.OrderByDescending(p => p.Code).Take(TakeCount);

        //return Result;
    }


    public object DoSearch(int PageSize, int PageNo, string Keyword, out int ResultCount, out int? ResultCatCode)
    {
        ResultCatCode = null;
        string SqlStr = "";
        PagedDataSource objPds = new PagedDataSource();

        Keyword = Keyword.Trim();

        if (Keyword.IndexOf(" ") == -1)
        {
            string WhereClause = Tools.MakeWhereClause(Keyword, "Title,Description");

            if (WhereClause.StartsWith("AND "))
                WhereClause = WhereClause.Substring(4, WhereClause.Length - 4);

            SqlStr = "SELECT TOP 200 * from Advertises where " + WhereClause + "ORDER BY Advertises.Rate desc, dbo.Advertises.UpdateDate DESC";
        }
        else//multiple keywords
        {
            while (Keyword.IndexOf("  ") > 0)
            {
                Keyword = Keyword.Replace("  ", " ");
            }
            string NEARClause = "";
            string[] KeywordArray = Keyword.Split(' ');
            for (int i = 0; i < KeywordArray.Length; i++)
            {
                if (NEARClause == "")
                    NEARClause = KeywordArray[0];
                else
                    NEARClause += " NEAR " + KeywordArray[i];
            }
            SqlStr = @"SELECT        FT_TBL.Code, FT_TBL.Description, KEY_TBL.RANK, dbo.Advertises.Title,  dbo.Advertises.Name, dbo.Advertises.Tel, dbo.Advertises.Address, dbo.Advertises.Rate, 
                         dbo.Advertises.SmallPicFile, dbo.Advertises.ID, FT_TBL.CatCode
                        FROM            dbo.Advertises AS FT_TBL INNER JOIN
                                                    CONTAINSTABLE(Advertises, Description, '(" + NEARClause + @")', 200) AS KEY_TBL ON FT_TBL.Code = KEY_TBL.[KEY] INNER JOIN
                                                    dbo.Advertises ON FT_TBL.Code = dbo.Advertises.Code
                        WHERE        (KEY_TBL.RANK > 10) order by Rate desc, KEY_TBL.RANK desc";
        }
        
        DataTable dt = Tools.DoSearchSiteQuery(SqlStr);

        if (dt.Rows.Count == 0)//Search Again :: Simple Search
        {
            string WhereClause = Tools.MakeWhereClause(Keyword, "Title,Description");

            if (WhereClause.StartsWith("AND "))
                WhereClause = WhereClause.Substring(4, WhereClause.Length - 4);

            SqlStr = "SELECT     TOP 100 * from Advertises where " + WhereClause + "ORDER BY Advertises.Rate desc, dbo.Advertises.UpdateDate DESC";
            dt = Tools.DoSearchSiteQuery(SqlStr);
        }

        ResultCount = dt.Rows.Count;

        if (ResultCount > 0)
        {
            ArrayList ARCatList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ARCatList.Add(Convert.ToInt32( dt.Rows[i]["CatCode"]));
            }

            //List<int> list = ARCatList.Cast<int>();
            var query = from i in ARCatList.Cast<int>()
                        group i by i into g
                        select new {g.Key, Count = g.Count()};

            // compute the maximum frequency
            int whatsTheFrequencyKenneth = query.Max(g => g.Count);

            // find the values with that frequency
            IEnumerable<int> modes = query
                              .Where(g => g.Count == whatsTheFrequencyKenneth)
                              .Select(g => g.Key).Take(2);
            ResultCatCode = modes.First();
        }


        objPds.DataSource = dt.DefaultView;
        objPds.AllowPaging = true;
        objPds.PageSize = PageSize;
        objPds.CurrentPageIndex = PageNo - 1;

        return objPds;
    }

    public int GetSearchCount(string Keyword)
    {
        throw new NotImplementedException();
    }

    public vAdvertises GetAdsByCode(int Code)
    {
        return dataContext.vAdvertises.SingleOrDefault(p => p.Code.Equals(Code));
    }

    public vAdvertises GetAdsByID(string strID)
    {
        int CachingTime = 10;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetAdsByID" + strID] == null || context.Cache["GetAdsByID" + strID] == "")
        {
            vAdvertises Result = dataContext.vAdvertises.SingleOrDefault(p => p.ID.Equals(strID));
            context.Cache.Insert("GetAdsByID" + strID, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (vAdvertises)context.Cache["GetAdsByID" + strID];



    }

    public object GetByKeywordCode(int KeywordCode, int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        var Result = dataContext.vAdvertiseKeyworsFulls.Where(p => p.KeywordCode.Equals(KeywordCode)).Skip(SkipCount).Take(PageSize);
        return Result;
    }

    public int GetByKeywordCodeCount(int KeywordCode)
    {
        var Result = dataContext.vAdvertiseKeyworsFulls.Where(p => p.KeywordCode.Equals(KeywordCode));
        return Result.Count();
    }

    public object GetRelatedNews(int Code)
    {
        return dataContext.spGetAdverNews(Code);
    }

    public object GetByUserCode(int UserCode, int TakeCount, int PageNo, int PageSize, int CurAdsCode)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        return dataContext.vActiveAdvertises.Where(p => p.UserCode.Equals(UserCode) && !p.Code.Equals(CurAdsCode)).Take(TakeCount).OrderByDescending(p => p.Rate);
    }

    public int GetByUserCodeCount(int UserCode)
    {
        return dataContext.vActiveAdvertises.Where(p => p.UserCode.Equals(UserCode)).Count();
    }

    public object GetRelatedNews(int NewsCode, int PageNo, int PageSize)
    {
        AdvertisesDataContext ADdc = new AdvertisesDataContext();
        return ADdc.spGetNewsAdvertises(NewsCode);
    }

    public object ShowRelatedAds(int AdsCode, int TakeCount)
    {
        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["ShowRelatedAds" + AdsCode + "-" + TakeCount] == null)
        {
            ISingleResult<spGetRelatedAdvertisesResult> Result = dataContext.spGetRelatedAdvertises(AdsCode);//.Take(TakeCount).OrderByDescending(p => p.Rate);
            context.Cache.Insert("ShowRelatedAds" + AdsCode + "-" + TakeCount, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (ISingleResult<spGetRelatedAdvertisesResult>)context.Cache["ShowRelatedAds" + AdsCode + "-" + TakeCount];


//        return dataContext.spGetRelatedAdvertises(AdsCode).Take(TakeCount).OrderByDescending(p => p.Rate);
    }


    public object GetLatestFreeAds(int? CatCode, int TakeCount, int CityCode)
    {
        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetLatestFreeAds" + CatCode + "-" + TakeCount + "-" + CityCode] == null)
        {
            IQueryable<vActiveFreeAds> Result = dataContext.vActiveFreeAds;
            if (CatCode != null)
                Result = Result.Where(p => p.CatCode.Equals(CatCode));

            if (CityCode != 0)
                Result = Result.Where(p => p.CityCode.Equals(CityCode));

            Result = Result.OrderByDescending(p => p.Code).Take(TakeCount);
            context.Cache.Insert("GetLatestFreeAds" + CatCode + "-" + TakeCount + "-" + CityCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<vActiveFreeAds>)context.Cache["GetLatestFreeAds" + CatCode + "-" + TakeCount + "-" + CityCode];


/*
        IQueryable<vActiveFreeAds> Result = dataContext.vActiveFreeAds;
        if (CatCode != null)
            Result = Result.Where(p => p.CatCode.Equals(CatCode));

        if (CityCode != 0)
            Result = Result.Where(p => p.CityCode.Equals(CityCode));

        Result = Result.OrderByDescending(p=> p.Code).Take(TakeCount);
        return Result;
 */
    }

    public object GetLatestFreeAds(int CatCode, int PageNo, int PageSize, int AdsCode, int CityCode)
    {
        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetLatestFreeAds" + PageNo + "-" + PageSize + "-" + AdsCode + "-" + CityCode] == null)
        {
            int SkipCount = (PageNo - 1) * PageSize;
            IQueryable<vActiveFreeAds> Result = dataContext.vActiveFreeAds.Where(p => p.CatCode.Equals(CatCode) && !p.Code.Equals(AdsCode));
            if (CityCode != 0)
                Result = Result.Where(p => p.CityCode.Equals(CityCode) || p.CityCode == null);
            Result = Result.OrderByDescending(p => p.UpdateDate).OrderByDescending(p => p.Rate);
            Result = Result.Skip(SkipCount).Take(PageSize);
            context.Cache.Insert("GetLatestFreeAds" + PageNo + "-" + PageSize + "-" + AdsCode + "-" + CityCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<vActiveFreeAds>)context.Cache["GetLatestFreeAds" + PageNo + "-" + PageSize + "-" + AdsCode + "-" + CityCode];


        //int SkipCount = (PageNo - 1) * PageSize;
        //IQueryable<vActiveFreeAds> Result = dataContext.vActiveFreeAds.Where(p => p.CatCode.Equals(CatCode) && !p.Code.Equals(AdsCode));
        //if (CityCode != 0)
        //    Result = Result.Where(p => p.CityCode.Equals(CityCode));
        //Result = Result.Skip(SkipCount).Take(PageSize);
        //return Result;
    }

    public int GetLatestFreeAdsCount(int CatCode,int AdsCode,int CityCode)
    {
        IQueryable<vActiveFreeAds> Result = dataContext.vActiveFreeAds.Where(p => p.CatCode.Equals(CatCode) && !p.Code.Equals(AdsCode));
        if (CityCode != 0)
            Result = Result.Where(p => p.CityCode.Equals(CityCode) || p.CityCode == null);
        return Result.Count();
    }

    public object GetByCatCode(int CatCode, int CityCode, int PageNo, int PageSize)
    {
        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetByCatCode" + CatCode + "-" + CityCode + "-" + PageNo + "-" + PageSize] == null)
        {
            int SkipCount = (PageNo - 1) * PageSize;
            IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises.Where(p => p.CatCode.Equals(CatCode) || p.MasterCatCode.Equals(CatCode));

            if (CityCode != 0)
                Result = Result.Where(p => p.CityCode.Equals(CityCode));
            Result = Result.OrderByDescending(p => p.UpdateDate).OrderByDescending(p => p.Rate);
            Result = Result.Skip(SkipCount).Take(PageSize);
            context.Cache.Insert("GetByCatCode" + CatCode + "-" + CityCode + "-" + PageNo + "-" + PageSize, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<vActiveAdvertises>)context.Cache["GetByCatCode" + CatCode + "-" + CityCode + "-" + PageNo + "-" + PageSize];


/*
        int SkipCount = (PageNo - 1) * PageSize;
        IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises.Where(p => p.CatCode.Equals(CatCode) || p.MasterCatCode.Equals(CatCode));

        if (CityCode != 0)
            Result = Result.Where(p => p.CityCode.Equals(CityCode));
        Result = Result.OrderByDescending(p => p.UpdateDate).OrderByDescending(p => p.Rate);
        Result = Result.Skip(SkipCount).Take(PageSize);
        return Result;
 */
    }

    public int GetByCatCodeCount(int CatCode, int CityCode)
    {
        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetByCatCodeCount" + CatCode + "-" + CityCode] == null)
        {
            IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises.Where(p => p.CatCode.Equals(CatCode) || p.MasterCatCode.Equals(CatCode));
            if (CityCode != 0)
                Result = Result.Where(p => p.CityCode.Equals(CityCode));
            context.Cache.Insert("GetByCatCodeCount" + CatCode + "-" + CityCode , Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return ((IQueryable<vActiveAdvertises>)context.Cache["GetByCatCodeCount" + CatCode + "-" + CityCode ]).Count();


        //IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises.Where(p => p.CatCode.Equals(CatCode) || p.MasterCatCode.Equals(CatCode));
        //if (CityCode != 0)
        //    Result = Result.Where(p => p.CityCode.Equals(CityCode));

        
        //return Result.Count();
    }

    public object GetByUserCode(int UserCode, int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises.Where(p => p.UserCode.Equals(UserCode) );

        Result = Result.OrderByDescending(p => p.UpdateDate).OrderByDescending(p => p.Rate);
        Result = Result.Skip(SkipCount).Take(PageSize);
        return Result;
    }



    internal object GetAll()
    {
        return dataContext.Advertises.OrderByDescending(p => p.CreateDate);
    }

    internal void IncreaseViewCount(int Code)
    {
        Advertises CurAd = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(Code));
        if (CurAd != null)
        {
            CurAd.ViewCount++;
            dataContext.SubmitChanges();
        }
    }

    internal object GetAll(int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        return dataContext.Advertises.Skip(SkipCount).Take(PageSize);
    }

    internal string GetCatNameByCode(int CatCode)
    {
        AdvertiseCats CurCat = dataContext.AdvertiseCats.SingleOrDefault(p => p.Code.Equals(CatCode));
        if (CurCat != null)
            return CurCat.Title;
        else
            return "";
    }

    internal int? GetMasterCatCode(int? CatCode)
    {
        AdvertiseCats CurCat =  dataContext.AdvertiseCats.SingleOrDefault(p => p.Code.Equals(CatCode));
        if (CurCat != null)
            return CurCat.MasterCode;
        else
            return null;
    }

    internal bool IsOwner(int UserCode, int AdvertisCode)
    {
        Advertises CurAdver = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(AdvertisCode));
        if (CurAdver != null)
        {
            if (CurAdver.UserCode == UserCode)
                return true;
            else
                return false;
        }
        return false;
    }

    internal bool Delete(int AdvertisCode)
    {
        try
        {
            Advertises CurAdver = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(AdvertisCode));
            dataContext.Advertises.DeleteOnSubmit(CurAdver);
            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }

    }

    internal bool UpdateExpDate(int Code, DateTime NewExpDate)
    {
        try
        {
            Advertises CurAdver = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(Code));
            CurAdver.ExpDate = NewExpDate;
            CurAdver.UpdateDate = DateTime.Now;
            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal object ShowGeneralWordByCatCode(int CatCode)
    {
        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["ShowGeneralWordByCatCode" + CatCode] == null)
        {
            ISingleResult<spGetGeneralKeyByCatCodeResult> Result = dataContext.spGetGeneralKeyByCatCode(CatCode);
            context.Cache.Insert("ShowGeneralWordByCatCode" + CatCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (ISingleResult<spGetGeneralKeyByCatCodeResult>)context.Cache["ShowGeneralWordByCatCode" + CatCode];

    }

    internal bool UpdateRate(int AdsCode, int DecilCount)
    {
        try
        {
            Advertises CurAdver = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(AdsCode));
            if (CurAdver != null)
            {
                CurAdver.Rate = DecilCount;
                CurAdver.LinkActivated = true;
                CurAdver.DeciExpDate = DateTime.Now.AddDays(30);
                dataContext.SubmitChanges();
                return true;
            }
            else
                return false;
        }
        catch
        {
            return false;
        }
    }

    internal object GetInactiveAds()
    {
        return dataContext.vAdvertises.Where(p => p.HCAdvertiseStatusCode.Equals(1) || p.HCAdvertiseStatusCode.Equals(4));
    }

    internal object GetRelatedAdsKeywords(int KeywordCode)
    {
        return dataContext.spGetRelatedAdsKeywords(KeywordCode);
    }

    internal object GetKeywords(int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        var Result = (from p in dataContext.vAdvertiseKeyworsFulls
                      select new { p.Keyword }).Distinct().Skip(SkipCount).Take(PageSize);
        return Result;
    }

    internal object GetKeywordCodes(int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        var Result = (from p in dataContext.vAdvertiseKeyworsFulls
                      select new { p.KeywordCode }).Distinct().Skip(SkipCount).Take(PageSize);
        return Result;
    }

    internal object GetAllCats()
    {
        return dataContext.AdvertiseCats;
    }

    internal object ShowRelatedKeywordsByPhrase(string Keyword)
    {
        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["ShowRelatedKeywordsByPhrase" + Keyword] == null)
        {
            string WhereClause = Tools.MakeWhereClause(Keyword, "Title,Description");
            if (WhereClause.StartsWith("AND "))
                WhereClause = WhereClause.Substring(4, WhereClause.Length - 4);

            WhereClause = WhereClause.Replace("''", "'");

            ISingleResult<vAdvertiseKeyworsFull> Result = dataContext.spGetAdKeywordsBySearchPhrase(WhereClause);
            context.Cache.Insert("ShowRelatedKeywordsByPhrase" + Keyword, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (ISingleResult<vAdvertiseKeyworsFull>)context.Cache["ShowRelatedKeywordsByPhrase" + Keyword];
    }

    internal object GetTitles(int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        var Result = (from p in dataContext.Advertises
                      select new { p.Title }).Distinct().Skip(SkipCount).Take(PageSize);
        return Result;
    }

    internal bool ChangeStatus(int AdvertisCode, int HCAdvertiseStatusCode)
    {
        try
        {
            Advertises CurAds = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(AdvertisCode));
            CurAds.HCAdvertiseStatusCode = HCAdvertiseStatusCode;
            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal object GetRatedActiveAds(int TakeCount, int CityCode, int ProvinceCode)
    {
        int CachingTime = 120;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetRatedActiveAds" + TakeCount + "-" + CityCode + "-" + ProvinceCode] == null)
        {
            IQueryable<vActiveAdvertises> Result = dataContext.vActiveAdvertises.Where(p=> p.Rate > 0);
            if (CityCode != 0)
                Result = Result.Where(p => p.CityCode.Equals(CityCode));
            if (ProvinceCode != 0)
                Result = Result.Where(p => p.ProvinceCode.Equals(ProvinceCode));
            Result = Result.OrderByDescending(p => p.Rate).Take(TakeCount);

            context.Cache.Insert("GetRatedActiveAds" + TakeCount + "-" + CityCode + "-" + ProvinceCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<vActiveAdvertises>)context.Cache["GetRatedActiveAds" + TakeCount + "-" + CityCode + "-" + ProvinceCode];
    }

    internal bool UpdateLinkActivation(int AdsCode)
    {
        try
        {
            Advertises CurAdver = dataContext.Advertises.SingleOrDefault(p => p.Code.Equals(AdsCode));
            if (CurAdver != null)
            {
                CurAdver.LinkActivated = true;
                dataContext.SubmitChanges();
                return true;
            }
            else
                return false;
        }
        catch
        {
            return false;
        }
    }

    internal object GetTags(int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        var Result = (from p in dataContext.AdsTags
                      select new { p.Keyword }).Distinct().Skip(SkipCount).Take(PageSize);
        return Result;
    }
}
