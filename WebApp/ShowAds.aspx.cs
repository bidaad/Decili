using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;

public partial class Ads_ShowAds : System.Web.UI.Page
{
    public string LatX;
    public string LatY;
    public string strCatHirarchy = "";
    public string AdTitle;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            msgMessage.Text = "";

            string strID = Request["ID"];
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            vAdvertises CurAds = AdvertisesBOL.GetAdsByID(strID);
            if (CurAds == null)
                return;

            if (CurAds.ExpDate < DateTime.Now)
            {
                //lblTitle.Text = "آگهی " + CurAds.Title + " منقضی شده است";
                //pnlContactAdvertiser.Visible = false;
                //pnlRelatedNews.Visible = false;
                //pnlAdsInfo.Visible = false;
                //pnlGoogleMap.Visible = false;
                //pnlPic.Visible = false;
                //UCSmallAdsList1.Visible = false;
                //UCSmallAdsList1.ShowAdsByCatCode((int)CurAds.CatCode, (int)CurAds.Code, CurAds.CityCode);

                //return;
                pnlExpired.Visible = true;
            }
            if (CurAds.HCAdvertiseStatusCode != 2)
            {
                lblTitle.Text = "آگهی " + CurAds.Title + " در دست بررسی است";
                pnlContactAdvertiser.Visible = false;
                pnlRelatedNews.Visible = false;
                pnlAdsInfo.Visible = false;
                pnlGoogleMap.Visible = false;
                pnlPic.Visible = false;
                UCSmallAdsList1.Visible = false;
                UCSmallAdsList1.ShowAdsByCatCode((int)CurAds.CatCode, (int)CurAds.Code, CurAds.CityCode);

                return;
            }

            ViewState["ID"] = strID;

            

            #region Increase ViewCount
            try
            {
                string UserAgent = HttpContext.Current.Request.UserAgent;
                if (!Tools.GetCrawelerUserAgents().Contains(UserAgent))
                {
                    AdvertisesBOL.IncreaseViewCount(CurAds.Code);
                }

            }
            catch
            {
            }
            #endregion

            string AdTitle = CurAds.Title;
            string AdDescription = CurAds.Description;

            string Keyword = Request["Keyword"];
            if (!string.IsNullOrEmpty(Keyword))
            {
                Keyword = Keyword.Trim();
                string[] KeywordArray = Keyword.Split(' ');
                for (int i = 0; i < KeywordArray.Length; i++)
                {
                    AdTitle = AdTitle.Replace(KeywordArray[i], "<span class=keyworditem>" + KeywordArray[i] + "</span>");
                    AdDescription = AdDescription.Replace(KeywordArray[i], "<span class=keyworditem>" + KeywordArray[i] + "</span>");
                }
            }


            int PageNo = 1;
            string strPageNo = Request["PageNo"];
            try
            {
                PageNo = Convert.ToInt32(strPageNo);
            }
            catch
            {
            }
            if (PageNo == 0)
                PageNo = 1;

            if(PageNo == 1)
                Page.Title = CurAds.Title;
            else
                Page.Title = CurAds.Title + " - صفحه " + Tools.ChangeEnc(PageNo.ToString());
            lblTitle.Text = AdTitle;
            
            lblDescription.Text = Tools.FormatString(AdDescription);
            lblAdsDate.Text = Tools.ChangeEnc(CurAds.EDate);

            ColAds1.ShowAdsByUser((int)CurAds.UserCode, CurAds.Code);
            RelatedAds.ShowRelatedAds((int)CurAds.Code);


            UCSmallAdsList1.ShowAdsByCatCode((int)CurAds.CatCode, (int)CurAds.Code, CurAds.CityCode);

            if (!string.IsNullOrEmpty(CurAds.Tel))
                lblTel.Text = Tools.ChageEnc( CurAds.Tel);
            else
                pnlTel.Visible = false;

            if (!string.IsNullOrEmpty(CurAds.Name))
                lblName.Text = CurAds.Name;
            else
                pnlName.Visible = false;

            if (!string.IsNullOrEmpty(CurAds.Price))
                lblPrice.Text = Tools.ChangeEnc(CurAds.Price);
            else
                pnlPrice.Visible = false;

