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
                Console.WriteLine("Успешное подключение к БД"+"\n");
                //  получить все записи из таблицы
                // 4. получить все записи из таблицы 
                // 4.1. сформировать объект sql-команды
                string queryString = "SELECT * FROM game_t;";
                SqlCommand queryCommand = new SqlCommand(queryString, connection);
                // 4.2. выполнить sql-команду
                SqlDataReader result = queryCommand.ExecuteReader();   // выполнение sql-запроса с табличным результатом
                                                                       // 4.3. считать результат запроса - отложенное выполнение
                while (result.Read())
                {
                    long id = (long)result[0];                  // получаем id
                    string name = (string)result[1];            // получаем имя
                    int releasedIn = (int)result[2];            // год публикации
                    decimal price = (decimal)result[3];         // цена
                    Console.WriteLine($"{id} - {name} - {releasedIn} - {price}");
                }

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
