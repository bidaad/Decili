using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Decili.Code.DAL;
using System.Reflection;
using Decili.UserControls;

namespace Decili
{
    public partial class _Default : System.Web.UI.Page
    {
        public string StartHour = "";
        public string StartMinute = "";
        public string StartSecond = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserCode"] != null)
                NormalLogin1.Visible = false;
            try
            {
                //LatestAds.ShowLatestAds();

                string strProvinceCode = Request["ProvinceCode"];
                int ProvinceCode;
                Int32.TryParse(strProvinceCode, out ProvinceCode);
                string strCityCode = Request["CityCode"];
                int CityCode;
                Int32.TryParse(strCityCode, out CityCode);

                
                if (ProvinceCode != 0)
                {
                    UCProvinces1.Visible = false;
                    UCCities1.ProvinceCode = ProvinceCode;
                    BOLProvinces ProvincesBOL = new BOLProvinces();
                    string ProvinceName = ProvincesBOL.GetNameByCode(ProvinceCode);
                    Page.Title = "دسیلی :: استان " + ProvinceName;
                    lblHeader.Text = "آگهی های " + ProvinceName;
                }
                else if (CityCode != 0)
                {
                    UCProvinces1.Visible = true;
                    UCCities1.Visible = false;
                    BOLCities CitiesBOL = new BOLCities();
                    string CityName = CitiesBOL.GetNameByCode(CityCode);

                    Page.Title = "دسیلی :: " + CityName;
                    lblHeader.Text = "آگهی های " + CityName;

                }
                else
                    UCCities1.Visible = false;

                if (!Page.IsPostBack)
                {
                    string Keyword = Request["Keyword"];
                    if (string.IsNullOrEmpty(Keyword))
                        AdsList1.ShowTopAds();
                    else
                    {
                        Response.Redirect("~/s1-" + Keyword.Replace(" ", "%20") + ".html", false);
                        return;
                        /*
                        AdsList1.SearchAds(Keyword);
                        lblHeader.Text = Keyword;
                        UCAdKeywords1.ShowRelatedKeywordsByPhrase(Keyword);
                        UCProvinces1.Visible = false;
                        UCCities1.Visible = false;
                        UCAdKeywords1.Visible = true;
                         */
                    }
                }
            }
            catch
            {
            }
        }
        public string FormatDate(Object obj)
        {
            string Result = "";
            try
            {
                if (obj != null)
                {
                    DateTime CurDT = Convert.ToDateTime(obj);
                    DateTimeMethods dtm = new DateTimeMethods();
                    Result = Tools.ChageEnc(dtm.GetPersianLongDate(CurDT));
                }
                return Result;

            }
            catch
            {
                return "";
            }

        }
        public string ShowPic(object Title, object PicName)
        {
            string Result = "";
            if (PicName != null && PicName != "")
                Result = "<img class=\"cPicXSmall\" alt=\"" + Title + "\" src=\"" + PicName + "\" />";
            return Result;
        }
        private UserControl LoadControl(string UserControlPath, params object[] constructorParameters)
        {
            List<System.Type> constParamTypes = new List<System.Type>();
            foreach (object constParam in constructorParameters)
            {
                constParamTypes.Add(constParam.GetType());
            }

            UserControl ctl = Page.LoadControl(UserControlPath) as UserControl;

            // Find the relevant constructor
            ConstructorInfo constructor = ctl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());

            //And then call the relevant constructor
            if (constructor == null)
            {
                throw new MemberAccessException("The requested constructor was not found on : " + ctl.GetType().BaseType.ToString());
            }
            else
            {
                constructor.Invoke(ctl, constructorParameters);
            }

            // Finally return the fully initialized UC
            return ctl;
        }

    }
}
