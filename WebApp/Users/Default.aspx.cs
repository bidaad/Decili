using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;
using System.Configuration;
using Decili.ir.shaparak.pec;
using AKP.Web.Controls;

namespace Decili.UsersFolder
{
    public partial class Default : System.Web.UI.Page
    {
        public string ActivateTab = "";
        public int OrderCounter = 0;
        public int FavCounter = 0;
        protected string FormBody = "";

        public string tranKey = ConfigurationManager.AppSettings["BMITransactionKey"];
        public string CardAcqID = ConfigurationManager.AppSettings["BMIMerchantID"];
        public string TerminalId = ConfigurationManager.AppSettings["BMITerminalID"];
        public string ReturnURL = ConfigurationManager.AppSettings["ReturnURL"];
        public string ServiceURL = ConfigurationManager.AppSettings["BMIServiceURL"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("http://ipanel.decili.ir", false);
            return;

            Security.Check();
            int UserCode = Convert.ToInt32(Session["UserCode"]);

            if (!Page.IsPostBack)
            {
                BOLUsers UsersBOL = new BOLUsers();

                BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                rptAdvertises.DataSource = AdvertisesBOL.GetAdverByUserCode(UserCode);
                rptAdvertises.DataBind();

                if (rptAdvertises.Items.Count == 0)
                {
                    rptAdvertises.Visible = false;
                    pnlMyAdsTitle.Visible = false;
                    msgMessage.Text = "هم اکنون هیچ موردی در فهرست آگهی های شما موجود نیست.";
                }
                else
                {
                    rptAdvertises.Visible = true;
                    pnlMyAdsTitle.Visible = true;
                    msgMessage.Text = "";
                }

            }
        }

