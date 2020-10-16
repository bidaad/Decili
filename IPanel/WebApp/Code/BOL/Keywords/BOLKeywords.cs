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
using System.Web.SessionState;
using Decili.Code.DAL;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
  
public class BOLKeywords : BaseBOLKeywords, IBaseBOL<Keywords>
{
    public IList CheckBusinessRules()
    {
        var messages = new List<string>();
        //Business rules here

        if (false)
            messages.Add("");

        return messages;
    }

    public static bool IsInTitleKeywords(string str)
    {
        KeywordsDataContext dataContext = new KeywordsDataContext();
        var ResultList = from k in dataContext.vTitleKeywords
                         where k.Title.Equals(str)
                         select k;
        if (ResultList.Count() == 0)
            return false;
        else
            return true;
    }


    public Keywords GetDataByKeyword(string KeyName)
    {
        return dataContext.Keywords.SingleOrDefault(u => u.Name.Equals(KeyName));
    }

    public int? GetKeywordCode(string Word)
    {
        KeywordsDataContext dc = new KeywordsDataContext();
        IQueryable<Keywords> Result = from p in dc.Keywords
                                      where p.Name.Equals(Word)
                                      select p;
        foreach (var item in Result)
        {
            return item.Code;
            
        }
        return null;
    }

    public object GetList(int StartIndex, int PageSize)
    {
        int SkipCount = (StartIndex - 1) * PageSize;
        return dataContext.vUsedKeywords.Skip(SkipCount).Take(PageSize);
    }

    public void AddToGrabage(int KeywordCode)
    {
        dataContext.spAddtoGrabagge(KeywordCode);
    }

    public Decili.Code.DAL.Keywords GetKeywordByCode(int KeywordCode)
    {

        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetKeywordByCode" + KeywordCode] == null)
        {
            Decili.Code.DAL.KeywordsDataContext dc = new Decili.Code.DAL.KeywordsDataContext();
            Decili.Code.DAL.Keywords Result = dc.Keywords.SingleOrDefault(p => p.Code.Equals(KeywordCode));
            context.Cache.Insert("GetKeywordByCode" + KeywordCode, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (Decili.Code.DAL.Keywords)context.Cache["GetKeywordByCode" + KeywordCode];


        //Decili.Code.DAL.KeywordsDataContext dc = new Decili.Code.DAL.KeywordsDataContext();
        //return dc.Keywords.SingleOrDefault(p => p.Code.Equals(KeywordCode));
    }

    internal object GetKeywordsStartsWith(string Name)
    {
        return dataContext.Keywords.Where(p => p.Name.StartsWith(Name)).OrderBy(p=>p.Name.Length).Take(50);
    }

    internal void AddToSearchedKeywords(string Keyword, int ResultCount)
    {
        UtilDataContext dc = new UtilDataContext();
        SearchedKeywords NewRecord = new SearchedKeywords();
        dc.SearchedKeywords.InsertOnSubmit(NewRecord);
        NewRecord.Keyword = Keyword;
        NewRecord.HCSiteSectionCode = 5;
        NewRecord.SearchDate = DateTime.Now;
        NewRecord.IP = HttpContext.Current.Request.UserHostAddress;
        NewRecord.ReturnCount = ResultCount;
        dc.SubmitChanges();
    }
}
