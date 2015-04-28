namespace FightGame
{
    //this class represent team
    //you can use it if you want, but I would not
    internal class Team
    {
        //array of players
        private static readonly Player[] TeamPlayers = new Player[5];

        //construct from another array
        public Team(Player[] teamPlayers)
        {
            for (int i = 0; i < 5; i++)
            {
                TeamPlayers[i] = new Player(teamPlayers[i]);
            }
        }

        //default empty constructor
        public Team()
        {
            for (int i = 0; i < 5; i++)
            {
                TeamPlayers[i] = new Player();
            }
        }

        //count general stats of all players
        public double GetTeamPower()
        {
            double power = 0;
            for (int i = 0; i < 5; i++)
            {
                power += TeamPlayers[i].GetPlayerMight();
            }

            return power;
        }

        //change fortune for every player if team wins
        public void TeamIsWinner(bool trophy)
        {
            if (trophy)
            {
                for (int i = 0; i < 5; i++)
                    TeamPlayers[i].PlayerIsWinner();
            }
        }
    }
}
