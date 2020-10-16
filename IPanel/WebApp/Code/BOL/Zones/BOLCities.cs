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

public class BOLCities : BaseBOLCities, IBaseBOL<Cities>
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

    internal string GetCityByID(int CityCode)
    {
            return "";

    }

    internal string GetCityByID(int ProvinceCode, int CityCode)
    {
        vCities CutCity = dataContext.vCities.SingleOrDefault(p => p.IranMCCityCode.Equals(CityCode) && p.IranMCCode.Equals(ProvinceCode));
        if (CutCity != null)
            return CutCity.Name;
        else
            return "";

    }


    internal int GetCityCode(string CityCode)
    {
        
            return 0;
    }

    internal object GetCityByStateCode(int StateCode)
    {
        return dataContext.Cities.Where(p => p.ProvinceCode.Equals(StateCode));
    }

    internal int GetStateByCityCode(int CityCode)
    {
        return dataContext.Cities.SingleOrDefault(p => p.Code.Equals(CityCode)).ProvinceCode;
    }

    internal object GetStateByProvinceCode(int Code)
    {
        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetStateByProvinceCode" + Code] == null)
        {
            IQueryable<Cities> Result = dataContext.Cities.Where(p => p.ProvinceCode.Equals(Code));
            context.Cache.Insert("GetStateByProvinceCode" + Code, Result, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }
        return (IQueryable<Cities>)context.Cache["GetStateByProvinceCode" + Code];

    }

    internal string GetNameByCode(int Code)
    {
        int CachingTime = 1440;
        HttpContext context = HttpContext.Current;
        if (context.Cache["GetCityNameByCode" + Code] == null)
        {
            Cities Result = dataContext.Cities.SingleOrDefault(p => p.Code.Equals(Code));
            if (Result != null)
                context.Cache.Insert("GetCityNameByCode" + Code, Result.Name, null, DateTime.Now.AddMinutes(CachingTime), TimeSpan.Zero);
        }

        if (context.Cache["GetCityNameByCode" + Code] != null)
            return ((string)context.Cache["GetCityNameByCode" + Code]);
        else
            return "";
    }
}
