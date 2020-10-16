using AKP.Web.Controls;
using Decili.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BudgetWebApp
{
    public partial class Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                rptAdvertises.DataSource = AdvertisesBOL.GetInactiveAds();
                rptAdvertises.DataBind();
            }
        }

        protected void HandleRepeaterCommand(object source, RepeaterCommandEventArgs e)
        {
            Button btnShowAds = (Button)e.Item.Controls[1].FindControl("btnShowAds");
            Label lblExpDate = (Label)e.Item.Controls[1].FindControl("lblExpDate");

            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            int UserCode = Convert.ToInt32(Session["UserCode"]);
            int AdvertisCode = Convert.ToInt32(btnShowAds.Attributes["Code"]);


            #region Delete
            if (e.CommandName == "ShowAds")
            {
                ExTextBox txtTitle = (ExTextBox)e.Item.Controls[1].FindControl("txtTitle");
                ExTextBox txtDescription = (ExTextBox)e.Item.Controls[1].FindControl("txtDescription");
                ExTextBox txtName = (ExTextBox)e.Item.Controls[1].FindControl("txtName");
                ExTextBox txtAddress = (ExTextBox)e.Item.Controls[1].FindControl("txtAddress");
                ExTextBox txtPrice = (ExTextBox)e.Item.Controls[1].FindControl("txtPrice");
                ExTextBox txtTel = (ExTextBox)e.Item.Controls[1].FindControl("txtTel");
                HyperLink hplLink = (HyperLink)e.Item.Controls[1].FindControl("hplLink");
                HyperLink hplEdit = (HyperLink)e.Item.Controls[1].FindControl("hplEdit");

                Image imgAdsPic = (Image)e.Item.Controls[1].FindControl("imgAdsPic");
                System.Web.UI.WebControls.Panel pnlAdsInfo = (System.Web.UI.WebControls.Panel)e.Item.Controls[1].FindControl("pnlAdsInfo");
                pnlAdsInfo.Visible = true;

                Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails(AdvertisCode);
                txtName.Text = CurAdver.Name;
                txtDescription.Text = CurAdver.Description;
                txtAddress.Text = CurAdver.Address;
                txtPrice.Text = CurAdver.Price;
                txtTel.Text = CurAdver.Tel;
                txtTitle.Text = CurAdver.Title;
                imgAdsPic.ImageUrl = "https://cdn.Decili.ir/Files/Ads/" + CurAdver.LargePicFile;
                hplLink.NavigateUrl = "https://www.Decili.ir/Ads/" + CurAdver.ID + ".html";
                hplLink.Text = "https://www.Decili.ir/Ads/" + CurAdver.ID + ".html";
                hplEdit.Text = "ویرایش";
                hplEdit.NavigateUrl = "~/Admin/Advertises/EditAdvertises.aspx?Code=" + CurAdver.Code;


            }
            #endregion

            #region Approve
            if (e.CommandName == "Approve")
            {
                bool Result = AdvertisesBOL.ChangeStatus(AdvertisCode, 2);


                EmailTools emailTools = new EmailTools();
                emailTools.SendAdActivation(AdvertisCode);

                rptAdvertises.DataSource = AdvertisesBOL.GetInactiveAds();
                rptAdvertises.DataBind();

                try
                {
                    vAdvertises CurAds = AdvertisesBOL.GetAdsByCode(AdvertisCode);
                    HttpContext context = HttpContext.Current;
                    context.Cache["GetAdsByID" + CurAds.ID] = "";
                }
                catch
                {

                }
            }
            #endregion
        }

    }
}