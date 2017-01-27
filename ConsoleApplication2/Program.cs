using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Program
    {
        //strings
        public static string gender;
        public static string race;
        public static string class1;

        //integers
        //while loop int
        public static int correct = 0;

        //attack integers
        public static int player_arcane_magic = 0;
        public static int player_light_magic = 0;
        public static int player_dark_magic = 0;
        public static int player_rage_magic = 0;
        public static int player_holy_magic = 0;

        //General stats
        public static int stamina = 5;        //Life, 2 extra health pr. point 5 is default
        public static int intellect = 0;      //Magic power 2 ekstra skade pr. point
        public static int strength = 0;       //Atk power
        public static int energy = 0;         //Warrior atk bar 3 extra energy pr. point 5 is default
        public static int mana = 0;           //Atk bar for everything else 3 extra mana pr. point, 5 is default
        public static int health = stamina * 2;
        public static int RealMana = mana * 3;


        public static void Main(string[] args)
        {


            //Gender Creation:
            Console.WriteLine("Please choose a gender");
            Console.WriteLine("Male/Female");
            gender = Console.ReadLine().ToUpper();
            do
            {
                if (gender == "MALE" || gender == "FEMALE")
                {
                    correct = 1;
                }
                else
                {
                    Console.WriteLine("Please choose a listed gender");
                    gender = Console.ReadLine().ToUpper();
                }
            } while (correct == 0);
            correct = 0;
           
            
            // Race Creation:
            Console.Clear();
            Console.WriteLine("Please choose a race listed below");
            Console.WriteLine("Dwarf");
            Console.WriteLine("Human");
            Console.WriteLine("Elf");
            race = Console.ReadLine().ToUpper();
            while (correct == 0)
            {
                if (race == "DWARF" || race == "ELF" || race == "HUMAN")
                {
                    correct = 1;
                }
                else
                {
                    Console.WriteLine("Please choose a race (Dwarf, Elf or Human)");
                    race = Console.ReadLine().ToUpper();
                }
            }

            correct = 0;
           
            
            
            // Class creation
            Console.Clear();
            Console.WriteLine("Please choose a class listed below");
            Console.WriteLine("Warrior");
            Console.WriteLine("Paladin");
            Console.WriteLine("Mage");
            Console.WriteLine("Priest");
            Console.WriteLine("Warlock");
            class1 = Console.ReadLine().ToUpper();
            while (correct == 0)
            {
                if (class1 == "WARRIOR" || class1 == "PALADIN" || class1 == "MAGE" || class1 == "PRIEST" || class1 == "WARLOCK")
                {
                    correct = 1;
                }
                else
                {
                    Console.WriteLine("Please choose a class listed");
                    class1 = Console.ReadLine().ToUpper();
                }
            }
            // Race stat allocation
            if (race == "ELF")                  //Has magic affinity gets 1 extra intellect and 1 extra mana point
            {
                intellect = intellect++;
                mana = mana++;

            }
            if (race == "DWARF")                //Has melee affinity    gets 1 extra strength and 1 extra stamina
            {
                strength = strength + 1;
                stamina = stamina + 1;
            }
            if (race == "HUMAN")                //Magic and melee affinity gets 1 extra strength and 1 extra intellect 
            {       
                strength = strength++;
                intellect = intellect++;

            }

            //Class stat allocation
            if (class1 == "PRIEST")
            {
                player_light_magic = player_light_magic + 2;
                mana = mana +6;
                intellect = intellect + 2;
                 
            }
            if (class1 == "PALADIN")
            {
                player_light_magic++;
                intellect = intellect++;
                mana = mana + 5;
                stamina = stamina++;
                strength = strength++;
                intellect = intellect++;
            }
            if (class1 == "WARRIOR")
            {
                energy = energy + 5;
                strength = strength + 2;
                stamina = stamina++;
            }
            if (class1 == "MAGE")
            {
                player_arcane_magic = player_arcane_magic + 2;
                mana = mana + 6;
                intellect = intellect + 2;

            }
            if (class1 == "WARLOCK")
            {
                player_dark_magic = player_dark_magic + 2;
                mana = mana + 6;
                intellect = intellect + 2;

            }
            correct = 0;

            // Movement and world
            Console.WriteLine("Gamchini (movement N/S/E/W)");
            int x = 0;
            int y = 0;

            string Userinput = Console.ReadLine().ToUpper();

            while (correct == 0)
            {

                if (Userinput == "N")
                {
                    y++;
                }
                else if (Userinput == "S")
                {
                    y--;
                }
                else if (Userinput == "E")
                {
                    x++;
                }
                else if (Userinput == "W")
                {
                    x--;
                }
                else
                {
                }

                if (x == 0 && y == 0)
                {
                    Console.WriteLine("Ganchen");
                    Userinput = Console.ReadLine().ToUpper();

                }
                else if (x == 1 && y == 0)
                {
                    Console.WriteLine("Fork");
                    Userinput = Console.ReadLine().ToUpper();
                }
                else if (x == 1 && y == 1 || x == 1 && y == -1)
                {
                    Console.WriteLine("Dead end");
                    Userinput = Console.ReadLine().ToUpper();
                }
                else
                {
                    Console.WriteLine("You can't go that way!");
                    if (Userinput == "N")
                    {
                        y--;
                        Userinput = Console.ReadLine().ToUpper();
                    }
                    else if (Userinput == "S")
                    {
                        y++;
                        Userinput = Console.ReadLine().ToUpper();
                    }
                    else if (Userinput == "E")
                    {
                        x--;
                        Userinput = Console.ReadLine().ToUpper();
                    }
                    else if (Userinput == "W")
                    {
                        x++;
                        Userinput = Console.ReadLine().ToUpper();
                    }
                    else
                    {

                    }
                }
            }

        }
       
        //combat mechanisms

        public static void OrcCombat()
        {
            Random rnd = new Random();
            int OrcHealth = 20;
            int OrcDamage = rnd.Next(1, 3);
            double dblPlayer_Dark_Damage_Floor = (player_dark_magic + intellect) * 2 * 0.9;
            int intPlayer_Dark_Damage_Ceiling = (player_dark_magic + intellect) * 2;
            int intPlayer_Dark_Damage_Floor = Convert.ToInt32(Math.Round(dblPlayer_Dark_Damage_Floor));
          

            Console.WriteLine("The Orc looks furious. The orc has 20 HP");
            Console.WriteLine("You have " + health + "HP and " + RealMana + "mana");
            string playerchoice = Console.ReadLine().ToUpper();
            if (class1 == "WARLOCK")
            {
                Console.WriteLine("Choose your action:");
                Console.WriteLine("Attack with your dark magic (A)");
                Console.WriteLine("Attack with your weapon (B)");
                playerchoice = Console.ReadLine().ToUpper();
                if (playerchoice == "A")
                {
                }
                
            }

        }
    }
}
