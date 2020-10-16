using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Decili.Code.DAL;

/// <summary>
/// Summary description for BOLEmails
/// </summary>
public class BOLEmails
{
	public BOLEmails()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Insert(string Email, int HCSectionCode, string Comment)
    {
        EmailDataContext dc = new EmailDataContext();
        Emails NewEmail = new Emails();
        dc.Emails.InsertOnSubmit(NewEmail);
        NewEmail.PersonEmail = Email;
        NewEmail.HCSectionCode = HCSectionCode;
        NewEmail.Comment = Comment;
        dc.SubmitChanges();
    }
}
