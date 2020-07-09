using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BookApp.API.Entities;

namespace BookApp.DAL
{
    public class UserContext : IUser
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        public UserContext()
        {
            conn = new SqlConnection("data source=NIKITAT-MSD2\\SQLEXPRESS2014; initial catalog=BookAppDB; integrated security=true");
        }

        public bool AddUser(User user)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "AddUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Name", user.UserName);
                cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Contact", user.Contact);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@StateId", user.StateId);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cmd.Parameters.AddWithValue("@PostalCode", user.PostalCode);

                conn.Open();

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool UserLogin(string emailId, string password)
        {
            bool status = false;
            //User u1 = null;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UserLogin";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmailId", emailId);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    status = true;
                }
                else
                {
                    throw new Exception("Invalid User Credentials.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return status;
        }

        public List<User> GetUsers()
        {
            List<User> list = null;

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "usp_Get_Users";

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    list = new List<User>();
                    while (reader.Read())
                    {
                        User u1 = new User
                        {
                            UserId = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            EmailId = reader.GetString(2),
                            Password = reader.GetString(3),
                            Contact = reader.GetInt64(4),
                            Gender = reader.GetString(5),
                            Address = reader.GetString(6),
                            StateId = reader.GetInt32(7),
                            CityId = reader.GetInt32(8),
                            PostalCode = reader.GetInt32(9),
                            Token = reader.GetString(10)
                        };

                        list.Add(u1);
                    }
                }
                else
                {
                    throw new Exception("No Data found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in reading...." + list.Count);
                throw ex;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return list;

        }
    }
}
