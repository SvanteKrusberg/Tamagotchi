using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using RestSharp;

namespace Tamagotchi
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            RestClient client = new RestClient("https://pokeapi.co/api/v2/");
            string userinput;
            //Skapar en lista med currys, där alla currys som spelaren skapar ska lagras
            List<Curry> currys;
            //Skapar tamagotchi instansen
            Tamagotchi tamagotchi1 = new Tamagotchi();
            Console.WriteLine("Welcome to Pokemon x Tamagotchi 2019! " +
                "Which starter do you want?");

            Console.WriteLine("A: Chikorita");
            Console.WriteLine("B: Cyndaquil");
            Console.WriteLine("C: Totodile");

            //Bestämmer att så länge tamagotchin inte fått sin namn så körs loopen
            tamagotchi1.name = "none";
            while (tamagotchi1.name == "none")
            {
                userinput = Console.ReadLine();
                userinput = userinput.ToLower();

                if (userinput == "a")
                {
                    //Requestar en pokemon beroende på användarens val av pokemon, med detta bestäms namnet på
                    // tamagotchin
                    RestRequest request = new RestRequest("pokemon/chikorita");
                    IRestResponse response = client.Get(request);
                    Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    tamagotchi1.name = p.name;
                    tamagotchi1.requiredExp = p.base_experience;
                    
                }
                else if (userinput == "b")
                {

                    RestRequest request = new RestRequest("pokemon/cyndaquil");
                    IRestResponse response = client.Get(request);
                    Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    tamagotchi1.name = p.name;
                    tamagotchi1.requiredExp = p.base_experience;

                }
                else if (userinput == "c")
                {
                    RestRequest request = new RestRequest("pokemon/totodile");
                    IRestResponse response = client.Get(request);
                    Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
                    tamagotchi1.name = p.name;
                    tamagotchi1.requiredExp = p.base_experience;

                }
                //en else som körs ifall användar inputen inte är något av alternativen
                else
                {
                    Console.WriteLine("Enter a valid input");

                }

            }

            //En kort loadingscreen som körs för att användaren ska se att det händer något och inte blir förvirrad
            //medans requesten görs
            Loading();

            //En loop som körs så länge tamagotchin är vid liv
            while (tamagotchi1.GetAlive() == true)
            {
                Console.WriteLine("What would you like to do?");
                tamagotchi1.PrintStats();
                Console.WriteLine();

                Console.WriteLine("A: Feed " + tamagotchi1.name);
                Console.WriteLine("B: Train " + tamagotchi1.name);
                Console.WriteLine("C: Cook curry with " + tamagotchi1.name);

                userinput = Console.ReadLine();
                userinput = userinput.ToLower();

                if (userinput == "a")
                {
                    tamagotchi1.Tick();
                    tamagotchi1.Feed();
                    
                }

                else if (userinput == "b")
                {
                    tamagotchi1.Tick();
                    tamagotchi1.Train();
                    if(true)
                    {
                        tamagotchi1.LevelUp();

                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Press enter to continue:");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ReadLine();
                    Console.Clear();

                }

                else if (userinput == "c")
                {
                    Console.WriteLine("What should the main ingredient be?");
                    string ingredient = Console.ReadLine();
                    tamagotchi1.Tick();
                    tamagotchi1.CookCurry(ingredient);
                    
                }

                else
                {
                    Console.WriteLine("Please enter a valid action!");

                }

            }

            Gameover();

        }

        //En enkel gamover metod som körs när spelet är över
        public static void Gameover()
        {

            Console.Clear();
            Console.WriteLine("Game over");
            Console.ReadLine();

        }

        //En enkel loadingscreen
        public static void Loading()
        {
            Console.Clear();
            Console.WriteLine("Loading");
            Console.Write(". ");
            Thread.Sleep(300);
            Console.Write(". ");
            Thread.Sleep(300);
            Console.Write(". ");
            Thread.Sleep(300);
            Console.Clear();

        }

    }
}
