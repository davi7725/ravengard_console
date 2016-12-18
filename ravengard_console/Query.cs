using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ravengard_console
{
    class Query
    {
        public string connectionString { get; set; }
        public string ProductName { get; set; }

        public void QueryMethod(string ColumnName, string TableName)
        {
            decodeConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("Select " + ColumnName + " From " + TableName, con);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            int id = reader.GetInt32(1);
                            ProductName = reader.GetString(0);
                            Console.WriteLine(id + ". " + ProductName);
                        }
                    }

                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal void decodeConnectionString()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\Key.txt");
            byte[] data = Convert.FromBase64String(file.ReadLine());
            string decodedString = Encoding.UTF8.GetString(data);
            connectionString = decodedString;
            file.Close();
        }

        internal void CreateUser(string createName, string createLastName, string createPhoneNR, string createAddress, string createUsername, string createPassword)
        {
            decodeConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("prc_CreateUser", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@FirstName", createUsername);
                    cmd2.Parameters.AddWithValue("@LastName", createLastName);
                    cmd2.Parameters.AddWithValue("@Phone", createPhoneNR);
                    cmd2.Parameters.AddWithValue("@AddressInfo", createAddress);
                    cmd2.Parameters.AddWithValue("@username", createUsername);
                    cmd2.Parameters.AddWithValue("Cli_Password", createPassword);
                    cmd2.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("Account Created! Try logging in!");
                    con.Close();
                }
            }
        }

        internal bool LogUserIn(string username, string password)
        {
            decodeConnectionString();
            bool loggedIn = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("Select username,Cli_Password from Client", con);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Ui print = new Ui();
                        while (reader.Read())
                        {

                            if (username == reader["username"].ToString() && password == reader["Cli_Password"].ToString())
                            {
                                loggedIn = true;
                            }

                        }
                        if(loggedIn == false)
                        {
                            Console.WriteLine("Incorrect Password! Try again!");
                            Console.ReadLine();
                        }
                    }

                }
                catch (SqlException ex)
                {
                    loggedIn = false;
                    Console.WriteLine(ex);
                }
                finally
                {
                    con.Close();
                }
                return loggedIn;
            }
        }
    }
}
