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
using System.Net;
using System.Xml;
using System.IO;

public partial class UserControls_Weather : System.Web.UI.UserControl
{
    private void DisplayWeather()
    {
        try
        {
            // Request URL
            string wsUrl = "http://xoap.weather.com/weather/local/" +
                // City Code
                           "IRXX0018" +
                           "?cc=*" +
                // Forecast Days
                           "&dayf=3" + 
                           //"&prod=xoap&par=1010760847&key=36e1f14b468962e2" +
                           "&par=1010760847&key=36e1f14b468962e2" +
                // Set Unit
                           "&unit=m";

            // Contact service for content
            HttpWebRequest wrq = (HttpWebRequest)WebRequest.Create(wsUrl);
            WebProxy wproxy = new WebProxy("isa.gsi.local", 8080);
            wproxy.Credentials = new NetworkCredential("portalweb", "userportal");
            //wrq.Proxy = wproxy;

            // Load response
            WebResponse resp = wrq.GetResponse();
            // Create new stream for XmlTextReader
            Stream str = resp.GetResponseStream();
            XmlTextReader reader = new XmlTextReader(str);
            reader.XmlResolver = null;
            // Create Xml document
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            Xml1.Document = doc;
            Xml1.TransformSource = "WeatherComM.xslt";
        }
        catch (Exception ex)
        {
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayWeather();

    }
}
