using System.Data.OleDb;

namespace FightGame
{
<<<<<<< HEAD
    //class to update and reset fortune values
    abstract class FortuneChanger
    {
        //connection
        static OleDbConnection _connection;

        //update fortune for winner
        public static void ChangeFortune(Player player)
        {
            //creates new connection
=======
    abstract class FortuneChanger
    {
        static OleDbConnection _connection;

        public static void ChangeFortune(Player player)
        {
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

<<<<<<< HEAD
            //look down
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
            SetNewFortune(player);

            _connection.Close();
        }

<<<<<<< HEAD
        //set new values
        private static void SetNewFortune(Player player)
        {
            //command to update
=======
        private static void SetNewFortune(Player player)
        {
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
            var cmd = new OleDbCommand
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE PlayersInfo SET [Fortune] = @Fortune WHERE [ID] = @ID",
                Connection = _connection
            };
<<<<<<< HEAD

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
=======
            cmd.Parameters.AddWithValue("@Fortune", player.GetPlayerFortune());
            cmd.Parameters.AddWithValue("@ID", player.GetPlayerId());

            cmd.ExecuteNonQuery();
        }

        public static void ResetFortune()
        {
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

<<<<<<< HEAD
            //array for base fortune values
            var baseFortune = new double[20];

            //cycle for every player
            for (var id = 1; id <= 20; id++)
            {
                //gets our base values
=======
            var baseFortune = new double[20];

            for (var id = 1; id <= 20; id++)
            {
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
                var command = new OleDbCommand
                {
                    CommandText = "SELECT * FROM BaseFortune WHERE ID = " + id + ";",
                    Connection = _connection
                };

                OleDbDataReader dataReader = command.ExecuteReader();

<<<<<<< HEAD
                //and fill array
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        baseFortune[id -1] = (double)dataReader["BaseFortuneValue"];
                    }
                    dataReader.Close();
                }

<<<<<<< HEAD
                //then update main table
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
                var cmd = new OleDbCommand
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "UPDATE PlayersInfo SET [Fortune] = @Fortune WHERE [ID] = @ID",
                    Connection = _connection

                };
<<<<<<< HEAD

                //with this parameters
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
                cmd.Parameters.AddWithValue("@Fortune", baseFortune[id - 1]);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();

                command.ExecuteNonQuery();
            }

<<<<<<< HEAD
            //and close connection
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
            _connection.Close();
        }
    }
}
