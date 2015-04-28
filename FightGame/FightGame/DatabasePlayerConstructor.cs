using System.Data.OleDb;

namespace FightGame
{
    //this class copy player's info from database to program
    class DatabasePlayerConstructor: Player
    {
        //connection parameter
        readonly OleDbConnection _connection;

        //players stats
        private string _name;
        private readonly int _id;
        private int _strength;
        private int _agility;
        private int _intellect;
        private double _endurance;
        private int _clothes;
        private int _weapon;
        private double _fortune;

        //constructor
        public DatabasePlayerConstructor(int id)
        {
            //create new connection
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

            _id = id;

            //gets info from database
            GetPlayerInformation(id);

            _connection.Close();
        }

        //gets info from database
        private void GetPlayerInformation(int id)
        {
            //sql command
            var command = new OleDbCommand
            {
                CommandText = "SELECT * FROM PlayersInfo WHERE ID = " + id + ";",
                Connection  = _connection
            };

            //data reader
            OleDbDataReader dataReader = command.ExecuteReader();

            if (dataReader != null && dataReader.HasRows)
            {
                //copy data to vars
                while (dataReader.Read())
                {
                    _name       = (string) dataReader["PlayerName"];
                    _strength   = int.Parse(dataReader["Strength"].ToString());
                    _agility    = int.Parse(dataReader["Agility"].ToString());
                    _intellect  = int.Parse(dataReader["Intellect"].ToString());
                    _endurance  = double.Parse(dataReader["Endurance"].ToString());
                    _clothes    = int.Parse(dataReader["Clothes"].ToString());
                    _weapon     = int.Parse(dataReader["Weapon"].ToString());
                    _fortune    = double.Parse(dataReader["Fortune"].ToString());
                }
                dataReader.Close();
            }
        }

        //gets parameters from constructor
        public new string GetPlayerName()
        {
            return _name;
        }

        public new int GetPlayerId()
        {
            return _id;
        }

        public new int GetPlayerStrength()
        {
            return _strength;
        }

        public new int GetPlayerAgility()
        {
            return _agility;
        }

        public new int GetPlayerIntellect()
        {
            return _intellect;
        }

        public new double GetPlayerEndurance()
        {
            return _endurance;
        }

        public new int GetPlayerClothes()
        {
            return _clothes;
        }

        public new int GetPlayerWeapon()
        {
            return _weapon;
        }

        public new double GetPlayerFortune()
        {
            return _fortune;
        }
    }
}