        protected void HandleRepeaterCommand(object source, RepeaterCommandEventArgs e)
        {
            
            LinkButton btnDelete = (LinkButton)e.Item.Controls[1].FindControl("btnDelete");
            LinkButton btnUpdate = (LinkButton)e.Item.Controls[1].FindControl("btnUpdate");
            LinkButton btnMakeSpecial = (LinkButton)e.Item.Controls[1].FindControl("btnMakeSpecial");
            Label lblExpDate = (Label)e.Item.Controls[1].FindControl("lblExpDate");
            MsgBox msgItem = (MsgBox)e.Item.Controls[1].FindControl("msgItem");
            
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            int UserCode = Convert.ToInt32(Session["UserCode"]);
            #region Edit
            if (e.CommandName == "Edit")
            {
                int AdvertisCode = Convert.ToInt32(btnDelete.Attributes["Code"]);
                Response.Redirect("~/Users/EditAdvertise.aspx?Code=" + AdvertisCode, false);

            }
            #endregion
            #region Delete
            if (e.CommandName == "Delete")
            {
                int AdvertisCode = Convert.ToInt32( btnDelete.Attributes["Code"]);
                if (AdvertisesBOL.IsOwner(UserCode, AdvertisCode))
                {
                    bool DeleteResult = AdvertisesBOL.Delete(AdvertisCode);
                    if (DeleteResult)
                    {
                        msgMessage.Text = "آگهی با موفقیت حذف شد.";
                        rptAdvertises.DataSource = AdvertisesBOL.GetAdverByUserCode(UserCode);
                        rptAdvertises.DataBind();
                    }
                    else
                    {
                        msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                        msgMessage.Text = "متاسفانه در حذف آگهی خطایی رخ داده است.";

                    }

                }

            }
            #endregion
            #region Update
            if (e.CommandName == "Update")
            {
                int Code = Convert.ToInt32(btnDelete.Attributes["Code"]);
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
                TimeSpan DateDiff = DateTime.Now.AddDays(AddDay) - (DateTime)CurAdver.ExpDate;
                if (DateDiff.Days < 1)
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.Attributes["disabled"] = "disabled";
                    return;
                }

                //DateTime NewExpDate = ((DateTime)CurAdver.ExpDate).AddDays(AddDay);
                DateTime NewExpDate = (DateTime.Now).AddDays(AddDay);
                AdvertisesBOL.UpdateExpDate(Code, NewExpDate);
                DateTimeMethods dtm = new DateTimeMethods();

                msgItem.Text = "آگهی با موفقیت تا تاریخ " + Tools.ChageEnc(dtm.GetPersianLongDate(NewExpDate)) + "بروز شد.";
                lblExpDate.Text = Tools.ChageEnc(dtm.GetPersianDate(NewExpDate));

                btnUpdate.Enabled = false;
                btnUpdate.Attributes["disabled"] = "disabled";

            }
            #endregion
            #region Make Special
            if (e.CommandName == "MakeSpecial")
            {
                int Code = Convert.ToInt32(btnDelete.Attributes["Code"]);
                Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(Code);
                Panel pnlSpecialAds = (Panel)e.Item.Controls[1].FindControl("pnlSpecialAds");
                TextBox txtDecilCount = (TextBox)e.Item.Controls[1].FindControl("txtDecilCount");

                pnlSpecialAds.Visible = true;
                
                string strScript = "$('html, body').animate({ scrollTop: $(\"#" + btnMakeSpecial.ClientID +  "\").offset().top }, 1000);";
                strScript += @"$('#" + txtDecilCount.ClientID + @"').stepper({
                                                    wheel_step: 1,
                                                    arrow_step: 1,
                                                    onStep: CalcAmount,
                                                    limit: [1, ]
                                                });";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PreparePayment", strScript, true);


            }
            #endregion
            #region Make Special
            if (e.CommandName == "ActivateLink")
            {
                int Code = Convert.ToInt32(btnDelete.Attributes["Code"]);
                Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(Code);
                Panel pnlActivateLink = (Panel)e.Item.Controls[1].FindControl("pnlActivateLink");
                pnlActivateLink.Visible = true;

                string strScript = "$('html, body').animate({ scrollTop: $(\"#" + btnMakeSpecial.ClientID + "\").offset().top }, 1000);";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PreparePayment", strScript, true);

            }
            #endregion
            #region Make Payment
            if (e.CommandName == "MakePayment")
            {
                try
                {


                    DropDownList ddlBankCode = (DropDownList)e.Item.Controls[1].FindControl("ddlBankCode");
                    TextBox txtDecilCount = (TextBox)e.Item.Controls[1].FindControl("txtDecilCount");

                    int AdsCode = Convert.ToInt32(btnDelete.Attributes["Code"]);
                    int BankCode = Convert.ToInt32(ddlBankCode.SelectedValue);
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
                                msgItem.Text = "خطا در برقراری ارتباط با سرور بانک ملی";
                                msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                                return;
                            }

                        }
                        catch (Exception err)
                        {
                            msgItem.Text = "خطا در برقراری ارتباط با سرور بانک ملی" + err.Message;
                            msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
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
                                msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                                msgItem.Text = "خطا ذخیره داده های تراکنش بانک پارسیان" + " کد خطا: " + Status;
                                return;
                            }
                        }
                        else
                        {
                            msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                            msgItem.Text = "خطا در برقراری ارتباط با بانک پارسیان" + " کد خطا: " + Status;
                            return;
                        }
                    }
                    #endregion
                }
                catch (Exception errPay)
                {
                    msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgItem.Text = "خطا در برقراری ارتباط با بانک " + errPay.Message;
                    return;

                }
            }
            
            #endregion

            #region Make Payment
            if (e.CommandName == "MakeActivateLinkPayment")
            {
                try
                {
                    DropDownList ddlActivateLinkBankCode = (DropDownList)e.Item.Controls[1].FindControl("ddlActivateLinkBankCode");
                    TextBox txtDecilCount = (TextBox)e.Item.Controls[1].FindControl("txtDecilCount");

                    int AdsCode = Convert.ToInt32(btnDelete.Attributes["Code"]);
                    int BankCode = Convert.ToInt32(ddlActivateLinkBankCode.SelectedValue);
                    string UserIP = Request.UserHostAddress;
                    int AddAmount = 30000;

                    BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(UserCode);
                    int UserTransactionCode = UserTransactionsBOL.Insert(UserCode, DateTime.Now, 1, 1, UserIP, AddAmount, 7, 0, AdsCode, BankCode);
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
                                msgItem.Text = "خطا در برقراری ارتباط با سرور بانک ملی";
                                msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                                return;
                            }

                        }
                        catch (Exception err)
                        {
                            msgItem.Text = "خطا در برقراری ارتباط با سرور بانک ملی" + err.Message;
                            msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
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
                                msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                                msgItem.Text = "خطا ذخیره داده های تراکنش بانک پارسیان" + " کد خطا: " + Status;
                                return;
                            }
                        }
                        else
                        {
                            msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                            msgItem.Text = "خطا در برقراری ارتباط با بانک پارسیان" + " کد خطا: " + Status;
                            return;
                        }
                    }
                    #endregion
                }
                catch (Exception errPay)
                {
                    msgItem.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgItem.Text = "خطا در برقراری ارتباط با بانک " + errPay.Message;
                    return;

                }
            }

            #endregion
        
        }

        public bool IsActivateLinkVis(Object Link, Object LinkActivated)
        {
            if (Link != null)
            {
                if (Link.ToString() != "")
                {
                    if (LinkActivated != null)
                    {
                        if (!Convert.ToBoolean(LinkActivated))
                            return true;
                    }
                    else
                        return true;
                }
            }

            return false;
        }

        public bool IsPayOrderDisabled(Object objHCTransStatusCode)
        {
            bool Result = false;
            if (objHCTransStatusCode != null)
            {
                int HCTransStatusCode = Convert.ToInt32(objHCTransStatusCode);
                if (HCTransStatusCode == 2)
                    Result = false;
                else
                    Result = true;
            }
            else
                Result = true;
            return Result;
        }

        public string PayDisbaled(Object objHCTransStatusCode)
        {
            string Result = "";
            if (objHCTransStatusCode != null)
            {
                int HCTransStatusCode = Convert.ToInt32(objHCTransStatusCode);
                if (HCTransStatusCode == 2)
                    Result = "disabled";
                else
                    Result = "";
            }
            else
                Result = "";
            return Result;
        }
        


        public string ShowLink(Object obj, Object objCode)
        {
            string Result = "";
            if (obj != null)
            {
                int HCTransStatusCode = Convert.ToInt32(obj);
                if (HCTransStatusCode == 1)
                {
                    Result = "<a href=\"" + Page.ResolveUrl("~/Users/EditFish.aspx?Code=" + objCode.ToString()) + "\">ویرایش</a>";
                }
            }
            return Result;
        }





        protected void rptMyOrders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            OrderCounter++;
        }

        protected void rptFavorites_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            FavCounter++;
        }
    }
}
