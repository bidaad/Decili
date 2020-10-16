using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Decili.Code.DAL;
using AKP.Web.Controls;


public partial class Users_EditUsers : EditForm<Users>
{
    private string BaseID = "Users";
    IBaseBOL<Users> BaseBOL;



    protected void Page_Load(object sender, EventArgs e)
    {
        #region Tab Pages
        if (!NewMode)
            ShowDetails();

        #endregion
        BOLClass = new BOLUsers();
        lblSysName.Text = BOLClass.PageLable;

        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            //if (!NewMode) ShowDetails();
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            rptAdvertises.DataSource = AdvertisesBOL.GetAdverByUserCode((int)Code);
            rptAdvertises.DataBind();

            #region Fill Combo
            cboHCGenderCode.DataSource = new BOLHardCode().GetHCDataTable("HCGenders");

            #endregion
            if (!NewMode)
            {
                Tools.SetClientScript(this, "ActiveTab1", "BrowseObj1.ShowDetail('UserGroups', '" + Code + "',true,'BrowseObj1')");
                LoadData((int)Code);
                BOLUsers UsersBOL = new BOLUsers();
                Users CurUser = ((IBaseBOL<Users>)UsersBOL).GetDetails((int)Code);
                if (CurUser.RegDate != null)
                {
                    DateTimeMethods dtm = new DateTimeMethods();
                    dteRegDate.Text = dtm.GetPersianDate((DateTime)CurUser.RegDate);
                    if(CurUser.CreateDate != null)
                        lblCreateDate.Text = dtm.GetPersianDate((DateTime)CurUser.CreateDate);
                }
                txtPassword.Attributes.Add("value", CurUser.Password);
                hfPassword.Value = CurUser.Password;

            }
        }


    }

    protected void DoSave(object sender, EventArgs e)
    {
        try
        {
            int ReturnCode = SaveControls("~/Main/Default.aspx?BaseID=" + BaseID);
            if (NewMode && ReturnCode != -1)
            {
                NewMode = false;
                Code = ReturnCode;
                ShowDetails();
            }
            if (hfPassword.Value != txtPassword.Text)
            {
                BOLUsers UsersBOL = new BOLUsers();
                UsersBOL.ChangePassword(Code, txtPassword.Text);
                txtPassword.Attributes.Add("value", txtPassword.Text);

            }
        }
        catch
        {
        }
    }
    private void ShowDetails()
    {
        string Tab1Click = "BrowseObj1.ShowDetail('UserGroups', '" + Code
              + "', true,'BrowseObj1');BrowseObj2.ShowDetail('UserTransactions', '" + Code
              + "', true,'BrowseObj2');BrowseObj3.ShowDetail('UserAddresses', '" + Code
              + "', true,'BrowseObj3')";


        Tab1.Attributes.Add("onclick", Tab1Click);
        Tools.SetClientScript(this, "ActiveTab1", Tab1Click);

        #region HanldeSelectedTab
        if (Request["SelectedTab"] != null)
        {
            RadMultiPage1.SelectedIndex = Int32.Parse(Request["SelectedTab"]);
            SelectedTabIndex = Int32.Parse(Request["SelectedTab"]);
            switch (Int32.Parse(Request["SelectedTab"]))
            {
                case 0:
                    Tools.SetClientScript(Page, "ClickTab", Tab1Click);
                    RadMultiPage1.SelectedIndex = 0;
                    tsUsers.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
            tsUsers.Tabs[Int32.Parse(Request["SelectedTab"])].Selected = true;
        }
        else
        {
            RadMultiPage1.SelectedIndex = 0;
            tsUsers.Tabs[0].Selected = true;
        }
        #endregion
    }

    protected void btnLogAsUser_Click(object sender, EventArgs e)
    {
        BOLUsers UsersBOL = new BOLUsers();
        Users CurUser = ((IBaseBOL<Users>)UsersBOL).GetDetails((int)Code);

        Session["UserCode"] = CurUser.Code;
        Session["Email"] = CurUser.Email;
        Session["UserFullName"] = CurUser.FirstName + " " + CurUser.LastName;

        Response.Redirect("~/Users/");

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
            imgAdsPic.ImageUrl = "~/Files/Ads/" + CurAdver.LargePicFile;
            hplLink.NavigateUrl = "https://www.Decili.ir/Ads/" + CurAdver.ID + ".html";
            hplLink.Text = "https://www.Decili.ir/Ads/" + CurAdver.ID + ".html";



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
                context.Cache["GetAdsByID" + CurAds.ID] = null;
            }
            catch
            {

            }
        }
        #endregion
    }

}
