using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.UI.WebControls;
using BO_Notify;

namespace index
{
    public partial class register : System.Web.UI.Page
    {
        string username;
        string password;
        User newUser;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = "";
            newUser = Main.newUser();
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (TxtPass1.Text == TxtPass2.Text)
            {
                if (newUser != null)
                {
                    TxtName.Text = newUser.Username;
                    TxtPass1.Text = newUser.Password;
                    Session["ID"] = newUser.ID;
                    if(newUser.Create()){
                        Response.Redirect("Default.aspx");
                    }else LblError.Text = "Creation Failed";
                }
            }
            else
            {
                LblError.Text = "Passwoerter stimmen nicht ueberein";
            }
        }
        
    }
}
