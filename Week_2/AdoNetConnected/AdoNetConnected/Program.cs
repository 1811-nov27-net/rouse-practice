using System;
using System.Data.SqlClient;

namespace AdoNetConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.NET is technically Microsoft's name for all data-related libraries, including Entity Framework
            // "ADO.NET" is, in practice, referring to older ways of doing things with DataReader, DataAdapter objects (rather than Entity Framework)

            // In various GUIs, you need the server URL and login credentials; code has a convention to use a connection string which provides the required data for connection (to some kind of data source, SQL Server, Excel files, etc)

            // NEVER commit your connection strings to source control like git, they're basically passwords

            var connectionString = SecretConfiguration.ConnectionString;

            //Console.WriteLine("Enter your query to the movies DB:");
            // var commandString = Console.ReadLine();
            // ^ allows SQL injection ^
            // un-sanitized user must not be used to construct SQL queries directly, or else hackers can acess and/or destroy things

            Console.WriteLine("Enter name of movie: ");
            var input = Console.ReadLine();
            var commandString = $"SELECT * FROM Movies.Movie WHERE Name = '{input}';";


            // var commandString = "SELECT * FROM Movies.Movie";

            // Connected architecture recieves the whols result and have it waiting in the network buffer and use an iterator to read it in row by row

            using (var connection = new SqlConnection(connectionString))
            {
                // Connected architecture:
                // Step 1 - Open the connection
                connection.Open();

                // Step 2 - Execute the query
                using (var command = new SqlCommand(commandString, connection))

                // command.ExecuteReader for SELECT queries that return things (returns a DataReader)
                // command.ExecuteNonQuery for all other commands that don't return things (returns an int for number of rows affected)
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Step 3 - Process results
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = reader["ID"];  // Access values by column name
                            var name = reader["Name"];
                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
                    }

                }

                // Step 4 - Close the connection
                connection.Close();
            }
        }
    }
}
