using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_AdKeywords : System.Web.UI.UserControl
{
    protected int _adsCode;
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    public void ShowAdvertiseKeywords(int AdsCode)
    {
        try
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            IQueryable<vAdvertiseKeywords> ItemList = AdvertisesBOL.GetAdverKeywordsFull(AdsCode);
            rptKeywordList.DataSource = ItemList;
            rptKeywordList.DataBind();

            if (ItemList.Any())
            {
                string strKeywordList = "";
                foreach (var item in ItemList)
                {
                    if (strKeywordList == "")
                        strKeywordList = item.Keyword;
                    else
                        strKeywordList += ", " + item.Keyword;
                }
                Tools.SetMeta("keywords", strKeywordList);
            }


            if (rptKeywordList.Items.Count == 0)
                this.Visible = false;
        }
        catch (Exception exp)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, "UCAddKeywords");
        }
    }

    internal void ShowRelatedKeywordsByPhrase(string Keyword)
    {
        ltrHeader.Text = Keyword;
        BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        rptKeywordList.DataSource = AdvertisesBOL.ShowRelatedKeywordsByPhrase(Keyword);
        rptKeywordList.DataBind();
    }
}