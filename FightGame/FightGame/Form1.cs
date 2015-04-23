using System;
using System.Globalization;
using System.Windows.Forms;

namespace FightGame
{
    public partial class Form1 : Form
    {
        private Team _team1;
        private Team _team2;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateTeams()
        {
            var team1Players = new Player[5];
            var team2Players = new Player[5];
            int[] playersId = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 10; i++)
            {
                int id;
                string sid = "";
                for (;;)
                {
                    var rnd = new Random(DateTime.Now.Millisecond);
                    id = rnd.Next(1, 21);

                    for (int j = 0; j <= i; j++)
                    {
                        if (id == playersId[j]) break;
                        playersId[i] = id;
                    }
                    if (playersId[i] != 0) break;
                }

                
                   for (int j = 0; j < 10; j++)
                    {
                        sid += playersId[j].ToString() + " ";
                    }
              

                MessageBox.Show(id.ToString(CultureInfo.InvariantCulture));
                MessageBox.Show(sid);

                var con = new DatabasePlayerConstructor(id);
                if (i < 5)
                    team1Players[i] = new Player(con);
                else
                    team2Players[i - 5] = new Player(con);

            }

            _team1 = new Team(team1Players);
            _team2 = new Team(team2Players);
        }

        private void FillInfo()
        {
            for (int i = 0; i < 5; i++)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateTeams();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
