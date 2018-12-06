using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDisconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.ConnectionString;

            Console.WriteLine("Enter name of movie: ");
            var input = Console.ReadLine();
            var commandString = $"SELECT * FROM Movies.Movie WHERE Name = '{input}';";


            // var commandString = "SELECT * FROM Movies.Movie";

            // Disconnected architecture waits to get the whold result and load it into a "DataSet" (in-memory collection), close the connection, then process results
            // This has more overhead on the C# side, but it keeps the connection open for less time and prevents bottlenecking by/around the database

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                // Disconnected architecture:
                // Step 1 - Open the connection
                connection.Open();

                // Step 2 - Execute the query, filling the data set
                using (var command = new SqlCommand(commandString, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                    // ^ Still uses DataReader object internally
                }

                // Step 3 - Close the connection
                connection.Close();

                // Step 4 - Process results
                var firstTable = dataSet.Tables[0];
                
                // Foreach without generics does a cast when you assign the type right here (DataRow)
                foreach(DataRow row in firstTable.Rows)
                {
                    object id = row["ID"];
                    object name = row["Name"];
                    Console.WriteLine($"ID: {id}, Name: {name}");
                }
            }
        }
    }
}
