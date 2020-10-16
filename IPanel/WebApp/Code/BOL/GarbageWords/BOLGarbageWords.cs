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
  
public class BOLGarbageWords : BaseBOLGarbageWords, IBaseBOL<GarbageWords>
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

    internal bool IsInCurrectList(string Word)
    {
        int WordCount = (from k in dataContext.GarbageWords
                         where k.Word.Equals(Word)
                         select k).Count();
        if (WordCount == 0)
            return false;
        else
            return true;
    }
}
