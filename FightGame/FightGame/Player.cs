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


        public Player(DatabasePlayerConstructor constructor)
        {
            Name        =   constructor.GetPlayerName();
            ID          =   constructor.GetPlayerId();
            Strength    =   constructor.GetPlayerStrength();
            Intellect   =   constructor.GetPlayerIntellect();
            Agility     =   constructor.GetPlayerAgility();
            Endurance   =   constructor.GetPlayerEndurance();
            Clothes     =   constructor.GetPlayerClothes();
            Weapon      =   constructor.GetPlayerWeapon();
            _fortune    =   constructor.GetPlayerFortune();
        }

        public Player()
        {
            Name = "";
            ID = 0;
            Strength = 0;
            Intellect = 0;
            Agility = 0;
            Endurance = 0;
            Clothes = 0;
            Weapon = 0;
            _fortune = 0;
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
