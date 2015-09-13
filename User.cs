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
            set { mUsername = value; }
        }

        public string Password {
            get { return mPassword; }
            set { mPassword = value; }
        }

        internal User() {
        }

        public bool Create(){
            string SQL = "insert into [User] (UserId, name, password) values (@id, @nam, @pw)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();

            mID = Guid.NewGuid().ToString();

            //cmd.Parameters.Add(new SqlParameter("id",mID));
            cmd.Parameters.Add(new SqlParameter("id", mID));
            cmd.Parameters.Add(new SqlParameter("nam",mUsername));
            cmd.Parameters.Add(new SqlParameter("pw", mPassword));

            return (cmd.ExecuteNonQuery() > 0);

            
        }
        private static User fillUserFromSQLDataReader(SqlDataReader reader){
            User oneUser = new User();
            oneUser.ID = reader.GetString(0);
            oneUser.Username = reader.GetString(1);
            oneUser.Password = reader.GetString(2);
            return oneUser;
        
        }

        public User Login(string username){
            string SQL = "select * from [User] where name = @name";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("name", username));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return fillUserFromSQLDataReader(reader);

            }
            else
            {
                return null;
            }
           
        }
        
        internal static User Load(string UserId){
            string SQL = "select ID, name from User where name = @nam";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", UserId));
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
