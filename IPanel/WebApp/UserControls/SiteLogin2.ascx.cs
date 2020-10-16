using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Decili.Code.DAL;

public partial class UserControls_SiteLogin2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtPassword.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + ImageButton1.ClientID + "').click();return false;}} else {return true}; ");
        //Page.Form.DefaultButton = "ImageButton1";


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string ReadAccess = "";
        string RWAccess = "";
        string UserCode;

        BOLUsers bolUsers = new BOLUsers();
        Users CurUser = bolUsers.GetUserInfo(txtUsername.Text);
        if (CurUser != null)
        {
            if (CurUser.Password == Tools.Encode(txtPassword.Text))
            {
                UserCode = CurUser.Code.ToString();

                Session["FirstName"] = CurUser.FirstName;
                Session["LastName"] = CurUser.LastName;
                Session["PicFile"] = CurUser.PicFile;

                Session["Username"] = txtUsername.Text;
                Session["UserCode"] = UserCode;


                int GenderCode = (int)CurUser.HCGenderCode;
                if (GenderCode == 1)
                    Session["Gender"] = "آقای";
                else
                    Session["Gender"] = "خانم";


                Response.Redirect("~/Default.aspx");
            }
            else
                lblMessage.Text = Messages.ShowMessage(MessagesEnum.InvalidUsernameORPassword);

        }
        else
            lblMessage.Text = Messages.ShowMessage(MessagesEnum.InvalidUsernameORPassword);
    }
}
