using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_Notify;

namespace PL_Notify
{
    public partial class Page1 : System.Web.UI.Page
    {
        private Songs loadedSongs;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblname.Text = Session["name"].ToString();

            loadedSongs = Main.getSongs();
            //Session["loadedSongs"] = loadedSongs;
            
            GvSongs.DataSource = loadedSongs;
            GvSongs.DataBind();

        }

        protected void BtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
