using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Curry
    {
        public string name;
        private string[] rarity = { "Common", "Rare", "Legendary" };
        private int[] foodPoints = { 1, 2, 3 };
        private int rarityDeclaration;

        public Curry(string _name)
        {
            int rarityDecider = Utils.generator.Next(10);

            if (rarityDecider == 0)
            {
                rarityDeclaration = 2;
            }
            else if (rarityDecider < 4 && rarityDecider != 0)
            {
                rarityDeclaration = 1;

            }
            else
            {
                rarityDeclaration = 0;

            }

            name = _name + " curry";


        }

        public int GetCurryRarity()
        {
            return rarityDeclaration;

        }

        public string WriteCurryRarity()
        {
            if (rarity[rarityDeclaration] == "Common")
            {
                return "Common";

            }
            else if (rarity[rarityDeclaration] == "Rare")
            {
                return "Rare";

            }
            else if (rarity[rarityDeclaration] == "Legendary")
            {
                return "Legendary";

            }
            else
            {
                return "UltraSuperDuperNotPossibleRarity";

            }


        }

    }

}
