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

public class BOLErrorLogs : BaseBOLErrorLogs, IBaseBOL<ErrorLogs>
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
    public void Insert(string Message, System.Nullable<System.DateTime> DateTime, string AbsolutePath, string QueryString)
    {
        try
        {
            ErrorLogs NewObj = new ErrorLogs();
            dataContext.ErrorLogs.InsertOnSubmit(NewObj);
            NewObj.Message = Message;
            NewObj.DateTime = DateTime;
            NewObj.AbsolutePath = AbsolutePath;
            NewObj.QueryString = QueryString;
            dataContext.SubmitChanges();
        }
        catch (Exception err)
        {
            
        }
    }

}
