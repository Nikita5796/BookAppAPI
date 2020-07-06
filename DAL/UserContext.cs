using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demoAuthApp.Entities;
using demoAuthApp.Helpers;
using Microsoft.IdentityModel.Protocols;

namespace demoAuthApp.DAL
{
    public class UserContext : IUser
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader; 
        SQLConnection connection = new SQLConnection();

        public UserContext()
        {
            conn = connection.GetConnection();
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
                            Contact = reader.GetInt32(4),
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
