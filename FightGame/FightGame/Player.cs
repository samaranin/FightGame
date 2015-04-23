namespace FightGame
{
    class Player
    {
        private string Name;
        private int ID;
        private int Strength;
        private int Agility;
        private int Intellect;
        private double Endurance;
        private int Clothes;
        private int Weapon;
        private double _fortune;


        public Player(string name, int id, int str, int agl, int intel, double end, int cloth, int wpn, double ftn)
        {
            Name = name;
            ID = id;
            Strength = str;
            Intellect = intel;
            Agility = agl;
            Endurance = end;
            Clothes = cloth;
            Weapon = wpn;
            _fortune = ftn;
        }

        protected Player()
        {
            throw new System.NotImplementedException();
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public int GetPlayerId()
        {
            return ID;
        }

        public int GetPlayerStrength()
        {
            return Strength;
        }

        public int GetPlayerAgility()
        {
            return Agility;
        }

        public int GetPlayerIntellect()
        {
            return Intellect;
        }

        public double GetPlayerEndurance()
        {
            return Endurance;
        }

        public int GetPlayerClothes()
        {
            return Clothes;
        }

        public int GetPlayerWeapon()
        {
            return Weapon;
        }

        public double GetPlayerFortune()
        {
            return _fortune;
        }

        public double GetPlayerMight()
        {
            return ( ( (Strength + Agility + Intellect)*Endurance ) + Clothes + Weapon )*_fortune;
        }

        public void PlayerIsWinner()
        {
            _fortune += 0.1;
        }

        public void PlayerIsLoser()
        {
            _fortune -= 0.1;
        }
    }
}
