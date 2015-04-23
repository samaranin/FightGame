using System.Data.OleDb;

namespace FightGame
{
    class DatabasePlayerConstructor: Player
    {
        readonly OleDbConnection _connection;
        private string _name;
        private readonly int _id;
        private int _strength;
        private int _agility;
        private int _intellect;
        private double _endurance;
        private int _clothes;
        private int _weapon;
        private double _fortune;

        public DatabasePlayerConstructor(int id)
        {
            _connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb"
            };
            _connection.Open();

            _id = id;
            GetPlayerInformation(id);
            _connection.Close();

        }
        private void GetPlayerInformation(int id)
        {
            var command = new OleDbCommand
            {
                CommandText = "SELECT * FROM PlayersInfo WHERE ID = " + id + ";",
                Connection  = _connection
            };

            OleDbDataReader dataReader = command.ExecuteReader();

            if (dataReader != null && dataReader.HasRows)
            {
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
