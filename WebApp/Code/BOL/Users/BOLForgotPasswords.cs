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
  
public class BOLForgotPasswords : BaseBOLForgotPasswords, IBaseBOL<ForgotPasswords>
{
    public BOLForgotPasswords(params int[] MCodes): base(MCodes)
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
    public vValidForgotPasswords GetDataByGenKey(string GenKey)
    {
        return dataContext.vValidForgotPasswords.SingleOrDefault(g => g.GenKey.Equals(GenKey));
    }

    public void InactiveByGenKey(string GenKey)
    {
        ForgotPasswords ObjForgotPasswords = dataContext.ForgotPasswords.Single(p => p.GenKey.Equals(GenKey));
        ObjForgotPasswords.Used = true;
        dataContext.SubmitChanges();
    }
}
