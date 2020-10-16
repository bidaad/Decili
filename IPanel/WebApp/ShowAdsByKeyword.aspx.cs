using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;

public partial class Ads_ShowAdsByKeyword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strKeywordCode = Request["Code"];
            int KeywordCode;

            Int32.TryParse(strKeywordCode, out KeywordCode);
            if (KeywordCode != 0)
            {
                BOLKeywords KeywordsBOL = new BOLKeywords();
                Keywords CurKeyword = KeywordsBOL.GetKeywordByCode(KeywordCode);
                if (CurKeyword != null)
                {
                    Page.Title = CurKeyword.Name + " - Decili.ir";
                    lblHeader.Text = CurKeyword.Name;
                    AdsList1.ShowAdsByKeywordCode(KeywordCode, CurKeyword.Name);
                }
            }
            SearchWords1.ShowRelatedKeywordByKeywordCode(KeywordCode);
            LatestAds.ShowLatestAds(null);


        }
        catch(Exception e1)
        {
            Response.Write(e1.Message);
        }
    }
}