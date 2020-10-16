﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Decili.Code.DAL;
using System.Reflection;
using System.Globalization;
using System.Data;

namespace Decili
{
    public partial class RootSecond : System.Web.UI.MasterPage
    {
        public string Header = "";
        public string strTypingNews = "";
        public string StartHour = "";
        public string StartMinute = "";
        public string StartSecond = "";
        public string SearchCaption = "جستجو";
        public string strKeyword = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            DateTimeMethods dtm = new DateTimeMethods();
            try
            {
                //Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnSend);
                BOLLogs LogsBOL = new BOLLogs();
                int? Result = 1;
                string UserCode = "";
                if (Session["UserCode"] != null)
                {
                    UserCode = Session["UserCode"].ToString();

                    pnlLoginLinks.Visible = false;
                    pnlLoggedUserLinks.Visible = true;

                    hplProfile.Text = Session["UserFullName"].ToString() + "<span class=\"fa fa-user fa-20 Gray\"></span>";

                    //lblPublicUserMessage.Visible = false;
                    //lblLoggedUserMessage.Visible = true;
                    //lblLoggedUserMessage.Text = "سلام، " + Session["UserFullName"].ToString();
                }

                bool HCReqTypeCode = false;
                string UserAgent = HttpContext.Current.Request.UserAgent;

                if (Tools.GetCrawelerUserAgents().Contains(UserAgent))
                    HCReqTypeCode = true;

                Result = LogsBOL.InsertLog(Request.UserAgent, Request.QueryString.ToString(), UserCode, Request.UserHostAddress, Request.Url.AbsolutePath, Tools.GetIranDate(), Page.Request.ServerVariables["http_referer"],HCReqTypeCode, ref Result);
                if (Result == 0)
                    Response.End();

                strKeyword = Request["Keyword"];


            }
            catch
            {
            }


            if (!Page.IsPostBack)
            {
                //this.form1.DefaultButton = ImageButton1.UniqueID;
                //txtKeyword.Attributes.Add("onblur", "this.className='Keyword';if(this.value == '') this.value = '" + "جستجو ..." + "';");

                DateTime CurDT = DateTime.Now;
                StartHour = CurDT.Hour.ToString();
                StartMinute = CurDT.Minute.ToString();
                StartSecond = CurDT.Second.ToString();


                lblPersianDate.Text = "امروز " + Tools.ChangeEnc(dtm.GetPersianLongDate(DateTime.Now));
                lblGerigorianDate.Text = DateTime.Now.ToString("ddd d MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));

                /*
                if (Request["Logout"] != "1")
                {
                    #region Try Login

                    try
                    {
                        if (Session["Username"] == null)
                        {
                            if (Request.Cookies["Decili"] != null && Session["AlreadyTryLogin"] != "1")
                            {
                                string Email = Request.Cookies["Decili"]["DeciliUser"];
                                string Password = Request.Cookies["Decili"]["DeciliPass"];

                                BOLUsers BOLUsers = new BOLUsers();
                                Users ValidUser = BOLUsers.GetDataByEmail(Email);

                                if (ValidUser != null)
                                {
                                    string HashedPass = Tools.GetHashString(Password);
                                    string DBPassword = ValidUser.Password;
                                    if (HashedPass == DBPassword && (bool)ValidUser.Active)
                                    {
                                        //BOLUsers.UpdateLastLoginTime(ValidUser.Code);
                                        Session["UserCode"] = ValidUser.Code;
                                        Session["Email"] = ValidUser.Email;
                                        Session["UserFullName"] = ValidUser.FirstName + " " + ValidUser.LastName;
                                    }
                                    else
                                        Session["AlreadyTryLogin"] = "1";
                                }
                                else
                                    Session["AlreadyTryLogin"] = "1";
                            }

                        }

                    }
                    catch
                    {
                    }
                    #endregion
                }
                */

                //UCSelectedProducts1.ShowSelectedProducts();
                //UCSelectedProducts2.ShowRelatedProducts();

            }


            #region Load Scripts
            HtmlGenericControl scriptJQuery = new HtmlGenericControl("script");
            scriptJQuery.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/jquery.js"));
            scriptJQuery.Attributes.Add("type", "text/javascript");
            Page.Header.Controls.Add(scriptJQuery);


            HtmlGenericControl scriptBootstrap = new HtmlGenericControl("script");
            scriptBootstrap.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/bootstrap.min.js"));
            scriptBootstrap.Attributes.Add("type", "text/javascript");
            Page.Header.Controls.Add(scriptBootstrap);


            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/Decili.main.js"));
            script.Attributes.Add("type", "text/javascript");
            Page.Header.Controls.Add(script);


            //HtmlGenericControl scriptCycle = new HtmlGenericControl("script");
            //scriptCycle.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/jquery.cycle.all.js"));
            //scriptCycle.Attributes.Add("type", "text/javascript");
            //Page.Header.Controls.Add(scriptCycle);

            //HtmlGenericControl scriptTicker = new HtmlGenericControl("script");
            //scriptTicker.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/jquery.ticker.js"));
            //scriptTicker.Attributes.Add("type", "text/javascript");
            //Page.Header.Controls.Add(scriptTicker);

            //HtmlGenericControl scriptprettyPhoto = new HtmlGenericControl("script");
            //scriptprettyPhoto.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/jquery.prettyPhoto.js"));
            //scriptprettyPhoto.Attributes.Add("type", "text/javascript");
            //Page.Header.Controls.Add(scriptprettyPhoto);


            HtmlGenericControl scripthoverIntent = new HtmlGenericControl("script");
            scripthoverIntent.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/hoverIntent.js"));
            scripthoverIntent.Attributes.Add("type", "text/javascript");
            Page.Header.Controls.Add(scripthoverIntent);

            //HtmlGenericControl themepunch1 = new HtmlGenericControl("script");
            //themepunch1.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/jquery.themepunch.plugins.min.js"));
            //themepunch1.Attributes.Add("type", "text/javascript");
            //Page.Header.Controls.Add(themepunch1);

            //HtmlGenericControl themepunch2 = new HtmlGenericControl("script");
            //themepunch2.Attributes.Add("src", this.ResolveClientUrl("https://cdn.Decili.ir/Scripts/jquery.themepunch.revolution.min.js"));
            //themepunch2.Attributes.Add("type", "text/javascript");
            //Page.Header.Controls.Add(themepunch2);


            #endregion




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

        //protected void ImageButton1_Click(object sender, EventArgs e)
        //{
        //    if (txtKeyword.Text.Trim() != "")
        //        Response.Redirect("~/?Keyword=" + txtKeyword.Text);
        //}


    }
}