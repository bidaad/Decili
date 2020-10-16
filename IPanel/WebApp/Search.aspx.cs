using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Decili.Code.DAL;
using System.Reflection;
using Decili.UserControls;

namespace Decili
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserCode"] != null)
                NormalLogin1.Visible = false;
            try
            {
                if (!Page.IsPostBack)
                {
                    string Keyword = Request["Keyword"];
                    if (!string.IsNullOrEmpty(Keyword))
                    {
                        int? SuggestedCatCode = null;
                        AdsList1.SearchAds(Keyword, out SuggestedCatCode);
                        lblHeader.Text = Keyword;
                        UCAdKeywords1.ShowRelatedKeywordsByPhrase(Keyword);
                        UCAdKeywords1.Visible = true;
                        if (SuggestedCatCode != null)
                        {
                            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                            string CatName = AdvertisesBOL.GetCatNameByCode((int)SuggestedCatCode);
                            CatName = CatName.Replace("-", " ");
                            SearchWords1.ShowKeywordByCatCode((int)SuggestedCatCode, CatName);

                        }
                    }
                }
            }
            catch
            {
            }
        }
        public string FormatDate(Object obj)
        {
            string Result = "";
            try
            {
                if (obj != null)
                {
                    DateTime CurDT = Convert.ToDateTime(obj);
                    DateTimeMethods dtm = new DateTimeMethods();
                    Result = Tools.ChageEnc(dtm.GetPersianLongDate(CurDT));
                }
                return Result;

            }
            catch
            {
                return "";
            }

        }
        public string ShowPic(object Title, object PicName)
        {
            string Result = "";
            if (PicName != null && PicName != "")
                Result = "<img class=\"cPicXSmall\" alt=\"" + Title + "\" src=\"" + PicName + "\" />";
            return Result;
        }

    }
}