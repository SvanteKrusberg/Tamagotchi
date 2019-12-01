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
        private int rarityDeclaration;

        //Konstruktor som bestämmer rarity och namnet av curryn
        public Curry(string _name)
        {
            //Genererar ett slumpmässigt värde som bestämmer rarity hos curryn
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

            //Gör ett namn på curryn kombinerat med ingrediensen som spelaren väljer
            name = _name + " curry";


        }

        //Returnerar curryns rarity
        public int GetCurryRarity()
        {
            return rarityDeclaration;

        }

        //Returnerar curryns rarity som text i en string
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
            //Ännu en gång en else sats som aldrig ska kunna hända, men skulle det hända så får användaren
            // en trevlig överraskning :)
            else
            {
                return "UltraSuperDuperNotPossibleRarity";

            }


        }

    }

}
