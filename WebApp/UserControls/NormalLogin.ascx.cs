using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decili.Code.DAL;

namespace IONS.UserControls
{
    public partial class NormalLogin : System.Web.UI.UserControl
    {
        protected string _afterLoginUrl = null;
        public string AfterLoginUrl
        {
            set
            {
                _afterLoginUrl = value;
                    
            }
            get
            {
                return _afterLoginUrl;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            msgMessage.Text = "";
            if (!Page.IsPostBack)
            {
                ((System.Web.UI.HtmlControls.HtmlForm)Page.Master.FindControl("form1")).DefaultButton = btnSubmit.UniqueID;

                string Referer = Request["RefPage"];
                
                ViewState["Referer"] = Referer;

                if (Request.Cookies["Decili"] != null)
                {
                    string Username = Request.Cookies["Decili"]["DeciliUser"];
                    if (Username != "")
                    {
                        txtEmail.Text = Username;
                        chkRemember.Checked = true;
                    }
                    else
                        chkRemember.Checked = false;
                }
                if (Request.Cookies["Decili"] != null)
                {
                    string Password = Request.Cookies["Decili"]["DeciliPass"];
                    if (Password != "")
                    {
                        txtPassword.Attributes.Add("value", Request.Cookies["Decili"]["DeciliPass"]);
                        chkRemember.Checked = true;
                    }
                    else
                        chkRemember.Checked = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;

            string EncUsername = Tools.Encode(Email);
            string EncPassword = Tools.Encode(Password);

            Response.Redirect("http://ipanel.decili.ir/Users/Login.aspx?EncUsername=" + Server.UrlEncode(EncUsername) + "&EncPassword=" + Server.UrlEncode(EncPassword));
            return;


            if (string.IsNullOrEmpty(Email))
            {
                msgMessage.Text = "لطفا ایمیل را وارد کنید";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                msgMessage.Text = "لطفا کلمه عبور را وارد کنید";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }

            BOLUsers UsersBOL = new BOLUsers();
            string strEncPass = Tools.Encode(Password);
            Users CurUser = UsersBOL.GetUserByEmail(Email);
            if (CurUser == null)
            {
                msgMessage.Text = "ایمیل اشتباه است";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }


            if (strEncPass != CurUser.Password)
            {
                msgMessage.Text = "کلمه عبور اشتباه است";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }

            if (chkRemember.Checked)
            {
                Response.Cookies["Decili"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Decili"]["DeciliUser"] = Email;

                Response.Cookies["Decili"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Decili"]["DeciliPass"] = txtPassword.Text;
            }
            else
            {
                Response.Cookies["Decili"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Decili"]["DeciliUser"] = "";

                Response.Cookies["Decili"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Decili"]["DeciliPass"] = "";
            }


            Session["UserCode"] = CurUser.Code;
            Session["Email"] = CurUser.Email;
            Session["UserFullName"] = CurUser.FirstName + " " + CurUser.LastName;

            //Response.Redirect("~/Default.aspx");


            if (_afterLoginUrl != null)
            {
                Response.Redirect(_afterLoginUrl);
            }
            else
            {
                if (ViewState["Referer"] != null)
                {
                    if (!ViewState["Referer"].ToString().Contains("Users/Login.aspx"))
                        Response.Redirect(ViewState["Referer"].ToString());
                    else
                        Response.Redirect("http://ipanel.decili.ir/Users/");
                }
                else
                    Response.Redirect("http://ipanel.decili.ir/Users");
            }


        }


        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://ipanel.decili.ir/Users/Register.aspx?RefPage=" + ViewState["Referer"]);

        }

    }
}
