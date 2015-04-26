namespace FightGame
{
    class Player
    {
        private readonly string _name;
        private readonly int _id;
        private readonly int _strength;
        private readonly int _agility;
        private readonly int _intellect;
        private readonly double _endurance;
        private readonly int _clothes;
        private readonly int _weapon;
        private double _fortune;


        public Player(Player player)
        {
            _name = player.GetPlayerName();
            _id = player.GetPlayerId();
            _strength = player.GetPlayerStrength();
            _intellect = player.GetPlayerIntellect();
            _agility = player.GetPlayerAgility();
            _endurance = player.GetPlayerEndurance();
            _clothes = player.GetPlayerClothes();
            _weapon = player.GetPlayerWeapon();
            _fortune = player.GetPlayerFortune();
        }

        public Player(DatabasePlayerConstructor constructor)
        {
            _name        =   constructor.GetPlayerName();
            _id          =   constructor.GetPlayerId();
            _strength    =   constructor.GetPlayerStrength();
            _intellect   =   constructor.GetPlayerIntellect();
            _agility     =   constructor.GetPlayerAgility();
            _endurance   =   constructor.GetPlayerEndurance();
            _clothes     =   constructor.GetPlayerClothes();
            _weapon      =   constructor.GetPlayerWeapon();
            _fortune    =   constructor.GetPlayerFortune();
        }

        public Player()
        {
            _name = "";
            _id = 0;
            _strength = 0;
            _intellect = 0;
            _agility = 0;
            _endurance = 0;
            _clothes = 0;
            _weapon = 0;
            _fortune = 0;
        }
        
        public string GetPlayerName()
        {
            return _name;
        }

        public int GetPlayerId()
        {
            return _id;
        }

        public int GetPlayerStrength()
        {
            return _strength;
        }

        public int GetPlayerAgility()
        {
            return _agility;
        }

        public int GetPlayerIntellect()
        {
            return _intellect;
        }

        public double GetPlayerEndurance()
        {
            return _endurance;
        }

        public int GetPlayerClothes()
        {
            return _clothes;
        }

        public int GetPlayerWeapon()
        {
            return _weapon;
        }

        public double GetPlayerFortune()
        {
            return _fortune;
        }

        public double GetPlayerMight()
        {
            return ( ( (_strength + _agility + _intellect)*_endurance ) + _clothes + _weapon )*_fortune;
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
