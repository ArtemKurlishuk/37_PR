using MySql.Data.MySqlClient;

namespace Shop.Data.Common
{
    public class Connection
    {
        /// <summary>
        /// Настроки для подключения сервера
        /// </summary>
        readonly static string ConnctionData = "server=student.permaviat.ru;port=3306;database=ISP_21_2_8;uid=ISP_21_2_8;pwd=D17IDNLg4#;";
        readonly static string ConnctionDataHome = "server=localhost;port=3306;database=shop2;uid=root;";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection NewMySqlConnction = new MySqlConnection(ConnctionDataHome);
            NewMySqlConnction.Open();
            return NewMySqlConnction;
        }

        /// <summary>
        /// Выполнение запроса
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, Connection);
            return NewMySqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Закрываем соединение с базой данных
        /// </summary>
        /// <param name="Connection"></param>
        public static void MysqlColose(MySqlConnection Connection)
        {
            Connection.Close();
        }
    }
}
