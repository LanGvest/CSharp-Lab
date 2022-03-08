using System;
using System.Data.OleDb;

namespace Lab3
{
    public class DatabaseManager
    {
        private static DatabaseManager _databaseManager;
        private string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";

        private DatabaseManager()
        {
            
        }

        public static DatabaseManager GetInstance()
        {
            return _databaseManager ?? (_databaseManager = new DatabaseManager());
        }

        public void PrintTable()
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "SELECT * FROM Cars";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();
            if (dbReader.HasRows)
            {
                Console.WriteLine("┌────┬" + "".PadRight(30, '─') + "┬" + "".PadRight(20, '─')  + "┬" + "".PadRight(20, '─') + "┐");
                Console.WriteLine("│ ID │" + " МОДЕЛЬ".PadRight(30) + "│" + " ЦЕНА".PadRight(20)  + "│" + " КОЛ-ВО".PadRight(20) + "│");
                Console.WriteLine("╞════╪" + "".PadRight(30, '═') + "╪" + "".PadRight(20, '═')  + "╪" + "".PadRight(20, '═') + "╡");
                bool ignore = true;
                while (dbReader.Read())
                {
                    if (!ignore)
                    {
                        Console.WriteLine("├────┼" + "".PadRight(30, '─') + "┼" + "".PadRight(20, '─')  + "┼" + "".PadRight(20, '─') + "┤");
                    }
                    ignore = false;
                    Console.WriteLine(
                        "│ {0} | {1} | {2} | {3} |",
                        dbReader["ID"].ToString().PadLeft(2),
                        dbReader["Model"].ToString().PadRight(28),
                        dbReader["Price"].ToString().PadLeft(18),
                        dbReader["Amount"].ToString().PadLeft(18)
                    );
                }
                Console.WriteLine("└────┴" + "".PadRight(30, '─') + "┴" + "".PadRight(20, '─')  + "┴" + "".PadRight(20, '─') + "┘");
            }
            else
            {
                Console.WriteLine("Данные не обнаружены!");
            }
            dbReader.Close();
            dbConnection.Close();
        }
        
        public void Add()
        {
            Console.Write("Модель: ");
            string model = Console.ReadLine();
            Console.Write("Цена: ");
            string price = Console.ReadLine();
            Console.Write("Кол-во: ");
            string amount = Console.ReadLine();
            OleDbConnection dbConnection = new OleDbConnection();
            try
            {
                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
                string query = "INSERT INTO Cars (Model, Price, Amount) VALUES ('" + model + "', " + price + ", " + amount +");";
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    Console.WriteLine("Не удалось добавить!");
                }
                else
                {
                    Console.WriteLine("Успешно добавлено!");
                }
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public void Update()
        {
            Console.Write("Укажите ID автомобиля: ");
            string id = Console.ReadLine();
            Console.Write("Новая цена: ");
            string price = Console.ReadLine();
            Console.Write("Новое кол-во: ");
            string amount = Console.ReadLine();
            OleDbConnection dbConnection = new OleDbConnection();
            try
            {
                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
                string query = "UPDATE Cars SET Price = " + price + ", Amount = " + amount + " WHERE ID = " + id;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    Console.WriteLine("Не удалось обновить!");
                }
                else
                {
                    Console.WriteLine("Успешно обновлено!");
                }
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                dbConnection.Close();
            }
        }
        
        public void Delete()
        {
            Console.Write("Укажите ID автомобиля: ");
            string id = Console.ReadLine();
            OleDbConnection dbConnection = new OleDbConnection();
            try
            {
                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
                string query = "DELETE FROM Cars WHERE ID = " + id;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    Console.WriteLine("Не удалось удалить!");
                }
                else
                {
                    Console.WriteLine("Успешно удалено!");
                }
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}