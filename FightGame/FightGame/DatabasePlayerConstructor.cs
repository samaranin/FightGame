using System.Data.OleDb;

namespace FightGame
{
    class DatabasePlayerConstructor
    {
        public DatabasePlayerConstructor()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=players.mdb";

            OleDbCommand command = new OleDbCommand();
            command.CommandText = "SELECT * FROM PlayersInfo";
            command.Connection = connection;
            connection.Open();
            OleDbDataReader dataReader1 = command.ExecuteReader();

            while (dataReader1.Read())
            {
                //label1.Text = label1.Text + dataReader1["PlayerName"] + "\n";
            }

            dataReader1.Close();
            connection.Close();
        }
    }
}
