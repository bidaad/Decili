using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Decili.Code.DAL;
using System.Configuration;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for EmailTools
/// </summary>
public class EmailTools
{
	public EmailTools()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool IsValidEmail(string CurEmail)
    {
        string _pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        Regex r = new Regex(_pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Match m = r.Match(CurEmail);
        if (m.Success)
            return true;
        else
            return false;
    }
    public string LoadTemplate(int Code)
    {
        UtilDataContext dc = new UtilDataContext();
        EmailTemplates CurTemplate = dc.EmailTemplates.SingleOrDefault(p => p.Code.Equals(Code));
        if (CurTemplate != null)
            return CurTemplate.Template;
        else
            return null;
    }

    public string LoadTemplate(string Title)
    {
        UtilDataContext dc = new UtilDataContext();
        EmailTemplates CurTemplate = dc.EmailTemplates.SingleOrDefault(p => p.Title.Equals(Title));
        if (CurTemplate != null)
            return CurTemplate.Template;
        else
            return null;
    }


    public bool SendAdActivation(int AdsCode)
    {
        bool SendResult = false;
        try
        {
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            Advertises Ads = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(AdsCode);
            UtilDataContext dcUtil = new UtilDataContext();
            AccessLevelDataContext dcUser = new AccessLevelDataContext();

            EmailTemplates CurTemplate = dcUtil.EmailTemplates.SingleOrDefault(p => p.Title.Equals("AdActivation"));
            if (CurTemplate != null)
            {
                Users AdUser = dcUser.Users.SingleOrDefault(p => p.Code.Equals(Ads.UserCode));
                string SiteDomain = ConfigurationSettings.AppSettings["SiteDomain"];
                Tools tools = new Tools();
                string MsgBody = CurTemplate.Template;

                if (CurTemplate != null)
                {
                    DateTimeMethods dtm = new DateTimeMethods();

                    MsgBody = CurTemplate.Template;
                    MsgBody = MsgBody.Replace("[RecFirstName]", AdUser.FirstName);
                    MsgBody = MsgBody.Replace("[UserFullName]", AdUser.FirstName + " " + AdUser.LastName);
                    MsgBody = MsgBody.Replace("[AdTitle]", Ads.Title);
                    MsgBody = MsgBody.Replace("[AdExpDate]", dtm.GetPersianDate((DateTime)Ads.ExpDate));
                    MsgBody = MsgBody.Replace("[AdLink]", SiteDomain + "Ads/" + Ads.ID + ".html");
                }

                string MsgSubject = "دسیلی :: آگهی شما فعال شد";
                SendResult = tools.SendEmail(MsgBody, MsgSubject, "<noreply@Decili.ir>", AdUser.Email, "", "");
                BOLEmails EmailsBOL = new BOLEmails();
                EmailsBOL.Insert(AdUser.Email, 3, MsgBody);
            }
            return SendResult;
        }
        catch
        {
            return false;
        }

    }
}
