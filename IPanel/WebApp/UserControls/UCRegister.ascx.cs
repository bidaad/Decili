using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCRegister : System.Web.UI.UserControl
    {
        protected string _afterRegUrl = null;
        public string AfterRegUrl
        {
            set
            {
                _afterRegUrl = value;

            }
            get
            {
                return _afterRegUrl;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ((System.Web.UI.HtmlControls.HtmlForm)Page.Master.FindControl("form1")).DefaultButton = btnSubmit.UniqueID;

                cboGenderCode.DataSource = new BOLHardCode().GetHCDataTable("HCGenders");
                cboGenderCode.DataBind();

                string RefPage = Request["RefPage"];
                if (!string.IsNullOrEmpty(RefPage))
                    ViewState["RefPage"] = RefPage;

            }
            msgMessage.Text = "";
        }

        protected void btnBackToRefPage_Click(object sender, EventArgs e)
        {
            if (ViewState["RefPage"] != null)
                Response.Redirect(ViewState["RefPage"].ToString());
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            string ConfirmPassword = txtConfirmPassword.Text;

            if (!RadCaptcha1.IsValid)
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgMessage.Text = "کد امنیتی اشتباه است.";
                return;
            }

            string strGenderCode = cboGenderCode.SelectedValue;
            int GenderCode = 0;
            Int32.TryParse(strGenderCode, out GenderCode);

            if (string.IsNullOrEmpty(FirstName))
            {
                msgMessage.Text = "لطفا نام را وارد کنید";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                msgMessage.Text = "لطفا نام خانوادگی را وارد کنید";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }
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

            if (Password != ConfirmPassword)
            {
                msgMessage.Text = "کلمه عبور و تایید کلمه عبور با یکدیگر برابر نیستند";
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                return;
            }

            BOLUsers UsersBOL = new BOLUsers();
            if (UsersBOL.EmailExists(Email))
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgMessage.Text = "این ایمیل قبلا ثبت شده است. در صورتی که صاحب این ایمیل میباشید کافی است با کلیک بر روی <a style=\"color:white\" href=\"ForgotPassword.aspx\">فراموشی کلمه عبور</a> ایمیل خود را وارد کنید تا لینک بازیابی برای شما ارسال شود.";
                return;
            }

            int UserCode = UsersBOL.InsertRecord(FirstName, LastName, Email, Password, GenderCode);

            Session["UserCode"] = UserCode;
            Session["Email"] = Email;
            Session["UserFullName"] = FirstName + " " + LastName;
            if (GenderCode == 1)
                Session["Gender"] = "آقای";
            else
                Session["Gender"] = "خانم";

            EmailTools emailTools = new EmailTools();
            Tools tools = new Tools();
            string EmailTemplate = emailTools.LoadTemplate("DeciliUserRegister");//Suggest
            if (EmailTemplate != null)
            {
                EmailTemplate = EmailTemplate.Replace("[UserFullName]", Session["Gender"] + " " + Session["UserFullName"]);
                bool SendSellResult = tools.SendEmail(EmailTemplate, "ثبت نام شما در دسیلی با موفقیت انجام شد", "info@Decili.ir", txtEmail.Text, "bidaad@gmail.com", "");
            }


            if (_afterRegUrl != null)
                Response.Redirect(_afterRegUrl);

            if (UserCode != -1)
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
                msgMessage.Text = "ثبت نام شما با موفقیت انجام شد.";
                btnBackToRefPage.Visible = true;
            }
            else
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                msgMessage.Text = "بروز خطا در فرایند ثبت نام";
            }

        }
    }
}