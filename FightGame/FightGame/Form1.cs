using System;
using System.Linq;
using System.Windows.Forms;

namespace FightGame
{
    //THIS IS OUR MAIN MODULE, SO READ CAREFULLY 
    public partial class Form1 : Form
    {
        //private Team _team1 = new Team();
        //private Team _team2 = new Team();

        //two teams
        readonly Player[] _team1Players = new Player[5];
        readonly Player[] _team2Players = new Player[5];

        //arrays of labels to show info
        readonly Label[] _secondTeamNames = new Label[5];
        readonly Label[] _firstTeamNames = new Label[5];
        readonly Label[] _firstTeam = new Label[5];
        readonly Label[] _secondTeam = new Label[5];

        //number of round
        private int _round;

        public Form1()
        {
            InitializeComponent();
        }

        //create our teams
        private void CreateTeams()
        {  
            //get random array with players id
            const int arrayLength = 10;
            const int maxRandomNum = 20; 
            var rand = new Random(unchecked((int)(DateTime.Now.Ticks)));
            var id = Enumerable.Range(1, maxRandomNum).OrderBy(i => rand.Next()).Take(arrayLength).ToArray();

            //create first team from data base
            for (var j = 0; j < 5; j++)
            {
                var constructor = new DatabasePlayerConstructor(id[j]);
                _team1Players[j] = new Player(constructor);
            }

            //and the same for second
            for (var j = 5; j < 10; j++)
            {
                var constructor = new DatabasePlayerConstructor(id[j]);
                _team2Players[j - 5] = new Player(constructor);
            }

        }

        //show info on form
        private void FillInfo()
        {
            
            //labels for first team player's names
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

            //labels for second team player's names
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

            // labels for first team stats
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

            // labels for second team stats
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

        //delete previous labels with info and clear groupboxes
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

        //show winner
        private static string Winner(bool marker)
        {
            return marker ? "Team 1 wins!!!" : "Team 2 wins!!!";
        }

<<<<<<< HEAD
        //change fortune to winner (look Player.cs and FortuneChanger.cs)
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
        private void TeamIsWinner(bool marker)
        {
            if (marker)
            {
                for (var i = 0; i < 5; i++)
                {
                    _team1Players[i].PlayerIsWinner();
                    FortuneChanger.ChangeFortune(_team1Players[i]);
                }
            }
            else
            {
                for (var i = 0; i < 5; i++)
                {
                    _team2Players[i].PlayerIsWinner();
                    FortuneChanger.ChangeFortune(_team2Players[i]);
                }
            }
        }

<<<<<<< HEAD
        //fill groupboxes
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
        private void button1_Click(object sender, EventArgs e)
        {
            ClearWindow();
            CreateTeams();
            FillInfo();
        }

        //dont use this method
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //FIGHT button
        private void button2_Click(object sender, EventArgs e)
        {
            //_team1 = new Team(_team1Players);
            //_team2 = new Team(_team2Players);

            //set new round
            _round++;

            //count team stats
            double team1Power = 0;
            double team2Power = 0;
            for (var i = 0; i < 5; i++)
            {
                team1Power += _team1Players[i].GetPlayerMight();
                team2Power += _team2Players[i].GetPlayerMight();
            }

            //find winner (look up)
            var marker = team1Power >= team2Power;

            //fill winner field
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
            TeamIsWinner(marker);

            //change fortune (look up)
            TeamIsWinner(marker);

            //show last winner
            label1.Text = @"Last winner: " + Winner(marker);

            if (_round != 5) return;
<<<<<<< HEAD
            //if was 5 rounds reset fortune stats
=======
>>>>>>> b789f308a943844a24df9d19ea24370a8daed87e
            FortuneChanger.ResetFortune();
            _round = 0;
            //clear textboxes
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
        }
    }
}
