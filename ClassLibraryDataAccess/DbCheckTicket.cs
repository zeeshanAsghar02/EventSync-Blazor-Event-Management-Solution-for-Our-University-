// DbChequeTickets.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Sockets;
using ClassLibraryModel;

namespace ClassLibraryDataAccess
{
    public class DbChequeTickets
    {
        public static void SaveChequeTicket(ModelCheckTicket ticket)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SaveChequeTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
      
                cmd.Parameters.AddWithValue("@EventId", ticket.Eventid);
                cmd.Parameters.AddWithValue("@BookingId", ticket.UserId);
                cmd.Parameters.AddWithValue("@Price", ticket.Price);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteChequeTicket(int checkId)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteChequeTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CheckId", checkId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateChequeTicket(int checkId, ModelCheckTicket ticket)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateChequeTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CheckId", checkId);
               
                cmd.Parameters.AddWithValue("@EventId", ticket.Eventid);
                cmd.Parameters.AddWithValue("@BookingId", ticket.UserId);
                cmd.Parameters.AddWithValue("@Price", ticket.Price);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<ModelCheckTicket> GetAllChequeTickets()
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAllChequeTickets", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelCheckTicket> tickets = new List<ModelCheckTicket>();
            while (reader.Read())
            {
                ModelCheckTicket ct = new ModelCheckTicket();

                ct.CheckId = Convert.ToInt32(reader["CheckId"]);
                ct.Eventid = Convert.ToInt32(reader["EventId"]);
                
                ct.UserId = Convert.ToInt32(reader["BookingId"]);
                ct.Price = Convert.ToDecimal(reader["Price"]);
                tickets.Add(ct);
            }
            return tickets;

        }

    }
}