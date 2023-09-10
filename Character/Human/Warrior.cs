using HwCreateGame.Character.Interface;
using HwCreateGame.Equip.Interface;

namespace HwCreateGame.Character.Human
{
    class Warrior : Character, IStats, IHealth
    {
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }

        public Warrior(string name) : base("Human", name, 175, 38)
        {
            Health = 120;
            AttackBonus = 5000;
            DefenseBonus = 2500;
        }
    }
}
