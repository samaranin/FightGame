using System.Data.OleDb;

namespace FightGame
{
    //class to update and reset fortune values
    abstract class FortuneChanger
    {
        //connection
        static OleDbConnection _connection;

        //update fortune for winner
        public static void ChangeFortune(Player player)
        {
            //creates new connection
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

            //look down
            SetNewFortune(player);

            _connection.Close();
        }

        //set new values
        private static void SetNewFortune(Player player)
        {
            //command to update
            var cmd = new OleDbCommand
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE PlayersInfo SET [Fortune] = @Fortune WHERE [ID] = @ID",
                Connection = _connection
            };

            //set values
            cmd.Parameters.AddWithValue("@Fortune", player.GetPlayerFortune());
            cmd.Parameters.AddWithValue("@ID", player.GetPlayerId());

            //execute command
            cmd.ExecuteNonQuery();
        }

        //reset fortune values from enother table
        public static void ResetFortune()
        {
            //one more connection
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

            //array for base fortune values
            var baseFortune = new double[20];

            //cycle for every player
            for (var id = 1; id <= 20; id++)
            {
                //gets our base values
                var command = new OleDbCommand
                {
                    CommandText = "SELECT * FROM BaseFortune WHERE ID = " + id + ";",
                    Connection = _connection
                };

                OleDbDataReader dataReader = command.ExecuteReader();

                //and fill array
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        baseFortune[id -1] = (double)dataReader["BaseFortuneValue"];
                    }
                    dataReader.Close();
                }

                //then update main table
                var cmd = new OleDbCommand
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "UPDATE PlayersInfo SET [Fortune] = @Fortune WHERE [ID] = @ID",
                    Connection = _connection

                };

                //with this parameters
                cmd.Parameters.AddWithValue("@Fortune", baseFortune[id - 1]);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();

                command.ExecuteNonQuery();
            }

            //and close connection
            _connection.Close();
        }
    }
}
