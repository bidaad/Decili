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

public class BOLUserFavorites : BaseBOLUserFavorites, IBaseBOL<UserFavorites>
{
    public BOLUserFavorites(params int[] MCodes)
        : base(MCodes)
    {

    }
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

    internal bool Insert(int UserCode, int AdvertiseCode)
    {
        try
        {
            UserFavorites NewRecord = new UserFavorites();
            dataContext.UserFavorites.InsertOnSubmit(NewRecord);

            NewRecord.UserCode = UserCode;
            NewRecord.AdvertiseCode = AdvertiseCode;

            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
     }

    internal bool Exists(int UserCode, int AdvertiseCode)
    {
        return dataContext.UserFavorites.Where(p => p.UserCode.Equals(UserCode) && p.AdvertiseCode.Equals(AdvertiseCode)).Count() > 0;
    }

    internal object GetListByUserCode(int UserCode)
    {
        return dataContext.vUserFavorites.Where(p => p.UserCode.Equals(UserCode));
    }

    internal bool Delete(int Code, int UserCode)
    {
        try
        {
            var Result = dataContext.UserFavorites.Where(p => p.Code.Equals(Code) && p.UserCode.Equals(UserCode));
            dataContext.UserFavorites.DeleteAllOnSubmit(Result);
            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
