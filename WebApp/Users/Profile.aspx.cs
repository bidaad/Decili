using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.Check();
            int UserCode = Convert.ToInt32(Session["UserCode"]);
            if (!Page.IsPostBack)
            {

                cboGenderCode.DataSource = new BOLHardCode().GetHCDataTable("HCGenders");
                cboGenderCode.DataBind();

                BOLUsers UsersBOL = new BOLUsers();
                Users CurUser = UsersBOL.GetUserByEmail(Session["Email"].ToString());

                txtFirstName.Text = CurUser.FirstName;
                txtLastName.Text = CurUser.LastName;
                txtEmail.Text = CurUser.Email;
                txtPassword.Attributes["value"] = "******";
                txtConfirmPassword.Attributes["value"] = "******";
                cboGenderCode.SelectedValue = CurUser.HCGenderCode.ToString();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int UserCode = Convert.ToInt32(Session["UserCode"]);

            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            string ConfirmPassword = txtConfirmPassword.Text;



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


            UsersBOL.Update(UserCode, FirstName, LastName, Email, Password, GenderCode);
            if (UserCode != -1)
            {
                msgMessage.MessageTextMode = AKP.Web.Controls.Common.MessageMode.OK;
                msgMessage.Text = "تغییرات با موفقیت انجام شد.";
            }

        }


    }
}