using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDataAccess
{
    public class DbUser
    {
        public static void SaveUserInformation(ModelUser user)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("saveUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteUserInformation(int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateUserInformation(int id, ModelUser user)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@UserRole", user.UserRole);
                cmd.ExecuteNonQuery();
            }
        }

       
            public static List<ModelUser> GetUserInformation()
            {
                SqlConnection con = DbHelper.GetConnection();
                con.Open();


                SqlCommand cmd = new SqlCommand("getAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<ModelUser> listUsers = new List<ModelUser>();

                while (reader.Read())
                {
                    ModelUser us = new ModelUser();

                    us.UserId = Convert.ToInt32(reader["UserID"]);
                    us.Username = reader["Username"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Password = reader["Password"].ToString();
                    us.FullName = reader["FullName"].ToString();
                    us.PhoneNumber = reader["PhoneNumber"].ToString();
                    us.UserRole = reader["UserRole"].ToString();
                    
                    listUsers.Add(us);
                }
                con.Close();

                return listUsers;
            }
        

        public static void UpdateUserPassword(string email, string newPassword)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateUserPassword", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getAllUsers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                var result = (int)cmd.ExecuteScalar();
                return result == 1;
            }
        }
    }
}
