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
    public class DbEventType
    {
        public static void SaveEventTypeInformation(ModelEventType eventType)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("saveEventType", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EventTypeName", eventType.EventTypeName);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEventTypeInformation(int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteEventType", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EventTypeId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateEventTypeInformation(int id, ModelEventType eventType)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateEventType", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EventTypeId", id);
                cmd.Parameters.AddWithValue("@EventTypeName", eventType.EventTypeName);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<ModelEventType> GetEventTypeInformation()
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();


            SqlCommand cmd = new SqlCommand("getEventTypes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelEventType> listEventTypes = new List<ModelEventType>();

            while (reader.Read())
            {
                ModelEventType evt = new ModelEventType();

                evt.EventTypeId = Convert.ToInt32(reader["EventTypeID"]);
                evt.EventTypeName = reader["EventTypeName"].ToString();


                listEventTypes.Add(evt);
            }
            con.Close();

            return listEventTypes;
        }
    }
}

