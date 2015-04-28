using System.Data.OleDb;

namespace FightGame
{
    abstract class FortuneChanger
    {
        static OleDbConnection _connection;

        public static void ChangeFortune(Player player)
        {
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

            SetNewFortune(player);

            _connection.Close();
        }

        private static void SetNewFortune(Player player)
        {
            var cmd = new OleDbCommand
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE PlayersInfo SET [Fortune] = @Fortune WHERE [ID] = @ID",
                Connection = _connection
            };
            cmd.Parameters.AddWithValue("@Fortune", player.GetPlayerFortune());
            cmd.Parameters.AddWithValue("@ID", player.GetPlayerId());

            cmd.ExecuteNonQuery();
        }

        public static void ResetFortune()
        {
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

            var baseFortune = new double[20];

            for (var id = 1; id <= 20; id++)
            {
                var command = new OleDbCommand
                {
                    CommandText = "SELECT * FROM BaseFortune WHERE ID = " + id + ";",
                    Connection = _connection
                };

                OleDbDataReader dataReader = command.ExecuteReader();

                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        baseFortune[id -1] = (double)dataReader["BaseFortuneValue"];
                    }
                    dataReader.Close();
                }

                var cmd = new OleDbCommand
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "UPDATE PlayersInfo SET [Fortune] = @Fortune WHERE [ID] = @ID",
                    Connection = _connection

                };
                cmd.Parameters.AddWithValue("@Fortune", baseFortune[id - 1]);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();

                command.ExecuteNonQuery();
            }

            _connection.Close();
        }
    }
}
