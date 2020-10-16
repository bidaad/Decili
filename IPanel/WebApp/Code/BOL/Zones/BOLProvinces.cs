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

public class BOLProvinces : BaseBOLProvinces, IBaseBOL<Provinces>
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

    internal string GetNameByMCCode(int IranMCCode)
    {
        return dataContext.Provinces.SingleOrDefault(p => p.IranMCCode.Equals(IranMCCode)).Name;
    }

    internal int GetProvinceCode(string ProvinceCode)
    {
        
            return 0;
    }

    internal IQueryable<Provinces> GetAll()
    {
        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetAllProvinces"] == null)
        {
            IQueryable<Provinces> Result = dataContext.Provinces.OrderBy( p=> p.Name);
            context.Cache.Insert("GetAllProvinces" , Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<Provinces>)context.Cache["GetAllProvinces"];

    }

    internal string GetNameByCode(int Code)
    {
        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetProvinceNameByCode" + Code] == null)
        {
            Provinces Result = dataContext.Provinces.SingleOrDefault(p => p.Code.Equals(Code));
            if(Result != null)
                context.Cache.Insert("GetProvinceNameByCode" + Code, Result.Name, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }

        if (context.Cache["GetProvinceNameByCode" + Code] != null)
            return ((string)context.Cache["GetProvinceNameByCode" + Code]);
        else
            return "";
    }
}
