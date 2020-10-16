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
  
public class BOLLinks : BaseBOLLinks, IBaseBOL<Links>
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

    public object GetRandLinks(int TakeCount)
    {
        return dataContext.vRandLinks.Take(TakeCount);
    }

    public object GetLinksByCat(int CatCode)
    {
        return dataContext.Links.Where(p => p.CatCode.Equals(CatCode));
    }
    internal object GetAllLinks()
    {
        return dataContext.vLinks.OrderBy(p => p.Title);
    }


    internal object GetPicLinks(int TakeCount)
    {
        return dataContext.vLinks.Where(p => p.FileName != null).OrderBy(p => p.ShowOrder).Take(TakeCount);
    }

    internal object GetLinksBycatCode(int? CatCode)
    {
        IQueryable<vLinks> Result = dataContext.vLinks;
        if (CatCode != null)
            Result = Result.Where(p => p.CatCode.Equals(CatCode));
        
        Result = Result.OrderBy(p => p.ShowOrder);
        return Result;
    }
}
