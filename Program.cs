using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            try
            {
                // Подключение к БД
                // 1. создать объект SqlConnection
                SqlConnection connection = new SqlConnection();
                // 2. установить строку подключения
                string connectionString = @"Data Source=fishman\SQLEXPRESS;
                                Initial Catalog=computer_game_db;
                                Integrated Security=SSPI;";
                connection.ConnectionString = connectionString;
                // 3. открыть подключение (подключиться к БД)
                connection.Open();
                Console.WriteLine("Успешное подключение к БД");
                // 4. закрыть подключение
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Что-то пошло не так: {ex}");
            }

        }
    }
}
