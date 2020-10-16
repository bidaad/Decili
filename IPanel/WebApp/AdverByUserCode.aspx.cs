using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class AdverByUserCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strID = Request["ID"];

                if ( !string.IsNullOrEmpty(strID))
                {
                    BOLUsers UsersBOL = new BOLUsers();
                    Users CurAdsUser = UsersBOL.GetUserInfoByID(strID);
                    if (CurAdsUser == null)
                        return;
                    int UserCode = CurAdsUser.Code;

                    int PageNo = 1;
                    string strPageNo = Request["PageNo"];
                    try
                    {
                        PageNo = Convert.ToInt32(strPageNo);
                    }
                    catch
                    {
                    }
                    if (PageNo == 0)
                        PageNo = 1;

                    AdsList1.ShowAdsByUserCode(UserCode);

                    BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                    string UserFullName = CurAdsUser.FirstName + " " + CurAdsUser.LastName;

                    if (UserFullName != null)
                    {
                        Page.Title = lblHeader.Text = "آگهی های " + UserFullName + " صفحه " + Tools.ChangeEnc(PageNo.ToString());
                        Tools.SetMeta("description", "آگهی های " + UserFullName);
                        Tools.SetMeta("keywords", "آگهی های " + UserFullName);
                    }

                    LatestAds.ShowLatestAds(UserCode);

                }

            }
            catch (Exception e1)
            {
                //Response.Write(e1.Message);
            }
        }
    }
}