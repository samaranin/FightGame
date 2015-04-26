using System;
using System.Linq;
using System.Windows.Forms;

namespace FightGame
{
    public partial class Form1 : Form
    {
        //private Team _team1 = new Team();
        //private Team _team2 = new Team();
        readonly Player[] _team1Players = new Player[5];
        readonly Player[] _team2Players = new Player[5];

        readonly Label[] _secondTeamNames = new Label[5];
        readonly Label[] _firstTeamNames = new Label[5];
        readonly Label[] _firstTeam = new Label[5];
        readonly Label[] _secondTeam = new Label[5];
        private int _round;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateTeams()
        {  
            const int arrayLength = 10;
            const int maxRandomNum = 20; 
            var rand = new Random(unchecked((int)(DateTime.Now.Ticks)));
            var id = Enumerable.Range(1, maxRandomNum).OrderBy(i => rand.Next()).Take(arrayLength).ToArray();

            for (var j = 0; j < 5; j++)
            {
                var constructor = new DatabasePlayerConstructor(id[j]);
                _team1Players[j] = new Player(constructor);
            }

            for (var j = 5; j < 10; j++)
            {
                var constructor = new DatabasePlayerConstructor(id[j]);
                _team2Players[j - 5] = new Player(constructor);
            }

        }

        private void FillInfo()
        {
            
            for (int j = 0; j < 5; j++)
            {
                _firstTeamNames[j] = new Label
                {
                    Left = 7, 
                    Top = 31 + j * 30, 
                    Text =  _team1Players[j].GetPlayerName(), 
                    Visible = true, 
                    Name = "firstTeamPlayerName00" + j,
                    AutoSize = true
                };

                groupBox1.Controls.Add(_firstTeamNames[j]);

            }

            
            for (int j = 0; j < 5; j++)
            {
                _secondTeamNames[j] = new Label
                {
                    Left = 7,
                    Top = 31 + j*30,
                    Text = _team2Players[j].GetPlayerName(),
                    Visible = true,
                    Name = "secondTeamPlayerNames00" + j,
                    AutoSize = true
                };
                groupBox2.Controls.Add(_secondTeamNames[j]);

            }


            for (int j = 0; j < 5; j++)
            {
                string info = "  "
                          + String.Format("{0, 2}", _team1Players[j].GetPlayerStrength()) + "       "
                          + String.Format("{0, 2}", _team1Players[j].GetPlayerAgility()) + "       "
                          + String.Format("{0, 2}", _team1Players[j].GetPlayerIntellect()) + "       "
                          + String.Format("{0:0.00}", _team1Players[j].GetPlayerEndurance()) + "       "
                          + String.Format("{0, 2}", _team1Players[j].GetPlayerWeapon()) + "       "
                          + String.Format("{0, 2}", _team1Players[j].GetPlayerClothes()) + "      "
                          + String.Format("{0:0.00}", _team1Players[j].GetPlayerFortune());

                _firstTeam[j] = new Label { Left = 192, Top = 31 + j * 30, Text = info, Visible = true, Name = "firstTeamPlayerStat00" + j, AutoSize = true };
                groupBox1.Controls.Add(_firstTeam[j]);

            }
          
            for (int j = 0; j < 5; j++)
            {
                string info = "  "
                          + String.Format("{0, 2}", _team2Players[j].GetPlayerStrength()) + "       "
                          + String.Format("{0, 2}", _team2Players[j].GetPlayerAgility()) + "       "
                          + String.Format("{0, 2}", _team2Players[j].GetPlayerIntellect()) + "       "
                          + String.Format("{0:0.00}", _team2Players[j].GetPlayerEndurance()) + "       "
                          + String.Format("{0, 2}", _team2Players[j].GetPlayerWeapon()) + "       "
                          + String.Format("{0, 2}", _team2Players[j].GetPlayerClothes()) + "      "
                          + String.Format("{0:0.00}", _team2Players[j].GetPlayerFortune());

                _secondTeam[j] = new Label { Left = 192, Top = 31 + j * 30, Text = info, Visible = true, Name = "secondTeamPlayerStat00" + j, AutoSize = true };
                groupBox2.Controls.Add(_secondTeam[j]);

            }
        }


        private void ClearWindow()
        {
            for (var j = 0; j < 5; j++)
            {
                if (groupBox1.Controls.Contains(_firstTeamNames[j]))
                {
                    groupBox1.Controls.Remove(_firstTeamNames[j]);
                    _firstTeamNames[j].Dispose();
                }

                if (groupBox2.Controls.Contains(_secondTeamNames[j]))
                {
                    groupBox2.Controls.Remove(_secondTeamNames[j]);
                    _secondTeamNames[j].Dispose();
                }

                if (groupBox1.Controls.Contains(_firstTeam[j]))
                {
                    groupBox1.Controls.Remove(_firstTeam[j]);
                    _firstTeam[j].Dispose();
                }
                if (!groupBox2.Controls.Contains(_secondTeam[j])) continue;
                groupBox2.Controls.Remove(_secondTeam[j]);
                _secondTeam[j].Dispose();
            }
        }

        private static string Winner(bool marker)
        {
            return marker ? "Team 1 wins!!!" : "Team 2 wins!!!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearWindow();
            CreateTeams();
            FillInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_team1 = new Team(_team1Players);
            //_team2 = new Team(_team2Players);

            _round++;
            double team1Power = 0;
            double team2Power = 0;
            for (var i = 0; i < 5; i++)
            {
                team1Power += _team1Players[i].GetPlayerMight();
                team2Power += _team2Players[i].GetPlayerMight();
            }
            var marker = team1Power >= team2Power;

            switch (_round)
            {
                case 1:
                    textBox1.Text = Winner(marker);
                    break;
                case 2:
                    textBox2.Text = Winner(marker);
                    break;
                case 3:
                    textBox3.Text = Winner(marker);
                    break;
                case 4:
                    textBox4.Text = Winner(marker);
                    break;
                case 5:
                    textBox5.Text = Winner(marker);
                    break;
            }

            label1.Text = @"Last winner: " + Winner(marker);
            if (_round != 5) return;
            _round = 0;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
        }
    }
}