            if (CurAds.CityCode != null)
            {
                pnlCity.Visible = true;
                lblCityProvince.Text = CurAds.CityName + " - " + CurAds.ProvinceName;
            }
            txtQuestion.Text = "در رابطه با آگهی " + CurAds.Title + " در سایت دسیلی ... ";
            string MetaDesc = "";
            if (CurAds.Description.Length > 100)
                MetaDesc = CurAds.Description.Substring(0, 100);
            else
                MetaDesc = CurAds.Description;
            Tools.SetMeta("description", MetaDesc);

            lblSenderName.Text = CurAds.Name;
            AdTitle = CurAds.Title;
            if (CurAds.Rate != null)
            {
                int DeciCount = Convert.ToInt32(CurAds.Rate);
                if (DeciCount > 0)
                {
                    ltrDeci.Text = Tools.ChangeEnc( CurAds.Rate.ToString());
                    pnlDeci.Visible = true;
                }
            }

            if (CurAds.Tel != null)
            {
                try
                {
                    CurAds.Tel = CurAds.Tel.Replace("\n", " ");
                    if (CurAds.Tel.Trim().IndexOf(" ") != -1)
                    {
                        string[] TelArray = CurAds.Tel.Trim().Split(' ');
                        lblPhone.Text = Tools.ChangeEnc(TelArray[0]);
                    }
                    else
                        lblPhone.Text = Tools.ChangeEnc(CurAds.Tel);
                }
                catch
                {
                }
            }
            if (CurAds.CityCode != null)
            {
                hplSenderCity.Text = CurAds.CityName;
                hplSenderCity.NavigateUrl = "~/?CityCode=" + CurAds.CityCode;
            }

            if (CurAds.CityCode != null)
            {
                BOLCities CitiesBOL = new BOLCities();
                int CurCityProvinceCode = CitiesBOL.GetStateByCityCode((int)CurAds.CityCode);
                UCCities1.ProvinceCode = CurCityProvinceCode;
            }
            else
                UCCities1.Visible = false;


            GenCatHirarchy(CurAds.CatCode);
            string CatFullHirarchy = "<ul class=\"CatHirrarchy\">" + strCatHirarchy + "<li>&nbsp;<span class=\"fa fa-tag\"></span>&nbsp;</li>"  + "</ul>";
            lblCat.Text = CatFullHirarchy;

            SearchWords1.ShowKeywordByCatCode(CurAds.CatCode, CatFullHirarchy);


            DateTimeMethods dtm = new DateTimeMethods();
            lblAdsDate.Text = Tools.ChangeEnc(CurAds.EDate);
            if (!string.IsNullOrEmpty(CurAds.StateName))
                lblStateName.Text = CurAds.StateName;
            else
                pnlStateName.Visible = false;
            if (!string.IsNullOrEmpty(CurAds.Address))
                lblAddress.Text = CurAds.Address;
            else
                pnlAddress.Visible = false;

