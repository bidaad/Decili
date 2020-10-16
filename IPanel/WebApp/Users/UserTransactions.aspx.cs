using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UsersFolder
{
    public partial class UserTransactionsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                        Security.Check();
            int UserCode = Convert.ToInt32(Session["UserCode"]);

            if (!Page.IsPostBack)
            {

                BOLUsers UsersBOL = new BOLUsers();
                Users CurUser = UsersBOL.GetUserByEmail(Session["Email"].ToString());

                BOLUserTransactions UserTransactionsBOL = new BOLUserTransactions(UserCode);
                rptTransList.DataSource = UserTransactionsBOL.GetUserTrans(UserCode);
                rptTransList.DataBind();

            }
        }

        public string ShowAmount(Object obj)
        {
            string Result = "";
            if (obj != null)
            {
                int Val = Convert.ToInt32(obj);
                if (Val < 0)
                    Val = -1 * Val;
                Result = Tools.ChageEnc(Tools.FormatCurrency(Val));
            }
            return Result;
        }

        public string ShowPayDirection(Object obj)
        {
            string Result = "";
            if (obj != null)
            {
                int Val = Convert.ToInt32(obj);
                if (Val < 0)
                    Result = "برداشت از حساب";
                else
                    Result = "واریز به حساب";
            }
            return Result;
        }

        public string ShowClass(Object obj)
        {
            string Result = "";
            if (obj != null)
            {
                int Val = Convert.ToInt32(obj);
                if (Val < 0)
                    Result = "DeductFromAccount";
                else
                    Result = "AddToAccount";
            }
            return Result;
        }

    }
}