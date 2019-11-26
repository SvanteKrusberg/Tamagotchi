﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Pokemon
    {
        public string name;
        public int base_experience;
        public TypeSlot[] types;

        public string Types
        {
            get
            {
                string s = "";
                for (int i = 0; i < types.Length; i++)
                {
                    s += types[i].type.name + " ";
                }

                return s;
            }
            set
            {


            }

        }

        public void PrintTypes()
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].type.name);
            }

        }


    }
}