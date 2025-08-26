using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDataAccess
{
    public class DbVenue
    {
        public static void SaveVenueInformation(ModelVenue venue)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("saveVenue", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VenueName", venue.VenueName);
                cmd.Parameters.AddWithValue("@Address", venue.Address);
                cmd.Parameters.AddWithValue("@Capacity", venue.Capacity);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteVenueInformation(int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteVenue", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VenueId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateVenueInformation(int id, ModelVenue venue)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateVenue", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VenueId", id);
                cmd.Parameters.AddWithValue("@VenueName", venue.VenueName);
                cmd.Parameters.AddWithValue("@Address", venue.Address);
                cmd.Parameters.AddWithValue("@Capacity", venue.Capacity);
                cmd.ExecuteNonQuery();
            }
        }
        public static List<ModelVenue> GetVenueInformation()
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();


            SqlCommand cmd = new SqlCommand("getVenues", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelVenue> listVenues = new List<ModelVenue>();

            while (reader.Read())
            {
                ModelVenue mv = new ModelVenue();

                mv.VenueId = Convert.ToInt32(reader["VenueID"]);
                mv.VenueName = reader["VenueName"].ToString();
                mv.Address= reader["Address"].ToString();
                mv.Capacity = Convert.ToInt32(reader["Capacity"]);


                listVenues.Add(mv);
            }
            con.Close();

            return listVenues;
        }
    }
}

