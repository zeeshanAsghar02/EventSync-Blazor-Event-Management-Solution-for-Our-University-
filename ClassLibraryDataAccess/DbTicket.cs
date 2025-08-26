using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibraryModel;
using System.Diagnostics;
using System.Net.Sockets;

namespace ClassLibraryDataAccess
{
    public class DbTicket
    {
        public static void SaveTicketInformation(ModelTicket ticket)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("saveTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BookingId", ticket.UserId);
                cmd.Parameters.AddWithValue("@EventID", ticket.EventId);

                cmd.Parameters.AddWithValue("@Price", ticket.Price);
                
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteTicketInformation(int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TicketId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateTicketInformation(int id, ModelTicket ticket)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TicketId", id);
                cmd.Parameters.AddWithValue("@BookingId", ticket.UserId);
                cmd.Parameters.AddWithValue("@EventID", ticket.EventId);
                cmd.Parameters.AddWithValue("@Price", ticket.Price);
                
                cmd.ExecuteNonQuery();
            }
        }

        public static List<ModelTicket> GetTicketInformation()
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();


            SqlCommand cmd = new SqlCommand("getTickets", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelTicket> listTickets = new List<ModelTicket>();
            while (reader.Read())
            {
                ModelTicket tc = new ModelTicket();
                tc.TicketId = Convert.ToInt32(reader["TicketId"]);
                tc.UserId = Convert.ToInt32(reader["BookingId"]);
                tc.EventId = Convert.ToInt32(reader["EventID"]);
                tc.Price = Convert.ToDecimal(reader["Price"]);
                


                listTickets.Add(tc);
            }
            con.Close();

            return listTickets;

            
        }
        
    }
}

