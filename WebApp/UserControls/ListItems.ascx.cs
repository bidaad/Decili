using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_ListItems : System.Web.UI.UserControl
{
    string _baseID;
    public string Code
    {
        get
        {
            return txtCode.Text;
        }
        set
        {
            txtCode.Text = value;
        }
    }
    public string Title
    {
        get
        {
            return txtTitle.Text;
        }
        set
        {
            txtTitle.Text = value;
        }
    }
    public string BaseID
    {
        get
        {
            return _baseID;
        }
        set
        {
            _baseID = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string OpenListFunc;
        string AjaxFuncFunc;

        OpenListFunc = "OpenList('" + _baseID + "', this)";
        AjaxFuncFunc = "GetListName('" + _baseID + "', this)";
        imgList.Attributes.Add("onclick", OpenListFunc);
        txtCode.Attributes.Add("onkeypress", AjaxFuncFunc);

    }
}
