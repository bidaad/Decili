using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request["ID"];
            if(!string.IsNullOrEmpty(ID))
            {

                try
                {
                    BOLUsers UsersBOL = new BOLUsers();
                    Users CurUser = UsersBOL.GetDataByID(ID);
                    if (CurUser != null)
                    {
                        Response.Cookies["Decili"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Decili"]["DeciliUser"] = CurUser.Email;

                        Response.Cookies["Decili"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Decili"]["DeciliPass"] = Tools.Decode(CurUser.Password);


                        Session["UserCode"] = CurUser.Code;
                        Session["Email"] = CurUser.Email;
                        Session["UserFullName"] = CurUser.FirstName + " " + CurUser.LastName;

                        Response.Redirect("~/Users");
                    }

                }
                catch(Exception err)
                {
                    Response.Write(err);

                }
            }


        }
    }
}