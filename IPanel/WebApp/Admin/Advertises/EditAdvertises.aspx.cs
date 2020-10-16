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


public partial class Advertises_EditAdvertises : EditForm<Advertises>
{
    private string BaseID = "Advertises";
    IBaseBOL<Advertises> BaseBOL;



    protected void Page_Load(object sender, EventArgs e)
    {
        #region Tab Pages
        //if (!NewMode)
        //     ShowDetails();
        //else
        //{
        //     RadMultiPage1.SelectedIndex = 0;
        //     tsAdvertises.Tabs[0].Selected = true;
        //}
        #endregion
        BOLClass = new BOLAdvertises();
        lblSysName.Text = BOLClass.PageLable;

        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            //if (!NewMode) ShowDetails();


            #region Fill Combo
            cboHCDurationCode.DataSource = new BOLHardCode().GetHCDataTable("HCAdvertiseDurations");
            //cboHCStateCode.DataSource = new BOLHardCode().GetHCDataTable("States");
            cboHCAdvertiseStatusCode.DataSource = new BOLHardCode().GetHCDataTable("HCAdvertiseStatuses");

            #endregion
            if (!NewMode)
            {
                LoadData((int)Code);

                BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                Advertises CurAdver = ((IBaseBOL<Advertises>)AdvertisesBOL).GetDetails((int)Code);
                imgAdsPic.ImageUrl = "~/Files/Ads/" + CurAdver.LargePicFile;

            }
        }


    }

    protected void DoSave(object sender, EventArgs e)
    {
        try
        {
            int ReturnCode = SaveControls("~/Main/Default.aspx?BaseID=" + BaseID);
            if (ReturnCode != -1)
            {
                NewMode = false;
                Code = ReturnCode;

                if(cboHCAdvertiseStatusCode.SelectedValue == "2")
                {
                    EmailTools emailTools = new EmailTools();
                    emailTools.SendAdActivation((int)Code);
                }

                Response.Redirect("~/Admin/Main/Panel.aspx");
            }
        }
        catch
        {
        }
    }
    
}
