using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Decili.Code.DAL;
using System.IO;
using System.Configuration;
using Decili.ir.shaparak.pec;

public partial class Users_EditAdvertise : System.Web.UI.Page
{
    protected string FormBody = "";

    public string tranKey = ConfigurationManager.AppSettings["BMITransactionKey"];
    public string CardAcqID = ConfigurationManager.AppSettings["BMIMerchantID"];
    public string TerminalId = ConfigurationManager.AppSettings["BMITerminalID"];
    public string ReturnURL = ConfigurationManager.AppSettings["ReturnURL"];
    public string ServiceURL = ConfigurationManager.AppSettings["BMIServiceURL"];

    List<String> AdvertiseKeyword;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        msgBox.Text = "";
        if (Session["UserCode"] == null)
            Response.Redirect("~/Users/Login.aspx?RefPage=/Users/EditAdvertise.aspx");

        int UserCode = Convert.ToInt32(Session["UserCode"]);

        if (!Page.IsPostBack)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            cboHCStateCode.SelectedValue = "7";
            if (cboHCStateCode.SelectedValue != "")
            {
                int StateCode = Convert.ToInt32(cboHCStateCode.SelectedValue);

                BOLCities CitiesBOL = new BOLCities();
                ddlCities.DataSource = CitiesBOL.GetCityByStateCode(StateCode);
                ddlCities.DataBind();
            }