            if (CurAds.LinkActivated != null)
            {
                if ((bool)CurAds.LinkActivated)
                {
                    if (CurAds.Link != null)
                    {
                        hplLink.NavigateUrl = "http://" + CurAds.Link;
                        hplLink.Text = CurAds.Link;
                        pnlLink.Visible = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(CurAds.LargePicFile))
            {
                if (File.Exists(@"D:\www\Gorji\cdn.decili.ir\wwwroot/Files/Ads/" + CurAds.LargePicFile))
                {
                    imgAdsPic.ImageUrl = "https://cdn.Decili.ir/Files/Ads/" + CurAds.LargePicFile;
                    imgAdsPic.AlternateText = CurAds.Title;
                    Tools.SetMeta("ogImage", "https://www.Decili.ir/Files/Ads/" + CurAds.LargePicFile);
                    Tools.SetMeta("ogTitle", CurAds.Title);
                    Tools.SetMeta("ogDescription", MetaDesc);

                }
                else if (!string.IsNullOrEmpty(CurAds.SmallPicFile))
                {
                    if (File.Exists(@"D:\www\Gorji\cdn.decili.ir\wwwroot/Files/Ads/" + CurAds.SmallPicFile))
                        imgAdsPic.ImageUrl = "https://cdn.Decili.ir/Files/Ads/" + CurAds.SmallPicFile;
                    else
                        pnlPic.Visible = false;
                }
                else
                    pnlPic.Visible = false;
            }
            else
                pnlPic.Visible = false;

            if (!string.IsNullOrEmpty(CurAds.Email))
                pnlContactAdvertiser.Visible = true;
            else
                pnlContactAdvertiser.Visible = false;
            string Desc = "";
            string Keywords = "";
            if (CurAds.Description.Length > 200)
            {
                int BlankPos = CurAds.Description.IndexOf(" ", 200);
                if (BlankPos != -1)
                    Desc = CurAds.Description.Substring(0, BlankPos);
                else
                    Desc = CurAds.Description;
            }
            else
                Desc = CurAds.Description;


            int ViewCount = Convert.ToInt32(CurAds.ViewCount);
            ViewCount++;

            lblViewCount.Text = Tools.ChangeEnc(ViewCount.ToString()) + " بار";
            lblCreateDate.Text = Tools.ChangeEnc( dtm.GetPersianLongDate((DateTime)CurAds.CreateDate));

            //UCAdKeywords1.AdsCode = CurAds.Code;
            UCAdKeywords1.ShowAdvertiseKeywords(CurAds.Code);
            
            
            //rptRelatedNews.DataSource = AdvertisesBOL.GetRelatedNews(CurAds.Code);
            //rptRelatedNews.DataBind();

            if (rptRelatedNews.Items.Count == 0)
                pnlRelatedNews.Visible = false;

            Tools.SetMeta("description", Desc);
            Tools.SetMeta("keywords", Keywords);

            if (!string.IsNullOrEmpty(CurAds.Email))
            {
                try
                {
                    #region Show Email
                    string firstText = CurAds.Email;

                    PointF firstLocation = new PointF(300f, 0f);
                    StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

                    string imageFilePath = @"D:\www\Gorji\Decili.ir\wwwroot\images\bulk.bmp";
                    Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(imageFilePath);//load the image file

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Font arialFont = new Font("Arial", 14))
                        {
                            graphics.DrawString(firstText,
                        arialFont,
                        new SolidBrush(Color.Black),
                        firstLocation,
                        format);
                        }

                        int n = 1;
                        Random rnd = new Random();
                        for (int i = 0; i < n; i++)
                        {
                            int x0 = bitmap.Width;
                            int y0 = rnd.Next(0, bitmap.Height);

                            int x1 = 0;// rnd.Next(0, bitmap.Width / 2);
                            int y1 = rnd.Next(0, bitmap.Height);// rnd.Next(0, bitmap.Height / 2);

                            float[] dashValues = { 5, 2, 15, 4 };
                            Pen blackPen = new Pen(Color.Black, 1);
                            blackPen.DashPattern = dashValues;

                            graphics.DrawLine(blackPen, x0, y0, x1, y1);
                        }

                    }

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);


                    byte[] byteImage = ms.ToArray();
                    string base64String = Convert.ToBase64String(byteImage);

                    imgEmail.ImageUrl = "data:image/jpeg;base64," + base64String;

                    bitmap.Dispose();
                    #endregion
                }
                catch
                {
                }
            }
            else
                pnlEmail.Visible = false;

            if (!string.IsNullOrEmpty(CurAds.LatX) && !string.IsNullOrEmpty(CurAds.LatY))
            {
                pnlGoogleMap.Visible = true;
                LatX = CurAds.LatX;
                LatY = CurAds.LatY;
            }
            else
                pnlGoogleMap.Visible = false;


            rptGenTitleKeys.DataSource = GetTitleKeys(CurAds.Title);
            rptGenTitleKeys.DataBind();

            ((Literal)Master.FindControl("ltrCanonicalLink")).Text =  "<link rel=\"canonical\" href=\"https://www.Decili.ir/Ads/" + CurAds.ID + ".html\" />";
            ((Panel)Master.FindControl("pnlDeciliPhone")).Visible = false;

            
        }
        catch(Exception err)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert("Show Advertise", DateTime.Now, "ShowAdver.aspx", err.Message);
        }


    }

    public IEnumerable<String> GetTitleKeys(string AdsTitle)
    {
        ArrayList OneLenList = GenLenKeywords(1, 2, @"(\w+)(\w+)", AdsTitle);
        ArrayList TwoLenList = GenLenKeywords(2, 2, @"(\w+)(\w+)", AdsTitle);
        ArrayList TreeLenList = GenLenKeywords(3, 1, @"(\w+)(\w+)", AdsTitle);
        ArrayList FourLenList = GenLenKeywords(4, 1, @"(\w+)(\w+)", AdsTitle);
        List<String> FinalKeywords = new List<String>();

        string[] OneLenListArray = (String[])OneLenList.ToArray(typeof(string));
        string[] TwoLenListArray = (String[])TwoLenList.ToArray(typeof(string));
        string[] TreeLenListArray = (String[])TreeLenList.ToArray(typeof(string));
        string[] FourLenListArray = (String[])FourLenList.ToArray(typeof(string));

        IEnumerable<String> FullKeyList;
        FullKeyList = (FourLenListArray.Union(TreeLenListArray).Union(TwoLenListArray).Union(OneLenListArray)).Distinct();

        return FullKeyList;
    }

    public ArrayList GenLenKeywords(int WordCount, int MinLen, string _pattern, string InputStr)
    {
        int StrLen = InputStr.Length;
        ArrayList ResultArray = new ArrayList();
        ArrayList InnerResultList = new ArrayList();

        Regex r = new Regex(_pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Match m = r.Match(InputStr);
        string CurKeyword = "";
        while (m.Success)
        {
            CurKeyword = m.Groups[0].Captures[0].ToString();
            InnerResultList.Add(CurKeyword);
            m = m.NextMatch();
        }

        string CurLengthKey = "";
        for (int i = 0; i < InnerResultList.Count; i++)
        {
            if (i >= WordCount && i < InnerResultList.Count)
            {
                for (int j = WordCount - 1; j >= 0; j--)
                    CurLengthKey = CurLengthKey + " " + InnerResultList[i - j - 1];
                CurLengthKey = CurLengthKey.Trim();

                if (!CurLengthKey.EndsWith("های") && CurLengthKey != "در" && !CurLengthKey.EndsWith("در") && !CurLengthKey.StartsWith("در") && !CurLengthKey.StartsWith("های"))
                    ResultArray.Add(CurLengthKey);
                CurLengthKey = "";
            }
        }

        return ResultArray;
    }


    public string ShowDate(Object obj)
    {
        if (obj != null)
        {
            DateTimeMethods dtm = new DateTimeMethods();
            return Tools.ChangeEnc( dtm.GetPersianDate(Convert.ToDateTime(obj)));
        }
        return "";
    }

    public void GenCatHirarchy(int? CatCode)
    {
        try
        {
            if (CatCode != null)
            {
                BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                string CatName = AdvertisesBOL.GetCatNameByCode((int)CatCode);
                strCatHirarchy += "<li><span ><a href='/Cats_" + CatName.Replace("-", "_") + "-" + CatCode + ".html'>" + CatName.Replace("-", " ") + "</a></span>&nbsp;&nbsp;»&nbsp;&nbsp;</li>";
                int? MasterCatCode = AdvertisesBOL.GetMasterCatCode(CatCode);
                GenCatHirarchy(MasterCatCode);
            }
        }
        catch
        {
        }

    }


    protected void btnSendToAdvertiser_Click(object sender, EventArgs e)
    {
        if (!RadCaptcha1.IsValid)
        {
            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgMessage.Text = "لطفا کد امنیتی را وارد کنید";
            return;
        }

        string Name = txtName.Text;
        string Email = txtEmail.Text;
        string Question = txtQuestion.Text;

        if (Name == "" || Email == "" || Question == "")
        {
            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgMessage.Text = "لطفا فیلدهای ضروری را تکمیل نمایید.";
            return;
        }

        string MailBody = "";
        MailBody = "<b>فرستنده:</b>" + Name + "<br />";
        MailBody = "<b>ایمیل:</b>" + Email + "<br />";
        MailBody += "<b>متن پیام: </b>" + Question.Replace("\n", "<br />");
        MailBody += "<b>لینک آگهی: </b> <a href=https://www.Decili.ir/Ads/" + ViewState["ID"] + ".html'>https://www.Decili.ir/Ads/" + ViewState["ID"] + "</a>";

        if (ViewState["ID"] == null)
            return;

        string strID = ViewState["ID"].ToString();
        
        BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        vAdvertises CurAds = AdvertisesBOL.GetAdsByID(strID);
        if (CurAds == null)
            return;

        Tools tools = new Tools();
        bool SendResult = tools.SendEmail(MailBody, CurAds.Title , Email, CurAds.Email, "bidaad@gmail.com", "");
        if (SendResult)
        {
            BOLEmails EmailsBOL = new BOLEmails();
            EmailsBOL.Insert(Email, 5, Question);
            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
            msgMessage.Text = "پیام شما به آگهی دهنده ارسال شد.";
        }
        else
        {
            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgMessage.Text = "متاسقانه در ارسال پیام شما خطایی رخ داده است";

        }
    }
}