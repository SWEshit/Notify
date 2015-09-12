using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtName.Text != "" && TxtPassword.Text != "")
            {
                Session["Name"] = TxtName.Text;
                Session["Password"] = TxtPassword.Text;

                Server.Transfer(null);

            }
        }

        protected void BtnToRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("register.aspx");
        }
    }
}