            string strCode = Request["Code"];
            int Code;
            Int32.TryParse(strCode, out Code);
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            if (Code != 0)
            {
                lblHeader.Text = "ویرایش آگهی";
                if (AdvertisesBOL.IsOwner(UserCode, Code))
                    LoadData(Code);
                pnlAdTools.Visible = true;
            }
            else
            {
                BOLUsers UsersBOL = new BOLUsers();
                Users CurUser = UsersBOL.GetDataByCode(UserCode);
                string strMembershipName = "عادی";

                //int AllowedAdsCount = 5;
                //string strPersianExpDate = "";
                //switch (CurUser.HCMembershipTypeCode)
                //{
                //    case 1:
                //        strMembershipName = "عادی";
                //        AllowedAdsCount = 5;
                //        break;
                //    case 2:
                //        strMembershipName = "برنزی";
                //        AllowedAdsCount = 10;
                //        break;
                //    case 3:
                //        strMembershipName = "نقره ای";
                //        AllowedAdsCount = 20;
                //        break;
                //    case 4:
                //        strMembershipName = "طلایی";
                //        AllowedAdsCount = 999;
                //        break;

                //    default:
                //        break;
                //}

                //int CurrentUserAdsCount = AdvertisesBOL.GetAdsCountByUserCode(UserCode);
                //if(CurrentUserAdsCount  >= AllowedAdsCount)
                //{
                //    ltrHeaderMessage.Text = "<br />عضویت شما هم اکنون " + strMembershipName + " میباشد.";
                //    ltrHeaderMessage.Text += "<br />در این نوع عضویت شما حداکثر قادر به ارسال " + Tools.ChangeEnc(AllowedAdsCount) + " آگهی میباشید." ;
                //    pnlMembershipMessage.Visible = true;
                //    btnUpgradeMembership.Visible = true;
                //    pnlSendAdver.Visible = false;
                //    return;

                //}

                //btnStep1.Visible = true;
                if (Session["FirstName"] != null && Session["LastName"] != null)
                {
                    txtName.Text = Session["FirstName"] + " " + Session["LastName"];
                }
                cboHCDurationCode.SelectedIndex = 1;
                btnEditAds.Visible = false;
            }
        }
    }

    protected void btnUpgradeMembership_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/UpgradeMembership.aspx");
    }
    private void LoadData(int Code)
    {
        try
        {
            Page.Title = "ویرایش آگهی";
            btnNewAds.Visible = false;
            ViewState["AdsCode"] = Code;
            int UserCode = Convert.ToInt32(Session["UserCode"]);
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(Code);
            if (CurAdver.UserCode != UserCode)
                Response.Redirect("~/Advertises.aspx");
            else
            {
                txtName.Text = CurAdver.Name;
                txtDescription.Text = CurAdver.Description;
                txtAddress.Text = CurAdver.Address;
                txtLink.Text = CurAdver.Link;
                txtPrice.Text = CurAdver.Price;
                txtTel.Text = CurAdver.Tel;
                txtTitle.Text = CurAdver.Title;
                if (CurAdver.HCDurationCode != null)
                    cboHCDurationCode.SelectedValue = CurAdver.HCDurationCode.ToString();
                if (CurAdver.HCStateCode != null)
                    cboHCStateCode.SelectedValue = CurAdver.HCStateCode.ToString();
                AdvertiseKeyword = AdvertisesBOL.GetAdverKeywords(Code);
                CatSelector1.SelectedCatCode = CurAdver.CatCode;
                if (CurAdver.CityCode != null)
                {
                    int CityCode = Convert.ToInt32(CurAdver.CityCode);
                    BOLCities CitiesBOL = new BOLCities();
                    int StateCode = CitiesBOL.GetStateByCityCode(CityCode);

                    cboHCStateCode.SelectedValue = StateCode.ToString();
                    ddlCities.DataSource = CitiesBOL.GetCityByStateCode(StateCode);
                    ddlCities.DataBind();
                    ddlCities.SelectedValue = CityCode.ToString();

                }

                if (CurAdver.Rate > 0)
                {
                    pnlDeci.Visible = true;
                    lblDeciCount.Text = Tools.ChangeEnc(CurAdver.Rate.ToString());
                }

                DateTimeMethods dtm = new DateTimeMethods();

                lblExpDate.Text = Tools.ChageEnc(dtm.GetPersianLongDate((DateTime)CurAdver.ExpDate));
                lblCreateDate.Text = Tools.ChageEnc(dtm.GetPersianLongDate((DateTime)CurAdver.CreateDate));

                int HCDurationCode = (int)CurAdver.HCDurationCode;
                int AddDay = 0;
                switch (HCDurationCode)
                {
                    case 1:
                        AddDay = 7;
                        break;
                    case 2:
                        AddDay = 30;
                        break;
                    case 3:
                        AddDay = 60;
                        break;
                    case 4:
                        AddDay = 10000;
                        break;
                    default:
                        break;
                }
                TimeSpan DateDiff = DateTime.Now.AddDays(AddDay) - (DateTime)CurAdver.ExpDate;
                if (DateDiff.Days < 1)
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.Attributes["disabled"] = "disabled";
                }


                if (!string.IsNullOrEmpty(CurAdver.LargePicFile))
                {
                    if (File.Exists(@"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + CurAdver.LargePicFile))
                    {
                        imgAdsPic.ImageUrl = "http://cdn.decili.ir/Files/Ads/" + CurAdver.LargePicFile;
                        imgAdsPic.Visible = true;
                    }
                    PicTools pictools = new PicTools();
                    //int PicDimention = pictools.GetPicDimention(Server.MapPath("~/Files/Ads/" + CurAdver.LargePicFile));
                    /*
                    if (PicDimention > 0)
                    {
                        wci1.X = 0;
                        wci1.X2 = PicDimention;

                        wci1.Y = 0;
                        wci1.Y2 = PicDimention;
                    }
                     * */
                }
                if (AdvertiseKeyword.Count > 0)
                {
                    pnlKeywords.Visible = true;
                    pnlKeywordMessage.Visible = true;
                    ViewState["AdvertiseKeyword"] = AdvertiseKeyword;
                    rptKeywords.DataSource = AdvertiseKeyword;
                    rptKeywords.DataBind();
                }
                //btnEditAdsStep1.Visible = true;
            }
        }
        catch (Exception err)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(err.Message, DateTime.Now, Request.Url.AbsolutePath, "Advertise::Load::Code=" + Code);
        }

        
    }
    private void ExtractKeywords(string AdsContent)
    {
        try
        {
            Tools tools = new Tools();
            ArrayList OneLenList = tools.GenLenKeywords(1, 2, @"(\w+)(\w+)", AdsContent);
            ArrayList TwoLenList = tools.GenLenKeywords(2, 2, @"(\w+)(\w+)", AdsContent);
            ArrayList TreeLenList = tools.GenLenKeywords(3, 1, @"(\w+)(\w+)", AdsContent);
            ArrayList FourLenList = tools.GenLenKeywords(4, 1, @"(\w+)(\w+)", AdsContent);
            List<String> FinalKeywords = new List<String>();

            string[] OneLenListArray = (String[])OneLenList.ToArray(typeof(string));
            string[] TwoLenListArray = (String[])TwoLenList.ToArray(typeof(string));
            string[] TreeLenListArray = (String[])TreeLenList.ToArray(typeof(string));
            string[] FourLenListArray = (String[])FourLenList.ToArray(typeof(string));

            IEnumerable<String> FullKeyList;
            FullKeyList = FourLenListArray.Union(TreeLenListArray).Union(TwoLenListArray).Union(OneLenListArray);
            for (int j = 0; j < FullKeyList.Count(); j++)
            {
                string CurrentKeyword = FullKeyList.ElementAt(j);
                IEnumerable<String> ContainList = FullKeyList.Where(p => p.Contains(CurrentKeyword));
                if (!CurrentKeyword.Contains(" "))
                    FinalKeywords.Add(CurrentKeyword);
                else if (ContainList.Count() == 1 || !CurrentKeyword.Contains(" "))
                    FinalKeywords.Add(ContainList.ElementAt(0));
            }
            AdvertiseKeyword = FinalKeywords;
        }
        catch (Exception err)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert(err.Message, DateTime.Now, Request.Url.AbsolutePath, "Advertise::GenKeywords::");
        }

        //return Tools.GetkeywordCodes(FinalKeywords);
    }

    //protected void btnStep1_Click(object sender, EventArgs e)
    //{
    //    string Title = txtTitle.Text;
    //    string Description = txtDescription.Text;
    //    if (Title.Trim() == "")
    //    {
    //        msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
    //        msgBox.Text = "لطفا عنوان آگهی را وارد کنید.";
    //        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
    //        return;
    //    }

    //    if (Title.Trim().Length > 70)
    //    {
    //        msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
    //        msgBox.Text = "عنوان آگهی نباید بیشتر از 70 کاراکتر باشد";
    //        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
    //        return;
    //    }

    //    if (Description.Trim() == "")
    //    {
    //        msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
    //        msgBox.Text = "لطفا متن آگهی را وارد کنید.";
    //        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
    //        return;
    //    }
    //    ExtractKeywords(Description);
    //    ViewState["AdvertiseKeyword"] = AdvertiseKeyword;
    //    rptKeywords.DataSource = AdvertiseKeyword;
    //    rptKeywords.DataBind();

    //    btnNewAds.Visible = true;
    //    if (rptKeywords.Items.Count > 0)
    //    {
    //        pnlKeywords.Visible = true;
    //        pnlKeywordMessage.Visible = true;
    //    }
    //    pnlUploadedImage.Visible = true;

    //    if (FileUpload1.HasFile)
    //    {
    //        string FileName = FileUpload1.FileName;
    //        int LastDotIndex = FileName.LastIndexOf(".");
    //        string Extension = FileName.Substring(LastDotIndex + 1, FileName.Length - LastDotIndex - 1);

    //        Tools tools = new Tools();
    //        string RandPicName = tools.GetRandString(20) + "." + Extension;
    //        PicTools PictureTools = new PicTools();
    //        PictureTools.SavePic(FileUpload1, RandPicName, Server.MapPath("~/Files/Ads/Temp/"), 800);
    //        imgAdsPic.ImageUrl = "~/Files/Ads/Temp/" + RandPicName;
    //        imgAdsPic.Visible = true;
    //        ViewState["FileName"] = RandPicName;

    //    }
    //    else
    //        pnlUploadedImage.Visible = false;
    //    pnlFileUpload.Visible = false;
    //}
    
    protected void btnEditAdsStep1_Click(object sender, EventArgs e)
    {
        int UserCode = Convert.ToInt32(Session["UserCode"]);

        BOLUsers UsersBOL = new BOLUsers();
        Users CurUser = UsersBOL.GetDataByCode(UserCode);
        string strMembershipName = "عادی";

        //int AllowedAdsCount = 2;
        //string strPersianExpDate = "";
        //switch (CurUser.HCMembershipTypeCode)
        //{
        //    case 1:
        //        strMembershipName = "عادی";
        //        AllowedAdsCount = 2;
        //        break;
        //    case 2:
        //        strMembershipName = "برنزی";
        //        AllowedAdsCount = 10;
        //        break;
        //    case 3:
        //        strMembershipName = "نقره ای";
        //        AllowedAdsCount = 20;
        //        break;
        //    case 4:
        //        strMembershipName = "طلایی";
        //        AllowedAdsCount = 999;
        //        break;

        //    default:
        //        break;
        //}

        //BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        //int CurrentUserAdsCount = AdvertisesBOL.GetAdsCountByUserCode(UserCode);
        //if (CurrentUserAdsCount >= AllowedAdsCount)
        //{
        //    ltrHeaderMessage.Text = "<br />عضویت شما هم اکنون " + strMembershipName + " میباشد.";
        //    ltrHeaderMessage.Text += "<br />در این نوع عضویت شما حداکثر قادر به ارسال " + Tools.ChangeEnc(AllowedAdsCount) + " آگهی میباشید.";
        //    pnlMembershipMessage.Visible = true;
        //    btnUpgradeMembership.Visible = true;
        //    pnlSendAdver.Visible = false;
        //    return;

        //}

        string Title = txtTitle.Text;
        string Description = txtDescription.Text;
        if (Title.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا عنوان آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Title.Trim().Length > 70)
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "عنوان آگهی نباید بیشتر از 70 کاراکتر باشد";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Description.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا متن آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        ExtractKeywords(Description);
        ViewState["AdvertiseKeyword"] = AdvertiseKeyword;
        rptKeywords.DataSource = AdvertiseKeyword;
        rptKeywords.DataBind();

        pnlKeywords.Visible = true;
        pnlKeywordMessage.Visible = true;
        pnlUploadedImage.Visible = true;


        if (FileUpload1.HasFile)
        {
            string FileName = FileUpload1.FileName;
            int LastDotIndex = FileName.LastIndexOf(".");
            string Extension = FileName.Substring(LastDotIndex + 1, FileName.Length - LastDotIndex - 1);

            Tools tools = new Tools();
            string RandPicName = tools.GetRandString(20) + "." + Extension;
            PicTools PictureTools = new PicTools();
            PictureTools.SavePic(FileUpload1, RandPicName, Server.MapPath("~/Files/Ads/Temp/" ), 800);
            imgAdsPic.ImageUrl = "~/Files/Ads/Temp/" + RandPicName;
            imgAdsPic.Visible = true;
            ViewState["FileName"] = RandPicName;

        }
        btnEditAds.Visible = true;
        //btnEditAdsStep1.Visible = false;
    }
    protected void btnNewKeyword_Click(object sender, EventArgs e)
    {
        string NewKeyword = txtNewKeyword.Text.Trim();
        if (NewKeyword != "")
        {
            AdvertiseKeyword = (List<String>)ViewState["AdvertiseKeyword"];
            if (AdvertiseKeyword != null)
            {
                if (!AdvertiseKeyword.Contains(NewKeyword))
                {
                    AdvertiseKeyword.Add(NewKeyword);
                    rptKeywords.DataSource = AdvertiseKeyword;
                    rptKeywords.DataBind();
                    txtNewKeyword.Text = "";
                }
                else
                {
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgBox.Text = "این کلمه در لیست کلمات کلید موجود است";
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
                    return;
                }
            }
        }
    }
    protected void btnNewAds_Click(object sender, EventArgs e)
    {

        string Title = txtTitle.Text;
        string Description = txtDescription.Text;
        string Name = txtName.Text;
        string Tel = txtTel.Text;
        string Price = txtPrice.Text;
        bool ShowContactAdvetiserWin;

        #region Validate
        if (Title.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا عنوان آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Title.Trim().Length < 10)
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "طول عنوان کوتاه تر از ٢٠ کاراکتر است";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Description.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا متن آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Description.Trim().Length < 100)
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "طول متن کوتاه تر از ١٠٠ کاراکتر است";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }

        int? CatCode = null;
        if (CatSelector1.SelectedCatCode != null)
            CatCode = Convert.ToInt32(CatSelector1.SelectedCatCode);

        if (CatCode == null)
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا گروه آگهی را انتخاب کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }

        int HCDurationCode = Convert.ToInt32(cboHCDurationCode.SelectedValue);
        int? HCStateCode = null;
        if (!string.IsNullOrEmpty(cboHCStateCode.SelectedValue))
            HCStateCode = Convert.ToInt32(cboHCStateCode.SelectedValue);

        if (Title.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا عنوان آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Description.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا متن آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }

        #endregion

        string Address = txtAddress.Text;
        string Link = txtLink.Text;

        Link = Link.Trim();
        Link = Link.Replace("http://", "");

        if (Description.Length > 4000)
            Description = Description.Substring(0, 4000) + "...";
        ShowContactAdvetiserWin = true;

        int UserCode = Convert.ToInt32(Session["UserCode"]);
        Tools tools = new Tools();

        string LargePic = "";
        string SmallPic = "";

        if (FileUpload1.HasFile)
        {
            string FileName = FileUpload1.FileName;
            int LastDotIndex = FileName.LastIndexOf(".");
            string Extension = FileName.Substring(LastDotIndex + 1, FileName.Length - LastDotIndex - 1);

            string RandPicName = tools.GetRandString(20) + "." + Extension;
            PicTools PictureTools = new PicTools();
            PictureTools.SavePic(FileUpload1, RandPicName, Server.MapPath("~/Files/Ads/Temp/"), 800);
            imgAdsPic.ImageUrl = "~/Files/Ads/Temp/" + RandPicName;
            imgAdsPic.Visible = true;

            string PicFirstChar = RandPicName.Substring(0, 1);

            LargePic = PicFirstChar + "/" + RandPicName;
            string LargePicRandName = tools.GetRandString(20) + "." + Extension;
            string LargePicFirstChar = LargePicRandName.Substring(0, 1);
            string SmallPicRandName = Tools.GetRand2() + "." + Extension;
            string SmallPicFirstChar = SmallPicRandName.Substring(0, 1);

            string OrigPicPath = Server.MapPath("~/Files/Ads/Temp/") + RandPicName;// PicFirstChar + "/" + RandPicName;
            string SaveSmallResult = PictureTools.ResizeAndSave(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + SmallPicFirstChar + "/" + SmallPicRandName, 120);
            string SaveLargeResult = PictureTools.ResizeAndSave(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + LargePicFirstChar + "/" + LargePicRandName, 400);

            //PictureTools.DeletePic(Server.MapPath("~/Files/Ads/Temp/") + FileName);
            //PictureTools.DeletePic(Server.MapPath("~/Files/Ads") + "/" + PicFirstChar +  RandPicName);

            SmallPic = SmallPicFirstChar + "/" + SmallPicRandName;
            if (SaveSmallResult == OrigPicPath)
            {
                SmallPic = PicFirstChar + "/" + RandPicName;
                File.Copy(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + SmallPicFirstChar + "/" + SmallPicRandName);
            }

            LargePic = LargePicFirstChar + "/" + LargePicRandName;
            if (SaveLargeResult == OrigPicPath)
            {
                LargePic = LargePicFirstChar + "/" + LargePicRandName;
                File.Copy(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + LargePicFirstChar + "/" + LargePicRandName);
            }

        }
        else
        {
            SmallPic = "pic.jpg";
            LargePic = "pic-large.jpg";
        }


        Title = tools.RemoveTags(Title);
        Description = tools.RemoveTags(Description);

        int? CityCode = null;
        if (ddlCities.SelectedValue != "")
            CityCode = Convert.ToInt32(ddlCities.SelectedValue);

        BOLAdvertises AdvertisesBOL = new BOLAdvertises();
        int? AdsCode = AdvertisesBOL.InsertAdvertise(UserCode, Title, Description, Name, Tel, (int)CatCode, HCDurationCode, HCStateCode, Price, SmallPic, LargePic, ShowContactAdvetiserWin, Address, CityCode, Link);
        if (AdsCode != null)
        {
            ExtractKeywords(Description);

            string KeywordCodeList = Tools.GetkeywordCodes2(AdvertiseKeyword);
            BOLEntityKeywords EntityKeywordsBOL = new BOLEntityKeywords();
            EntityKeywordsBOL.SaveKeywordList((int)AdsCode, KeywordCodeList, 2);

            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
            msgBox.Text = "آگهی شما با موفقیت ثبت شد. پس از تایید در لیست آگهی ها قرار میگیرد.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);

            try
            {
                string MailBody = Title + "<br />" + Description;
                bool SendResult = tools.SendEmail(MailBody, "ثبت آگهی جدید", Session["Email"].ToString(), "bidaad@gmail.com", "", "");
            }
            catch
            {
            }

            return;
        }
        else
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "متاسفانه در ثبت آگهی شما خطایی رخ داده است. لطفا دوباره سعی نمایید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);

            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert("", DateTime.Now, Request.Url.AbsolutePath, "Advertise::Save" );
            return;
        }

    }
    protected void btnEditAds_Click(object sender, EventArgs e)
    {
        int UserCode = Convert.ToInt32(Session["UserCode"]);

        int AdsCode = 0;
        if (ViewState["AdsCode"] != null)
            AdsCode = Convert.ToInt32(ViewState["AdsCode"]);
        BOLAdvertises AdvertisesBOL = new BOLAdvertises();


        BOLUsers UsersBOL = new BOLUsers();
        Users CurUser = UsersBOL.GetDataByCode(UserCode);
        string strMembershipName = "عادی";

        //int AllowedAdsCount = 5;
        //string strPersianExpDate = "";
        //switch (CurUser.HCMembershipTypeCode)
        //{
        //    case 1:
        //        strMembershipName = "عادی";
        //        AllowedAdsCount = 5;
        //        break;
        //    case 2:
        //        strMembershipName = "برنزی";
        //        AllowedAdsCount = 10;
        //        break;
        //    case 3:
        //        strMembershipName = "نقره ای";
        //        AllowedAdsCount = 20;
        //        break;
        //    case 4:
        //        strMembershipName = "طلایی";
        //        AllowedAdsCount = 999;
        //        break;

        //    default:
        //        break;
        //}

        //int CurrentUserAdsCount = AdvertisesBOL.GetAdsCountByUserCode(UserCode);
        //if (CurrentUserAdsCount >= AllowedAdsCount)
        //{
        //    ltrHeaderMessage.Text = "<br />عضویت شما هم اکنون " + strMembershipName + " میباشد.";
        //    ltrHeaderMessage.Text += "<br />در این نوع عضویت شما حداکثر قادر به ارسال " + Tools.ChangeEnc(AllowedAdsCount) + " آگهی میباشید.";
        //    pnlMembershipMessage.Visible = true;
        //    btnUpgradeMembership.Visible = true;
        //    pnlSendAdver.Visible = false;
        //    return;

        //}


        Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(AdsCode);

        string Title = txtTitle.Text;
        string Description = txtDescription.Text;
        string Name = txtName.Text;
        string Tel = txtTel.Text;
        string Price = txtPrice.Text;
        bool ShowContactAdvetiserWin;
        string Address = txtAddress.Text;
        string Link = txtLink.Text;
        Link = Link.Replace("http://", "");


        #region Validate
        if (Title.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا عنوان آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Description.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا متن آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        int? CatCode = null;
        if (CatSelector1.SelectedCatCode != null)
            CatCode = Convert.ToInt32(CatSelector1.SelectedCatCode);

        if (CatCode == null)
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا گروه آگهی را انتخاب کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }

        int HCDurationCode = Convert.ToInt32(cboHCDurationCode.SelectedValue);
        int? HCStateCode = null;
        if (!string.IsNullOrEmpty(cboHCStateCode.SelectedValue))
            HCStateCode = Convert.ToInt32(cboHCStateCode.SelectedValue);

        if (Title.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا عنوان آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        if (Description.Trim() == "")
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "لطفا متن آگهی را وارد کنید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        #endregion

        if (Description.Length > 4000)
            Description = Description.Substring(0, 4000) + "...";
        ShowContactAdvetiserWin = true;
        Tools tools = new Tools();

        string LargePic = "";
        string SmallPic = "";
        if (FileUpload1.HasFile)
        {
            string FileName = FileUpload1.FileName;
            int LastDotIndex = FileName.LastIndexOf(".");
            string Extension = FileName.Substring(LastDotIndex + 1, FileName.Length - LastDotIndex - 1);

            string RandPicName = tools.GetRandString(20) + "." + Extension;
            PicTools PictureTools = new PicTools();
            PictureTools.SavePic(FileUpload1, RandPicName, Server.MapPath("~/Files/Ads/Temp/"), 800);
            imgAdsPic.ImageUrl = "~/Files/Ads/Temp/" + RandPicName;
            imgAdsPic.Visible = true;

            string PicFirstChar = RandPicName.Substring(0, 1);

            LargePic = PicFirstChar + "/" + RandPicName;
            string LargePicRandName = tools.GetRandString(20) + "." + Extension;
            string LargePicFirstChar = LargePicRandName.Substring(0, 1);
            string SmallPicRandName = Tools.GetRand2() + "." + Extension;
            string SmallPicFirstChar = SmallPicRandName.Substring(0, 1);

            string OrigPicPath = Server.MapPath("~/Files/Ads/Temp/") + RandPicName;// PicFirstChar + "/" + RandPicName;
            string SaveSmallResult = PictureTools.ResizeAndSave(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + SmallPicFirstChar + "/" + SmallPicRandName, 120);
            string SaveLargeResult = PictureTools.ResizeAndSave(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + LargePicFirstChar + "/" + LargePicRandName, 400);

            //PictureTools.DeletePic(Server.MapPath("~/Files/Ads/Temp/") + FileName);
            //PictureTools.DeletePic(Server.MapPath("~/Files/Ads") + "/" + PicFirstChar +  RandPicName);

            SmallPic = SmallPicFirstChar + "/" + SmallPicRandName;
            if (SaveSmallResult == OrigPicPath)
            {
                SmallPic = PicFirstChar + "/" + RandPicName;
                File.Copy(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + SmallPicFirstChar + "/" + SmallPicRandName);
            }

            LargePic = LargePicFirstChar + "/" + LargePicRandName;
            if (SaveLargeResult == OrigPicPath)
            {
                LargePic = LargePicFirstChar + "/" + LargePicRandName;
                File.Copy(OrigPicPath, @"C:\WWWROOT\Gorji\cdn.decili.ir\wwwroot\Files/Ads/" + LargePicFirstChar + "/" + LargePicRandName);
            }

        }
        else
        {
            SmallPic = CurAdver.SmallPicFile;
            LargePic = CurAdver.LargePicFile;
        }

        Title = tools.RemoveTags(Title);
        Description = tools.RemoveTags(Description);

        int? CityCode = null;
        if (ddlCities.SelectedValue != "")
            CityCode = Convert.ToInt32(ddlCities.SelectedValue);

        bool EditResult = AdvertisesBOL.EditAdvertise(AdsCode, Title, Description, Name, Tel, (int)CatCode, HCDurationCode, HCStateCode, Price, SmallPic, LargePic, ShowContactAdvetiserWin, CityCode, Address, Link);
        if (EditResult)
        {
            AdvertiseKeyword = (List<String>)ViewState["AdvertiseKeyword"];
            string KeywordCodeList = Tools.GetkeywordCodes2(AdvertiseKeyword);
            BOLEntityKeywords EntityKeywordsBOL = new BOLEntityKeywords();
            EntityKeywordsBOL.DeleteKeywords(AdsCode, 2);
            EntityKeywordsBOL.SaveKeywordList(AdsCode, KeywordCodeList, 2);

            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
            msgBox.Text = "آگهی شما با موفقیت اصلاح شد. پس از تایید در لیست آگهی ها قرار میگیرد.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }
        else
        {
            msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
            msgBox.Text = "متاسفانه در اصلاح آگهی شما خطایی رخ داده است. لطفا دوباره سعی نمایید.";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "BackToTop", "$('html, body').animate({ scrollTop: 0 }, 1000);", true);
            return;
        }

    }
    protected void HandleRepeaterCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "RemoveKeyword")
        {
            AdvertiseKeyword = (List<String>)ViewState["AdvertiseKeyword"];
            AdvertiseKeyword.RemoveAt(e.Item.ItemIndex);
            ViewState["AdvertiseKeyword"] = AdvertiseKeyword;
            rptKeywords.DataSource = AdvertiseKeyword;
            rptKeywords.DataBind();
        }

    }
    //protected void btnPay_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["AdsCode"] != null)
    //    {
    //        int AdsCode = Convert.ToInt32(ViewState["AdsCode"].ToString());
    //        Response.Redirect("~/Users/PayStep1.aspx?Code=" + AdsCode);
    //    }
    //}

    protected void cboHCStateCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboHCStateCode.SelectedValue != "")
        {

            int StateCode = Convert.ToInt32(cboHCStateCode.SelectedValue);
            BOLCities CitiesBOL = new BOLCities();
            ddlCities.DataSource = CitiesBOL.GetCityByStateCode(StateCode);
            ddlCities.DataBind();
        }
        else
        {
            ddlCities.Items.Clear();
        }
    }

    protected void btnViewAds_Click(object sender, EventArgs e)
    {
        string strCode = Request["Code"];
        int Code;
        Int32.TryParse(strCode, out Code);
        if (Code != 0)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(Code);
            Response.Redirect(Page.ResolveUrl("~/Ads/" + CurAdver.ID + ".html"), false);
        }

    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        int BankCode = Convert.ToInt32(ddlBankCode.SelectedValue);
        int UserCode = Convert.ToInt32(Session["UserCode"]);
        int AdsCode = Convert.ToInt32(ViewState["AdsCode"]);
        int DecilCount = Convert.ToInt32(txtDecilCount.Text);
        string UserIP = Request.UserHostAddress;
        int AddAmount = DecilCount * 200000;

        BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(UserCode);
        int UserTransactionCode = UserTransactionsBOL.Insert(UserCode, DateTime.Now, 1, 1, UserIP, AddAmount, 6, DecilCount, AdsCode, BankCode);
        long OrderId = Convert.ToInt64(UserTransactionCode);

        #region Melli
        if (BankCode == 4)// Melli
        {
            try
            {
                string AdditionalData = "";
                string requestKey; // request key

                Decili.ir.bmi.bmiutility4.MerchantUtility utl = new Decili.ir.bmi.bmiutility4.MerchantUtility();
                utl.Url = ServiceURL;

                FormBody = utl.PaymentUtilityAdditionalData(CardAcqID, AddAmount, OrderId, tranKey, TerminalId, ReturnURL,
                                                            AdditionalData, out requestKey);
                bool UpdateResult = UserTransactionsBOL.UpdateRequestKey(UserTransactionCode, requestKey);
                if (UpdateResult)
                {
                    FormBody += "</form><script> document.getElementById('paymentUTLfrm').submit();</script>";
                    ((Literal)Master.FindControl("ltrForm")).Text = FormBody;
                }
                else
                {
                    msgBox.Text = "خطا در برقراری ارتباط با سرور بانک ملی";
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    return;
                }

            }
            catch (Exception err)
            {
                msgBox.Text = "خطا در برقراری ارتباط با سرور بانک ملی" + err.Message;
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }
        }
        #endregion
        #region Parsian
        else if (BankCode == 2) // Parsian Bank
        {
            long Authority = 0;
            byte Status = 1;
            EShopService ParsianService = new EShopService();
            ParsianService.PinPaymentRequest(ConfigurationManager.AppSettings["ParsianPin"], AddAmount, UserTransactionCode, ReturnURL, ref Authority, ref Status);
            if (Status == 0)
            {

                bool UpdateResult = UserTransactionsBOL.UpdateAuthority(UserTransactionCode, Authority.ToString());
                if (UpdateResult)
                {
                    Response.Redirect("https://pec.shaparak.ir/pecpaymentgateway/default.aspx?au=" + Authority);
                    return;
                }
                else
                {
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgBox.Text = "خطا ذخیره داده های تراکنش بانک پارسیان" + " کد خطا: " + Status;
                    return;
                }
            }
            else
            {
                msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgBox.Text = "خطا در برقراری ارتباط با بانک پارسیان" + " کد خطا: " + Status;
                return;
            }
        }
                    #endregion
    }

    protected void btnDelAds_Click(object sender, EventArgs e)
    {
        string strCode = Request["Code"];
        int Code;
        Int32.TryParse(strCode, out Code);
        if (Code != 0)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            int UserCode = Convert.ToInt32(Session["UserCode"]);

            if (AdvertisesBOL.IsOwner(UserCode, Code))
            {
                bool DeleteResult = AdvertisesBOL.Delete(Code);
                if (DeleteResult)
                {
                    msgBox.Text = "آگهی با موفقیت حذف شد.";
                    pnlAdForm.Visible = false;
                    pnlAdTools.Visible = false;
                }
                else
                {
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgBox.Text = "متاسفانه در حذف آگهی خطایی رخ داده است.";
                }

            }
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string strCode = Request["Code"];
        int Code;
        Int32.TryParse(strCode, out Code);
        if (Code != 0)
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            int UserCode = Convert.ToInt32(Session["UserCode"]);

            if (AdvertisesBOL.IsOwner(UserCode, Code))
            {
                Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(Code);

                int HCDurationCode = (int)CurAdver.HCDurationCode;
                int AddDay = 0;
                switch (HCDurationCode)
                {
                    case 1:
                        AddDay = 7;
                        break;
                    case 2:
                        AddDay = 30;
                        break;
                    case 3:
                        AddDay = 60;
                        break;
                    case 4:
                        AddDay = 10000;
                        break;
                    default:
                        break;
                }
                //DateTime NewExpDate = ((DateTime)CurAdver.ExpDate).AddDays(AddDay);
                DateTime NewExpDate = (DateTime.Now).AddDays(AddDay);
                AdvertisesBOL.UpdateExpDate(Code, NewExpDate);
                DateTimeMethods dtm = new DateTimeMethods();

                msgBox.Text = "آگهی با موفقیت تا تاریخ " + Tools.ChageEnc(dtm.GetPersianLongDate(NewExpDate)) + "بروز شد.";
                lblExpDate.Text = Tools.ChageEnc(dtm.GetPersianLongDate(NewExpDate));

                btnUpdate.Enabled = false;
                btnUpdate.Attributes["disabled"] = "disabled";


            }
        }

    
    }

    protected void btnMakeSpecial_Click(object sender, EventArgs e)
    {
        pnlSpecialAds.Visible = true;
    }

}