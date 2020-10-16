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
  
public class BOLLogs 
{


    public int? InsertLog(string  UserAgent,string  QueryString, string  UserInfo, string UserHostAddress, string AbsolutePath, DateTime LogDate, string Http_referer, bool HCReqTypeCode, ref int? Result)
    {
        LogsDataContext dataContext = new LogsDataContext();
        dataContext.spInsertDeciLog(UserAgent, QueryString, UserInfo, UserHostAddress, AbsolutePath, LogDate, Http_referer,HCReqTypeCode, ref Result);
        return Result;
    }
}
