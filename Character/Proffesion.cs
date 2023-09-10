namespace HwCreateGame.Character
{
    class Profession
    {
        public string GetProffesions(string race)
        {
            switch (race)
            {
                case "Human": return "Warrior, Rogue, Knight";
                case "Elf": return "Tank, Scout";
                default: return "unknown race";
            }
            
           
        }
    }
}
