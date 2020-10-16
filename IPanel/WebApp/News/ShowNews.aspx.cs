using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;
using System.Web.UI.HtmlControls;
using System.IO;
using Decili.UserControls;
using System.Globalization;

namespace ASNoor.NewsFolder
{
    public partial class ShowNews : System.Web.UI.Page
    {
        public string NewsCode;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {


                int Code = 0;
                string strCode = Request["Code"];
                Int32.TryParse(strCode, out Code);
                BOLNews NewsBOL = new BOLNews();
                //News CurNews = ((IBaseBOL<News>)NewsBOL).GetDetails(Code);
                vNews CurNews = NewsBOL.GetFullInfo(Code);
                if (CurNews != null)
                {

                    NewsBOL.IncermentVisitCount(Code);
                    NewsCode = Code.ToString();
                    ViewState["Code"] = CurNews.Code;
                    //hplExportTpPDF.NavigateUrl = "~/Export.aspx?Type=PDF&Code=" + CurNews.Code;
                    Page.Title = lblTitle.Text = CurNews.NewsTitle;


                    DateTimeMethods dtm = new DateTimeMethods();
                    string strDateTime = "";

                    if(!string.IsNullOrEmpty( CurNews.NDate ))
                        strDateTime += Tools.ChageEnc(CurNews.NDate);

                    lblDate.Text = strDateTime;


                    if (!string.IsNullOrEmpty(CurNews.PicFile))
                    {
                        hplImage.ImageUrl = CurNews.PicFile;
                    }
                    else
                        hplImage.ImageUrl = "~/images/Nopic.gif";

                    string Abstract = CurNews.ShortDesc;
                    Abstract = Abstract.Replace("<br />", "</p><p>");
                    Abstract = Abstract.Replace("font-family", "font-family1");
                    Abstract = Abstract.Replace("font-size", "font-size1");
                    Abstract = Abstract.Replace("line-height", "line-height1");

                    ltrNewsBody.Text = Tools.FormatText(CurNews.Description);

                    lblVisitCount.Text = " تعداد بازدید: " +  Tools.ChangeEnc( CurNews.VisitCount);

                    if (!string.IsNullOrEmpty(CurNews.CatName))
                        lblCatInfo.Text = "گروه: " + CurNews.CatName; 

                }
            }
        }


    }
}