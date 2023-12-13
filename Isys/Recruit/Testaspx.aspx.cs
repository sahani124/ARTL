using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Isys_Recruit_Testaspx : BaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNextPannel1_Click(object sender, EventArgs e)
    {
        divPannel1.Visible = false;
        btnNextPannel1.Visible = false;
        divPannel2.Visible = true;
        btnNextPannel2.Visible = true;
        btnPrev1.Enabled = true;
    }

    protected void btnNextPannel2_Click(object sender, EventArgs e)
    {
        divPannel2.Visible = false;
        btnNextPannel2.Visible = false;
        divpanel3.Visible = true;
        btnNextPannel3.Visible = true;
        btnPrev1.Visible = false;
        btnPrev2.Visible = true;
    }

    protected void btnNextPannel3_Click(object sender, EventArgs e)
    {
        divpanel3.Visible = false;
        btnNextPannel3.Visible = false;
        divpanel4.Visible = true;
        btnNextPannel4.Visible = true;
        btnPrev2.Visible = false;
        btnPrev3.Visible = true;
    }

    protected void btnNextPannel4_Click(object sender, EventArgs e)
    {
        divpanel4.Visible = false;
        btnNextPannel4.Visible = false;
        divpanel5.Visible = true;
        btnNextPannel5.Visible = true;
        btnPrev3.Visible = false;
        btnPrev4.Visible = true;
    }

    protected void btnNextPannel5_Click(object sender, EventArgs e)
    {
        divpanel5.Visible = false;
        btnNextPannel5.Visible = false;
        divpanel6.Visible = true;
        btnNextPannel6.Visible = true;
        btnPrev5.Visible = true;
        btnPrev4.Visible = false;
    }

    protected void btnNextPannel6_Click(object sender, EventArgs e)
    {
        divpanel6.Visible = false;
        btnNextPannel6.Visible = false;
        divpanel7.Visible = true;
        btnNextPannel7.Visible = true;
        btnPrev6.Visible = true;
        btnPrev5.Visible = false;
        btnPrev6.Enabled = true;
    }

    protected void btnNextPannel7_Click(object sender, EventArgs e)
    {
        divpanel7.Visible = false;
        divpanel8.Visible = true;
        btnNextPannel7.Visible = false;
        btnPreview.Visible = true;
        btnPrev6.Enabled = false;
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        divpanel8.Visible = false;
        btnPrev6.Visible = false;
        divPannel1.Visible = true;
        btnNextPannel1.Visible = true;
        btnPreview.Visible = false;
        btnPrev1.Visible = true;
        btnPrev1.Enabled = false;
    }

    protected void btnPrev1_Click(object sender, EventArgs e)
    {
        divPannel2.Visible = false;
        btnNextPannel2.Visible = false;
        divPannel1.Visible = true;
        btnPrev1.Enabled = false;
        btnNextPannel1.Visible = true;
    }

    protected void btnPrev2_Click(object sender, EventArgs e)
    {
        divPannel2.Visible = true;
        btnNextPannel2.Visible = true;
        btnPrev1.Visible = true;
        btnPrev2.Visible = false;
        divpanel3.Visible = false;
        btnNextPannel3.Visible = false;
    }

    protected void btnPrev3_Click(object sender, EventArgs e)
    {
        divpanel3.Visible = true;
        btnPrev2.Visible = true;
        btnNextPannel3.Visible = true;
        btnNextPannel4.Visible = false;
        btnPrev3.Visible = false;
        divpanel4.Visible = false;
    }

    protected void btnPrev4_Click(object sender, EventArgs e)
    {
        divpanel4.Visible = true;
        btnPrev3.Visible = true;
        btnNextPannel4.Visible = true;
        divpanel5.Visible = false;
        btnPrev4.Visible = false;
        btnNextPannel5.Visible = false;
    }

    protected void btnPrev5_Click(object sender, EventArgs e)
    {
        divpanel5.Visible = true;
        btnPrev4.Visible = true;
        btnNextPannel5.Visible = true;
        divpanel6.Visible = false;
        btnPrev5.Visible = false;
        btnNextPannel6.Visible = false;
    }

    protected void btnPrev6_Click(object sender, EventArgs e)
    {
        divpanel6.Visible = true;
        btnPrev5.Visible = true;
        btnNextPannel6.Visible = true;
        divpanel7.Visible = false;
        btnPrev6.Visible = false;
        btnNextPannel7.Visible = false;
    }
}