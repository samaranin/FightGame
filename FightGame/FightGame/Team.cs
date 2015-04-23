namespace FightGame
{
    internal class Team : Player
    {
        private static readonly Player[] TeamPlayers = new Player[5];

        public Team(Player[] teamPlayers)
        {
            for (int i = 0; i < 5; i++)
            {
                TeamPlayers[i] = new Player();
            }

            for (int i = 0; i < 5; i++)
            {
                TeamPlayers[i] = teamPlayers[i];
            }
        }

        public double GetTeamPower()
        {
            double power = 0;
            for (int i = 0; i < 5; i++)
            {
                power += TeamPlayers[i].GetPlayerMight();
            }

            return power;
        }

        public void TeamIsWinner(bool trophy)
        {
            if (trophy)
            {
                for (int i = 0; i < 5; i++)
                    TeamPlayers[i].PlayerIsWinner();
            }
            else
            {
                for (int i = 0; i < 5; i++)
                    TeamPlayers[i].PlayerIsLoser();
            }
        }
    }
}
