using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCSearchWords : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowKeywordByCatCode(int CatCode, string CatFullHirarchy)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptKeywordList.DataSource =  AdvertisesBOL.ShowGeneralWordByCatCode(CatCode);
            rptKeywordList.DataBind();

            ltrHeader.Text = CatFullHirarchy;
        }

        public void ShowRelatedKeywordByKeywordCode(int KeywordCode)
        {
            ltrHeader.Text = "جستجوهای مرتبط";
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptKeywordList.DataSource = AdvertisesBOL.GetRelatedAdsKeywords(KeywordCode);
            rptKeywordList.DataBind();
        }

    }
}