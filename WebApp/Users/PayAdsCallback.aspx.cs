using Decili.Code.Common;
using Decili.Code.DAL;
using Decili.ir.bmi.bmiutility4;
using Decili.ir.shaparak.pec;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
{
    public partial class PayAdsCallback : System.Web.UI.Page
    {
        public string BMITransactionKey = ConfigurationManager.AppSettings["BMITransactionKey"];
        public string CardAcqID = ConfigurationManager.AppSettings["BMIMerchantID"];
        public string TerminalId = ConfigurationManager.AppSettings["BMITerminalID"];
        public string ReturnURL = ConfigurationManager.AppSettings["BMIReturnURL"];
        public string ServiceURL = ConfigurationManager.AppSettings["BMIServiceURL"];


        string strOrderId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Parsian
            string strAuthority = Request["au"];
            string strStatus = Request["rs"];
            if (strAuthority != "" && strAuthority != null) //Parsian Bank
            {
                ParsianComplete(strAuthority, strStatus);
            }
            #endregion

            #region Melli
            string strFP = HttpContext.Current.Request.Form["FP"];
            strOrderId = HttpContext.Current.Request.Form["OrderId"];
            string strTimeStamp = HttpContext.Current.Request.Form["TimeStamp"];
            long OrderId = Convert.ToInt64(strOrderId);
            if (!string.IsNullOrEmpty(strOrderId))
            {
                MelliComplete(OrderId);
            }
            #endregion

        }

        private void ParsianComplete(string strAuthority, string strStatus)
        {
            BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(1);
            vUserTransactions CurTrans = UserTransactionsBOL.GetTransByAuthority(strAuthority);

            if (CurTrans != null)
            {
                if (CurTrans.HCTransStatusCode == 2)
                {
                    msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Warning;
                    msgMessage.Text = "این تراکنش قبلا تایید شده است.";
                    return;
                }
                byte Status = 1;
                EShopService ParsianService = new EShopService();
                ParsianService.PinPaymentEnquiry(ConfigurationManager.AppSettings["ParsianPin"], Convert.ToInt64(strAuthority), ref Status);
                if (Status == 0)
                {
                    msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
                    msgMessage.Text = "پرداخت با موفقیت انجام شد.";

                    UserTransactionsBOL.UpdateStatus(CurTrans.Code, 2);
                    BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                    int AdsCode = Convert.ToInt32(CurTrans.ItemCode);

                    DateTime NextMonth = DateTime.Now.AddDays(3);
                    DateTimeMethods dtm = new DateTimeMethods();
                    if (CurTrans.HCPayReasonCode == 6)
                    {
                        int DecilCount = Convert.ToInt32(CurTrans.DecilCount);
                        bool UpdateAdsResult = AdvertisesBOL.UpdateRate(AdsCode, DecilCount);
                        msgMessage.Text += " آگهی شما تا تاریخ " + dtm.GetPersianDate(NextMonth) + " بصورت ویژه به  نمایش در می آید";
                    }
                    else if (CurTrans.HCPayReasonCode == 7)
                    {
                        bool UpdateAdsResult = AdvertisesBOL.UpdateLinkActivation(AdsCode);
                        msgMessage.Text += " لینک آگهی تا تاریخ " + dtm.GetPersianDate(NextMonth) + " فعال شد.";
                    }

                    vAdvertises CurAds = AdvertisesBOL.GetAdsByCode(AdsCode);
                    HttpContext context = HttpContext.Current;
                    context.Cache["GetAdsByID" + CurAds.ID] = "";
                    return;
                }
                else
                {
                    msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgMessage.Text = "مشترک گرامی، پرداخت الکترونیک شما با موفقیت انجام نشد، این مشکل معمولاً در مواردی رخ می‌دهد که شما در صفحه بانک پرداخت را تایید نمی‌کنید، در حساب خود به اندازه کافی موجودی ندارید، مشکلی در برقرار ارتباط با بانک بوجود آمده و ... در هر صورت جای نگرانی وجود ندارد، چرا که هیچ وجهی از حساب شما کسر نشده است.. کد خطا:" + strStatus;
                }

            }
            else
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgMessage.Text = "مشترک گرامی، پرداخت الکترونیک شما با موفقیت انجام نشد، این مشکل معمولاً در مواردی رخ می‌دهد که شما در صفحه بانک پرداخت را تایید نمی‌کنید، در حساب خود به اندازه کافی موجودی ندارید، مشکلی در برقرار ارتباط با بانک بوجود آمده و ... در هر صورت جای نگرانی وجود ندارد، چرا که هیچ وجهی از حساب شما کسر نشده است.. کد خطا:" + strStatus;
            }

        }

        private void MelliComplete(long OrderId)
        {
            try
            {
                int UserCode = 0;

                BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(UserCode);
                UserTransactions CurTrans = UserTransactionsBOL.GetTransactionByCode(OrderId);

                if (CurTrans != null)
                {
                    if (CurTrans.HCTransStatusCode == 2)
                    {
                        msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                        msgMessage.Text = "این سفارش قبلا تایید شده است.";
                        return;
                    }

                    UserCode = (int)CurTrans.UserCode;
                    string _RefNo, Appstatus, RealTransactionDateTime;

                    MerchantUtility utl = new MerchantUtility();

                    ///You Can Change Your Line Here
                    utl.Url = ServiceURL;
                    int AppStatusCode = utl.CheckRequestStatusWithRealTransactionDateTime(OrderId, CardAcqID,
                                                                TerminalId, BMITransactionKey,
                                                                CurTrans.BMIRequestKey, Convert.ToInt64(CurTrans.Amount),
                                                                out _RefNo, out Appstatus, out RealTransactionDateTime);

                    if (AppStatusCode == 0)
                    {
                        int OrderCode;
                        Int32.TryParse(strOrderId, out OrderCode);
                        bool UpdateResult = UserTransactionsBOL.UpdateStatus(OrderCode, 2);
                        if (UpdateResult)
                        {
                            try
                            {
                                string RefNo = "";
                                string AppStatus = "";
                                int AppStatusCode2 = utl.CheckRequestStatus(CurTrans.Code, CardAcqID, TerminalId, BMITransactionKey, CurTrans.BMIRequestKey, (int)CurTrans.Amount, out RefNo, out AppStatus);
                                if (AppStatus == "COMMIT")
                                {

                                    string RealRefNo = RefNo.ToString().Substring(8, 6);
                                    UserTransactionsBOL.UpdateFishno(CurTrans.Code, RealRefNo);

                                }
                            }
                            catch
                            {
                            }

                            BOLUsers UsersBOL = new BOLUsers();
                            int CurrentBalance = UsersBOL.GetBalance(UserCode);

                            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
                            msgMessage.Text = "تراکنش با موفقیت انجام شد.";

                            int AdsCode = Convert.ToInt32(CurTrans.ItemCode);
                            BOLAdvertises AdvertisesBOL = new BOLAdvertises();

                            if (CurTrans.HCPayReasonCode == 6)
                            {
                                int DecilCount = Convert.ToInt32(CurTrans.DecilCount);
                                bool UpdateAdsResult = AdvertisesBOL.UpdateRate(AdsCode, DecilCount);
                                if (UpdateAdsResult)
                                    msgMessage.Text += " تعداد دسی آگهی شما در حال حاضر " + DecilCount + " میباشد";
                            }
                            else
                            {
                                bool UpdateAdsResult = AdvertisesBOL.UpdateLinkActivation(AdsCode);
                                msgMessage.Text += " لینک آگهی فعال شد.";
                            }


                            //try
                            //{
                            //    long intCelPhone = 0;
                            //    if (CurOrder.CellPhone.Length == 11)
                            //    {
                            //        if (CurOrder.CellPhone.StartsWith("0"))
                            //        {
                            //            intCelPhone = Convert.ToInt64(CurOrder.CellPhone.Substring(1, CurOrder.CellPhone.Length - 1));
                            //            SMSHelper sHelper = new SMSHelper();
                            //            sHelper.SendSingleSMS(intCelPhone, "سفارش شما در سایت کانلاین با موفقیت ثبت شد. کد پیگیری: " + InternalOrderID);
                            //            sHelper.SendSingleSMS(9123141876, "سفارش شما در سایت کانلاین با موفقیت ثبت شد. کد پیگیری: " + InternalOrderID);
                            //            sHelper.SendSingleSMS(9123209794, "سفارش شما در سایت کانلاین با موفقیت ثبت شد. کد پیگیری: " + InternalOrderID);
                            //        }
                            //    }
                            //}
                            //catch
                            //{
                            //}

                            return;
                        }
                        else
                        {
                            msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                            msgMessage.Text = "بروز خطا :: ";
                            return;
                        }

                    }
                    else
                    {
                        msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                        msgMessage.Text = "تراکنش شما در سایت بانک ملی با موفقیت همراه نبود";
                        return;
                    }
                }
                else
                {
                    msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgMessage.Text += "تراکنش شما در سایت بانک موفقیت آمیز نبود";
                    return;
                }
            }
            catch (Exception ex)
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgMessage.Text += "بروز خطا : " + ex.Message + "<BR>";
                return;
            }
        }
    }
}
