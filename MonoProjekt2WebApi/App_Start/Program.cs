using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MonoProjekt2WebApi.App_Start
{
    public class Program
    {
		static public void Main()

		{
            System.Diagnostics.Debug.WriteLine("radi");
            // Assumes connectionString is a valid connection string.  
            string connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

                // Do work here.  
                // Assumes that connection represents a SqlConnection object.  

                string queryString = "CREATE TABLE table1 ( red1 varchar(10));";
                SqlCommand command = new SqlCommand(queryString, connection);
                

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
		}
	}
}