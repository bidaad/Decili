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

public class BOLNews : BaseBOLNews, IBaseBOL<News>
{
    public IList CheckBusinessRules()
    {
        var messages = new List<string>();

        #region Business Rules
        //Example
        //if (string.IsNullOrEmpty(this.FirstName))
        //    messages.Add("Please fill FirstName.");

        #endregion
        return messages;
    }


    public News GetLatestNews()
    {
        return dataContext.News.OrderByDescending(p => p.Code).FirstOrDefault();
    }

    public object GetLatestNews(int TakeCount)
    {
        return dataContext.News.OrderByDescending(p => p.Code).Take(TakeCount);
    }

    public object GetLatestNews(int PageNo, int TakeCount)
    {
        int SkipCount = (PageNo - 1) * TakeCount;
        IQueryable<vNews> ResultList = dataContext.vNews.OrderByDescending(p => p.Code);

        return ResultList.Skip(SkipCount).Take(TakeCount);
    }
    public int GetNewsCount()
    {
        var ResultList = dataContext.vNews;
        return ResultList.Count();
    }

    internal void IncermentVisitCount(int Code)
    {
        News CurNews = dataContext.News.SingleOrDefault(p => p.Code.Equals(Code));
        CurNews.VisitCount = CurNews.VisitCount + 1;
        dataContext.SubmitChanges();
    }

    internal object GetRandomNews()
    {
        return dataContext.vRandNews;
    }

    internal vNews GetFullInfo(int Code)
    {
        return dataContext.vNews.SingleOrDefault(p => p.Code.Equals(Code));
    }
}
