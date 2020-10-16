using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.Admin
{
    public partial class KeyGenTester : System.Web.UI.Page
    {
        List<String> AdvertiseKeyword;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGen_Click(object sender, EventArgs e)
        {
            string str = txtStr.Text;

            ExtractKeywords(Tools.PersianTextCorrection(str));
            if (AdvertiseKeyword.Count > 0)
            {
                rptKeywords.DataSource = AdvertiseKeyword;
                rptKeywords.DataBind();
            }

        }
        private void ExtractKeywords(string AdsContent)
        {
            try
            {
                Tools tools = new Tools();
                ArrayList OneLenList = tools.GenLenKeywords(1, 2, @"(\w+)(\w+)", AdsContent);
                ArrayList TwoLenList = tools.GenLenKeywords(2, 2, @"(\w+)(\w+)", AdsContent);
                ArrayList TreeLenList = tools.GenLenKeywords(3, 1, @"(\w+)(\w+)", AdsContent);
                ArrayList FourLenList = tools.GenLenKeywords(4, 1, @"(\w+)(\w+)", AdsContent);
                List<String> FinalKeywords = new List<String>();

                string[] OneLenListArray = (String[])OneLenList.ToArray(typeof(string));
                string[] TwoLenListArray = (String[])TwoLenList.ToArray(typeof(string));
                string[] TreeLenListArray = (String[])TreeLenList.ToArray(typeof(string));
                string[] FourLenListArray = (String[])FourLenList.ToArray(typeof(string));

                IEnumerable<String> FullKeyList;
                FullKeyList = FourLenListArray.Union(TreeLenListArray).Union(TwoLenListArray).Union(OneLenListArray);
                for (int j = 0; j < FullKeyList.Count(); j++)
                {
                    string CurrentKeyword = FullKeyList.ElementAt(j);
                    IEnumerable<String> ContainList = FullKeyList.Where(p => p.Contains(CurrentKeyword));
                    if (!CurrentKeyword.Contains(" "))
                        FinalKeywords.Add(CurrentKeyword);
                    else if (ContainList.Count() == 1 || !CurrentKeyword.Contains(" "))
                        FinalKeywords.Add(ContainList.ElementAt(0));
                }
                AdvertiseKeyword = FinalKeywords;
            }
            catch (Exception err)
            {
                BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
                ErrorLogsBOL.Insert(err.Message, DateTime.Now, Request.Url.AbsolutePath, "Advertise::GenKeywords::");
            }

        }

    }
}