//BOMain: Buisinessobjekt zur Applikation Notify als Semesterprojekt in SWE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace BO_Notify
{
    public static class Main
    {
        static internal SqlConnection GetConnection(){
        
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count -1);
            string conString = @"Data Source = (LocalDB)\v11.0;AttachDbFilename ="+String.Join(@"\",dirs) + @"\DB_Notify\Datenbank.mdf;Integrated Security = true; Connect Timeout=5";


            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        public static User newUser(){
        return new User(); 
        }

        public static User getUser(string UserID){
            return User.Load(UserID);
        }
    }
}
