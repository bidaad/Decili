using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class UCSelectedNews : System.Web.UI.UserControl
    {
        protected string _showedCode = "";
        public string ShowedCodes
        {
            get
            {
                return _showedCode;
            }
            set
            {
                _showedCode = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        
    }
}