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
    public class DbBooking
    {
        public static void SaveBookingInformation(ModelBooking booking)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("saveBooking", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserId", booking.UserId);
                cmd.Parameters.AddWithValue("@EventId", booking.EventId);
                cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteBookingInformation(int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteBooking", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BookingId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateBookingInformation(int id, ModelBooking booking)
        {

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateBooking", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BookingId", id);
                cmd.Parameters.AddWithValue("@UserId", booking.UserId);
                cmd.Parameters.AddWithValue("@EventId", booking.EventId);
                cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<ModelBooking> GetBookingInformation()
        {

            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("getBookings", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelBooking> listBookings = new List<ModelBooking>();

            while (reader.Read())
            {
                ModelBooking ev = new ModelBooking();
                ev.BookingId = Convert.ToInt32(reader["BookingID"]);
                ev.UserId = Convert.ToInt32(reader["UserId"]);
                ev.EventId = Convert.ToInt32(reader["EventId"]);
                ev.BookingDate = Convert.ToDateTime(reader["BookingDate"]);
                listBookings.Add(ev);
            }
            con.Close();

            return listBookings;

            
        }
    }




}

