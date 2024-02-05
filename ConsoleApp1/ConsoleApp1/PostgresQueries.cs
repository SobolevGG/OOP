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
        /// <summary>
        /// Вставляет или обновляет данные гидрогенератора в базе данных.
        /// </summary>
        /// <param name="id">Идентификатор гидрогенератора.</param>
        /// <param name="name">Название гидрогенератора.</param>
        /// <param name="characteristic">Текущая эксплуатационная характеристика.</param>
        /// <param name="enteredLogin">Введенное значение логина.</param>
        /// <param name="enteredPassword">Введенное значение пароля.</param>
        public static void InsertOrUpdateHydroGenerator(int id, string name, string characteristic, string enteredLogin, string enteredPassword)
        {
            var connector = new PostgresConnector("localhost", "HPPs", enteredLogin, enteredPassword);
            string sqlQuery = $@"
            INSERT INTO hydro_generators (id, name, 
            hydro_power_plant_id, characteristic, last_change_date)
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
            string selectQuery = "SELECT hg.number AS generator_number, " +
                "gch.characteristic, " +
                "gch.max_load, " +
                "gch.rough_zone_fb, " +
                "gch.rough_zone_sb, " +
                "gch.change_date FROM generator_characteristic_history gch " +
                "JOIN hydro_generators hg " +
                "ON gch.generator_uid = hg.uid " +
                "ORDER BY hg.number ASC, gch.change_date DESC;";
            var reader = connector.ExecuteQuery(selectQuery);
            return reader;
        }

        public static NpgsqlDataReader SelectCharacteristics(PostgresConnector connector)
        {
            // Чтение данных из столбцов name, characteristic и change_date из таблицы generator_characteristic_history
            string selectQuery = "SELECT number, " +
                "characteristic, " +
                "max_load, " +
                "rough_zone_fb, " +
                "rough_zone_sb " +
                "FROM hydro_generators " +
                "ORDER BY number;";
            var reader = connector.ExecuteQuery(selectQuery);
            return reader;
        }
    }
}
