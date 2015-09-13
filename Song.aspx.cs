using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BO_Notify
{
    public class Song
    {
        private string TrackID="";
        private string titel;
        private string AlbumID;
        private string InterpretID;

        private static Songs fillSongsFromSQLDataReader(SqlDataReader reader){
            Songs allSongs = new Songs();
            Song oneSong = new Song();
            oneSong.TrackID = reader.GetString(0);
            oneSong.AlbumID = reader.GetString(1);
            oneSong.InterpretID = reader.GetString(2);
            oneSong.titel = reader.GetString(3);

            allSongs.Add(oneSong);
            return allSongs;
        }
    
        internal static Songs LoadAllSongs(){
            String SQL = "select * from [Tracks]";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            
            if(reader.HasRows){
                reader.Read();
                return fillSongsFromSQLDataReader(reader);
            }else return null;
        }
        internal static Songs LoadSongsForAlbum(string AlbumID){
            SqlCommand cmd = new SqlCommand("select * from [Tracks] where albumID = @albumID");
            cmd.Parameters.Add(new SqlParameter("albumID",AlbumID));
            cmd.Connection = Main.GetConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return fillSongsFromSQLDataReader(reader);
            }
            else return null;
        }
        internal static Songs LoadSongsForInterpret(string InterpretID)
        {
            SqlCommand cmd = new SqlCommand("select * from Tracks where interpretID = @InterpretID");
            cmd.Parameters.Add(new SqlParameter("interpretID", InterpretID));
            cmd.Connection = Main.GetConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return fillSongsFromSQLDataReader(reader);
            }
            else return null;
        }
    
    }

}
