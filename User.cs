using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BO_Notify
{
    public class User
    {
        private string mID;
        private string mUsername;
        private string mPassword;

        public string ID {
            get { return mID; }
            internal set { mID = value; }
        }

        public string Username {
            get { return mUsername; }
            internal set { mUsername = value; }
        }

        public string Password {
            get { return mPassword; }
            internal set { mPassword = value; }
        }

        internal User() {
        }

        public bool Create(){
            string SQL = "insert into [User] (UserID, name, password) values (@id, @name, @password)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();

            mID = Guid.NewGuid().ToString();

            cmd.Parameters.Add(new SqlParameter("id",mID));
            cmd.Parameters.Add(new SqlParameter("name",mUsername));
            cmd.Parameters.Add(new SqlParameter("password", mPassword));

            return (cmd.ExecuteNonQuery() > 0);

            
        }
        private static User fillUserFromSQLDataReader(SqlDataReader reader){
            User oneUser = new User();
            oneUser.ID = reader.GetString(0);
            oneUser.Username = reader.GetString(1);
            return oneUser;
        
        }

        internal static User Load(string UserID){
            string SQL = "select ID, name from User where ID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", UserID));
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows){
                reader.Read();
                return fillUserFromSQLDataReader(reader);

            }else{
                return null;
            }

        }
    }
}
