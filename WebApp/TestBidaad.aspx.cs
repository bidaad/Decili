using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili
{
    public partial class TestBidaad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AdsTitle = "فروش قطعات یدکی موتورهای گازسوز و دیزل";

            ArrayList OneLenList = GenLenKeywords(1, 2, @"(\w+)(\w+)", AdsTitle);
            ArrayList TwoLenList = GenLenKeywords(2, 2, @"(\w+)(\w+)", AdsTitle);
            ArrayList TreeLenList = GenLenKeywords(3, 1, @"(\w+)(\w+)", AdsTitle);
            ArrayList FourLenList = GenLenKeywords(4, 1, @"(\w+)(\w+)", AdsTitle);
            List<String> FinalKeywords = new List<String>();

            string[] OneLenListArray = (String[])OneLenList.ToArray(typeof(string));
            string[] TwoLenListArray = (String[])TwoLenList.ToArray(typeof(string));
            string[] TreeLenListArray = (String[])TreeLenList.ToArray(typeof(string));
            string[] FourLenListArray = (String[])FourLenList.ToArray(typeof(string));

            IEnumerable<String> FullKeyList;
            FullKeyList = (FourLenListArray.Union(TreeLenListArray).Union(TwoLenListArray).Union(OneLenListArray)).Distinct();
            foreach (var item in FullKeyList)
            {
                string CurKey = item;
            }

            int gg = 1;
        }

        public ArrayList GenLenKeywords(int WordCount, int MinLen, string _pattern, string InputStr)
        {
            int StrLen = InputStr.Length;
            ArrayList ResultArray = new ArrayList();
            ArrayList InnerResultList = new ArrayList();

            Regex r = new Regex(_pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match m = r.Match(InputStr);
            string CurKeyword = "";
            while (m.Success)
            {
                CurKeyword = m.Groups[0].Captures[0].ToString();
                InnerResultList.Add(CurKeyword);
                m = m.NextMatch();
            }

            string CurLengthKey = "";
            for (int i = 0; i < InnerResultList.Count; i++)
            {
                if (i >= WordCount && i < InnerResultList.Count)
                {
                    for (int j = WordCount - 1; j >= 0; j--)
                        CurLengthKey = CurLengthKey + " " + InnerResultList[i - j - 1];
                    CurLengthKey = CurLengthKey.Trim();

                    if (!CurLengthKey.EndsWith("های") && CurLengthKey != "در" && !CurLengthKey.EndsWith("در") && !CurLengthKey.StartsWith("در"))
                        ResultArray.Add(CurLengthKey);
                    CurLengthKey = "";
                }
            }

            return ResultArray;
        }

    }
}