using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCCatSelector : System.Web.UI.UserControl
    {
        protected int? _selectedCat;
        public int? SelectedCatCode
        {
            get
            {
                if (ViewState["CatCode"] != null)
                    return Convert.ToInt32(ViewState["CatCode"]);
                else
                    return null;
            }
            set
            {
                _selectedCat = value;
                ViewState["CatCode"] = _selectedCat;
            }
        }

        public string strCatHirarchy = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                    //rptCats.DataSource = AdvertisesBOL.GetAdvertiseCatsByMasterCode(null);
                    //rptCats.DataBind();
                    //btnMasterCat.Visible = false;
                    ltrCatName.Text = "گروه آگهی";
                    SelectCat(_selectedCat);

                }
            }
            catch
            {
            }
        }

        protected void HandleRepeaterCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton btnCat = (LinkButton)e.Item.Controls[1].FindControl("btnCat");
            int CatCode = Convert.ToInt32(btnCat.Attributes["CatCode"]);
            SelectCat(CatCode);

        }

        public void SelectCat(int? CatCode)
        {
            ViewState["CatCode"] = CatCode;
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            if (CatCode != null)
            {
                string CatName = AdvertisesBOL.GetCatNameByCode((int)CatCode);
                lblCurCat.Text = "&nbsp;|&nbsp;&nbsp;" + CatName.Replace("-", " ") + "&nbsp;";
                btnMasterCat.Visible = true;
                pnlBacktoMasterCat.Visible = true;
                strCatHirarchy = "";

                GenCatHirarchy(CatCode);
                ltrCatName.Text = "<ul class=\"CatHirrarchy\">" + strCatHirarchy + "</ul>";
                CatSelectorTool.CssClass = "";
            }
            else
            {
                lblCurCat.Text = "";
                btnMasterCat.Visible = false;
                pnlBacktoMasterCat.Visible = false;
                ltrCatName.Text = "گروه آگهی";
            }

            rptCats.DataSource = AdvertisesBOL.GetAdvertiseCatsByMasterCode(CatCode);
            rptCats.DataBind();

            if (rptCats.Items.Count == 0)
            {
                CatSelectorTool.CssClass = "NoDisp";
                int? MasterofCurrentCat = null;
                if(CatCode != null)
                    MasterofCurrentCat = AdvertisesBOL.GetMasterCatCode(CatCode);
                rptCats.DataSource = AdvertisesBOL.GetAdvertiseCatsByMasterCode(MasterofCurrentCat);
                rptCats.DataBind();                //pnlCats.Visible = false;
                //pnlBacktoMasterCat.Visible = false;
            }
            else
            {
                CatSelectorTool.CssClass = "";
                //pnlCats.Visible = true;
                //pnlBacktoMasterCat.Visible = true;
            }

        }

        public void GenCatHirarchy(int? CatCode)
        {
            if (CatCode != null)
            {
                BOLAdvertises AdvertisesBOL = new BOLAdvertises();
                string CatName = AdvertisesBOL.GetCatNameByCode((int)CatCode);
                strCatHirarchy += "<li><span >" + CatName.Replace("-", " ") + "</span>&nbsp;&nbsp;»&nbsp;&nbsp;</li>";
                int? MasterCatCode = AdvertisesBOL.GetMasterCatCode(CatCode);
                GenCatHirarchy(MasterCatCode);
            }

        }

        public string ShowTitle(Object obj)
        {
            if (obj != null)
            {
                return obj.ToString().Replace("-", " ");
            }
            return "";
        }

        protected void btnMasterCat_Click(object sender, EventArgs e)
        {
            int? CatCode = Convert.ToInt32(ViewState["CatCode"]);
            BOLAdvertises AdvertisesBOL = new BOLAdvertises();
            int? MasterCatCode = AdvertisesBOL.GetMasterCatCode(CatCode);
            SelectCat(MasterCatCode);


        }

    }
}