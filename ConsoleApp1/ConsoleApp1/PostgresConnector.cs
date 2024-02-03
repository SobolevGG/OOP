using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Npgsql;

public class PostgresConnector
{
    private readonly string connectionString;

    public PostgresConnector(string host, string database, string username, string password)
    {
        // Формирование строки подключения
        connectionString = $"Host={host};Database={database};Username={username};Password={password};";
    }

    public bool TestConnection()
    {
        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    public void ExecuteNonQuery(string sql)
    {
        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
        }
    }

    public NpgsqlDataReader ExecuteQuery(string sql)
    {
        try
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var command = new NpgsqlCommand(sql, connection);
            return command.ExecuteReader();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public void CloseConnection()
    {
        // Закрытие соединения
    }
}
