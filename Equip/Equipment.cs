using HwCreateGame.Equip.Interface;

namespace HwCreateGame.Equip
{
    class Equipment : IStats
    {
        public string Name { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }

        public Equipment(string name, int attackBonus)
        {
            Name = name;
            AttackBonus = attackBonus;
            DefenseBonus = new Random().Next(5, 10);
        }
    }
}