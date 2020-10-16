using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IONS.UserControls
{
    public partial class PicLinks : System.Web.UI.UserControl
    {
        protected int _catCode;
        public int CatCode
        {
            get
            {
                return _catCode;
            }
            set
            {
                _catCode = value;
            }
        }


        public PicLinks()
        {
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            #region Language
            #endregion
            BOLLinks LinksBOL = new BOLLinks();

            rptRandLinks.DataSource = LinksBOL.GetLinksBycatCode(_catCode);
            rptRandLinks.DataBind();

            
        }
        public string ShowPropItem(Object objFileName, Object objTitle)
        {
            try
            {
                string Result = "";
                if (objFileName == null || objFileName == "")
                {
                    Result = "<div class=\"LinkItem\">" + objTitle.ToString() + "</div>";
                }
                else
                {
                    if (objFileName.ToString() != "")
                        Result = "<img style=\"width:175px;\" src=\"" + Page.ResolveUrl("~/" + objFileName.ToString()) + "\" />";
                }
                return Result;

            }
            catch
            {
                return "";
            }
        }
    }
}