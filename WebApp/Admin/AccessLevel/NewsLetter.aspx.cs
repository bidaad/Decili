using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.Admin.AccessLevel
{
    public partial class NewsLetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int Counter = 0;
            ParsetDataContext dc = new ParsetDataContext();

            var Result = dc.Users.Where(p => p.RegDate != null);


            Tools tools = new Tools();

            foreach (var item in Result)
            {
                string MailBody = @"<div>
        <div style=""font-family:Tahoma; font-size:13px; direction: rtl; text-align:right"">
          <b > کاربر گرامی،  " + item.FirstName + " " + item.LastName + @" </b >
             <br ><br >
             برای مدیریت آگهی های خود در نیازمندی های دسیلی از لینک زیر استفاده فرمایید:
<br ><br >
<div >
    <div style = ""border-collapse:collapse;border-radius:2px;text-align:center;display:block;border:solid 1px #344c80;background:#4c649b;padding:7px 16px 11px 16px"" ><a href =""http://ipanel.decili.ir/Users/Login.aspx?ID=" + item.ID + @""" style = ""color:#3b5998;text-decoration:none;display:block"" target=""_blank"" data -  ><center><font size =""3"" ><span style =""font-family:Tahoma;white-space:nowrap;font-weight:bold;vertical-align:middle;color:#ffffff;font-size:14px;line-height:14px"" > مدیریت آگهی </span ></font ></center ></a ></div >
                           </div>
                           </div>
                               </div > ";
                bool SendResult = tools.SendEmail(MailBody, "نیازمندی های دسیلی - " + item.FirstName + " " + item.LastName, "info@decili.ir", item.Email, "", "");
                Counter++;

                Response.Write(Counter + "<BR>");
                Response.Flush();
            }


        }
    }
}