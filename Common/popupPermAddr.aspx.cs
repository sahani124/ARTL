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
using Insc.Common.Multilingual;
using CLTMGR;

public partial class Application_Common_popupPermAddr : BaseClass
{
    private multilingualManager olng;
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        olng = new multilingualManager("DefaultConn", "popupPermAddr.aspx", Session["UserLangNum"].ToString());
        if (!IsPostBack)
        {
            InitializeControl();
        }

    }
    private void InitializeControl()
    {
        lblAPHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAPHeadear"));
        lblAddrP1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddrP1"));
        lblCity.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCity"));
        lblEstP2.Text = ObjDec.GetDecData(olng.GetItemDesc("lblEstP2"));
        lblEstP3.Text = ObjDec.GetDecData(olng.GetItemDesc("lblEstP3"));
        lblState.Text = ObjDec.GetDecData(olng.GetItemDesc("lblState"));
        lblPin.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPin"));
        lblEstP4.Text = ObjDec.GetDecData(olng.GetItemDesc("lblEstP4"));
        lblCountry.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountry"));
        lblEstP5.Text = ObjDec.GetDecData(olng.GetItemDesc("lblEstP5"));

    }
}

