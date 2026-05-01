namespace LibraryStockUpdater;

using MySql.Data.MySqlClient;
using DotNetEnv;

public class Program
{
    public static void Main()
    {
        
        Env.Load();
       
        string server = Environment.GetEnvironmentVariable("DB_SERVER");
        string database = Environment.GetEnvironmentVariable("DB_DATABASE");
        string user = Environment.GetEnvironmentVariable("DB_USER");
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

       
        string connectionString = $"server={server};database={database};user={user};password={password};";

        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;

        int bookId;
        int quantity;
        string response;

        List<int> idList = new List<int>();

        bool running = true;

        while (running)
        {
            Console.Clear();
            idList.Clear();

            string line = "===========================";
            Console.WriteLine(line);
            Console.WriteLine("        Book List");
            Console.WriteLine(line);
            Console.WriteLine();

            using (connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM books;";

                using (command = new MySqlCommand(sql, connection))
                using (reader = command.ExecuteReader())
                {
                    int counter = 0;

                    while (reader.Read())
                    {
                        counter++;
                        Console.WriteLine($"{counter}º Book");
                        Console.WriteLine($"Id: {reader["id"]}");
                        Console.WriteLine($"Title: {reader["titulo"]}");
                        Console.WriteLine($"Quantity: {reader["quantidade"]}");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();

                        idList.Add(Convert.ToInt32(reader["id"]));
                    }
                }
            }

            Console.WriteLine(line);
            Console.WriteLine("Update Stock");
            Console.WriteLine(line);
            Console.WriteLine("Enter the book ID you want to update:");

            while (!int.TryParse(Console.ReadLine(), out bookId))
                Console.WriteLine("Enter a valid ID.");

            while (!idList.Contains(bookId))
            {
                Console.WriteLine("ID not found. Try again:");
                Console.WriteLine(line);
                Console.WriteLine("Enter the book ID you want to update:");
                while (!int.TryParse(Console.ReadLine(), out bookId))
                    Console.WriteLine("Enter a valid ID.");
            }

            Console.WriteLine("Enter the new quantity:");
            while (!int.TryParse(Console.ReadLine(), out quantity))
                Console.WriteLine("Enter a valid quantity.");

            using (connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sqlUpdate = "UPDATE books SET quantity = @quantity WHERE id = @bookId";

                using (command = new MySqlCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@bookId", bookId);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Update completed successfully!");
            }

            do
            {
                Console.WriteLine("Update another book? [Y] Yes / [N] No:");
                response = Console.ReadLine().ToLower();

                if (response == "n")
                {
                    running = false;
                    Console.WriteLine(line);
                    Console.WriteLine("Closing program...");
                    Console.WriteLine(line);
                }
                else if (response == "y")
                {
                    break;
                }

                if (response != "n" && response != "y")
                    Console.WriteLine("Invalid response. Try again.");

            } while (response != "n" && response != "y");
        }
    }
}
