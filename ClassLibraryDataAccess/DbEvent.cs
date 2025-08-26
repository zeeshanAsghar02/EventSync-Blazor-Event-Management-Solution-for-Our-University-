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
    public class DbEvent
    {
        public static void SaveEventInformation(ModelEvent ev)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("saveEvent", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EventName", ev.EventName);
                cmd.Parameters.AddWithValue("@Description", ev.Description);
                cmd.Parameters.AddWithValue("@StartTime", ev.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", ev.EndTime);
                cmd.Parameters.AddWithValue("@VenueId", ev.VenueId);
                cmd.Parameters.AddWithValue("@EventTypeId", ev.EventTypeId);
                cmd.Parameters.AddWithValue("@OrganizerId", ev.OrganizerId);
                cmd.Parameters.AddWithValue("@Price", ev.Price);
                cmd.Parameters.AddWithValue("@TicketsBooked", 0);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEventInformation(int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteEvent", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EventId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateEventInformation(int id, ModelEvent ev)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateEvent", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EventId", id);
                cmd.Parameters.AddWithValue("@EventName", ev.EventName);
                cmd.Parameters.AddWithValue("@Description", ev.Description);
                
                cmd.Parameters.AddWithValue("@StartTime", ev.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", ev.EndTime);
                cmd.Parameters.AddWithValue("@VenueId", ev.VenueId);
                cmd.Parameters.AddWithValue("@EventTypeId", ev.EventTypeId);
                cmd.Parameters.AddWithValue("@OrganizerId", ev.OrganizerId);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<ModelEvent> GetEventInformation()
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();


            SqlCommand cmd = new SqlCommand("getEvents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelEvent> listEvents = new List<ModelEvent>();

                while (reader.Read())
                {
                        ModelEvent ev = new ModelEvent();

                ev.EventId = Convert.ToInt32(reader["EventID"]);
                ev.EventName = reader["EventName"].ToString();
                ev.Description = reader["Description"].ToString();

                ev.StartTime = Convert.ToDateTime(reader["StartTime"]);
                ev.EndTime = Convert.ToDateTime(reader["EndTime"]);
                ev.VenueId = Convert.ToInt32(reader["VenueID"]);
                ev.EventTypeId = Convert.ToInt32(reader["EventTypeID"]);
                ev.OrganizerId = Convert.ToInt32(reader["OrganizerID"]);
                ev.Price = Convert.ToDecimal(reader["Price"]);
                ev.TicketsBooked = Convert.ToInt32(reader["TicketsBooked"]);
                listEvents.Add(ev);
                }
            con.Close();

            return listEvents;
        }
    }
}

