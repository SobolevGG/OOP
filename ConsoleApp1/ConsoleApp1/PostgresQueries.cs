using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PostgresQueries
    {
        // Пароль для доступа к базе данных
        private static string passwordDB = "023098";

        // Только для чтения свойство
        public static string PasswordDB
        {
            get { return passwordDB; }
        }

        /// <summary>
        /// Вставляет или обновляет данные гидрогенератора в базе данных.
        /// </summary>
        /// <param name="id">Идентификатор гидрогенератора.</param>
        /// <param name="name">Название гидрогенератора.</param>
        /// <param name="characteristic">Текущая эксплуатационная характеристика.</param>

        public static void InsertOrUpdateHydroGenerator(int id, string name, string characteristic)
        {
            var connector = new PostgresConnector("localhost", "HPPs", "postgres", $"{PasswordDB}");
            string sqlQuery = $@"
        INSERT INTO hydro_generators (id, name, hydro_power_plant_id, characteristic, last_change_date)
        VALUES ({id}, '{name}', 1, '{characteristic}', CURRENT_TIMESTAMP)
        ON CONFLICT (id) DO UPDATE
        SET
            name = EXCLUDED.name,
            hydro_power_plant_id = EXCLUDED.hydro_power_plant_id,
            characteristic = EXCLUDED.characteristic,
            last_change_date = EXCLUDED.last_change_date;";

            connector.ExecuteNonQuery(sqlQuery);
        }

        public static NpgsqlDataReader SelectProtocol(PostgresConnector connector)
        {
            // Чтение данных из столбцов name, characteristic и change_date из таблицы generator_characteristic_history
            string selectQuery = "SELECT hydro_generators.name, generator_characteristic_history.characteristic, generator_characteristic_history.change_date " +
                "FROM generator_characteristic_history " +
                "JOIN hydro_generators ON generator_characteristic_history.generator_id = hydro_generators.id;";
            var reader = connector.ExecuteQuery(selectQuery);
            return reader;
        }

        public static NpgsqlDataReader SelectCharacteristics(PostgresConnector connector)
        {
            // Чтение данных из столбцов name, characteristic и change_date из таблицы generator_characteristic_history
            string selectQuery = "SELECT name, characteristic FROM hydro_generators;";
            var reader = connector.ExecuteQuery(selectQuery);
            return reader;
        }
    }
}
