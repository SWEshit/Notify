using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_Notify;

namespace index
{
    public partial class index : System.Web.UI.Page
    {
        User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Main.newUser();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtName.Text != "" && TxtPassword.Text != "")
            {
                currentUser.Username = TxtName.Text;
                currentUser.Password = TxtPassword.Text;

                if((currentUser.Login(currentUser.Username).Username).Equals(currentUser.Username) &&
                        (currentUser.Login(currentUser.Username).Password).Equals(currentUser.Password)){
                    Session["name"]= currentUser.Username;
                    Session["ID"] = currentUser.Login(currentUser.Username).ID;
                    Response.Redirect("Page1.aspx");
                }else{
                    lblError.Text = "MISTAKE!!!!!";
                }

                //Server.Transfer(null);

            }
        }

        protected void BtnToRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("register.aspx");
        }
    }
}
