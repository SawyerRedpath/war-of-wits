using csharp_combat.Classes.Characters;
using csharp_combat.Classes.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharp_combat
{
    /* LEAVE THIS CLASS COMMENTED OUT UNTIL THE END*/
    public class FightingRing
    {

        private static List<Weapon> weaponInventory = new List<Weapon>()
        {
            // Simple Melee Weapons
            new Weapon("Club", DamageType.Bludgeon, 1, 4),
            new Weapon("Dagger", DamageType.Pierce, 1, 4),
            new Weapon("Handaxe", DamageType.Slash, 1, 6),

            // Simple Ranged Weapons
            new RangedWeapon("Crossbow", DamageType.Pierce, 1, 8, 50),
            new RangedWeapon("Sling", DamageType.Bludgeon, 1, 4, 20),

            // Magical Weapons
            new Weapon("Frost Sword", DamageType.Cold, 2, 6),
            new Weapon("Master Sword", DamageType.Holy, 2, 10)
        };

        private static List<Combatant> combatants = new List<Combatant>()
        {
            // Fighters
            new Fighter("Bubba the Bruiser"),
            new Fighter("John, the Noble"),

            new Rogue("Fezzik"),
            //new Link(),
        };

        private static string[] descriptions = {
            "Fearless", "Lonesome", "Amazing", "Pathetic", "Courageous"
        };

        private static string[] messages = {
            "Ah! A good choice!",
            "Excellent",
            "Heh heh...I hope you brought help!",
            "The hour of your doom nears...",
            "A pity...They don't stand a chance."
        };

        private const int SleepTime = 2000;


        public void Run()
        {
            Console.Clear();
            PrintGreeting();

            PrintMessage($"Who wishes to fight first?");

            Combatant fighter1 = AskUserForCombatant();
            fighter1.Weapon = AskUserForWeapon();

            Console.WriteLine();
            PrintMessage($"Who dare challenge this {GetRandomString(descriptions).ToLower()} fighter?");
            Console.WriteLine();

            Combatant fighter2 = AskUserForCombatant();
            fighter2.Weapon = AskUserForWeapon();

            Fight(fighter1, fighter2);


        }

        private void Fight(Combatant fighter1, Combatant fighter2)
        {
            Console.WriteLine("The carnage BEGINS!");
            PrintMessage("5..4..3..2..1", 333);

            Console.WriteLine();
            Console.Clear();

            bool autoPlayMode = false;

            while (!fighter1.IsDead && !fighter2.IsDead)
            {

                if (autoPlayMode)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                Console.Clear();

                PlayAttack(fighter1, fighter2);
                Console.WriteLine();

                Thread.Sleep(TimeSpan.FromSeconds(2));

                PlayAttack(fighter2, fighter1);
                Console.WriteLine();

                Console.WriteLine("AFTER THE Round");
                Console.WriteLine("----------");
                Console.WriteLine(fighter1);
                Console.WriteLine();
                Console.WriteLine(fighter2);


                if (!autoPlayMode)
                {
                    autoPlayMode = (Console.ReadKey().Key == ConsoleKey.Escape);
                }
            }
        }

        private void PlayAttack(Combatant attacker, Combatant defender)
        {
            Console.WriteLine($"{attacker.Name} strikes with their {attacker.Weapon.Name}");

            int damageDealt = attacker.DealDamage();

            Console.WriteLine($"{attacker.Name} rolls a hit of {damageDealt} points!");

            int actualDamage = defender.TakeDamage(damageDealt, attacker.Weapon.DamageType);

            if (actualDamage < damageDealt)
            {
                Console.WriteLine($"What moves! {defender.Name} only took {actualDamage} damage.");
            }
            else if (actualDamage > damageDealt)
            {
                Console.WriteLine($"{defender.Name} actually took {actualDamage} damage from that hit!");
            }

        }

        private string GetRandomString(string[] strings)
        {
            Random rng = new Random();
            int index = rng.Next(strings.Length);

            return strings[index];
        }

        private Weapon AskUserForWeapon()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a weapon!!");

                for (int i = 0; i < weaponInventory.Count; i++)
                {
                    Console.WriteLine($" {i}: {weaponInventory[i].Name}");
                }

                Console.Write("What will they fight with? ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice < weaponInventory.Count)
                {
                    Console.WriteLine();
                    PrintMessage(GetRandomString(messages));

                    Weapon selectedWeapon = weaponInventory[choice];
                    weaponInventory.RemoveAt(choice);

                    return selectedWeapon;
                }
                else
                {
                    Console.WriteLine();
                    PrintError("Are you daft? Pick your instrument of destruction!");
                }
            }
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prompts a user for a combatant
        /// </summary>
        /// <returns>A selected combtant</returns>
        private Combatant AskUserForCombatant()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose your champion!!");

                for (int i = 0; i < combatants.Count; i++)
                {
                    Console.WriteLine($" {i}: {combatants[i].Name}");
                }

                Console.Write("Who will you choose? ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice < combatants.Count)
                {
                    Combatant combatant = combatants[choice];
                    combatants.RemoveAt(choice);
                    return combatant;
                }
                else
                {
                    Console.WriteLine();
                    PrintError("What are you? Daft? Pick a fighter!");
                }

            }
        }

        /// <summary>
        /// Prints the greeting message before the fight begins.
        /// </summary>
        private void PrintGreeting()
        {
            Console.WriteLine(@"
            
.------..------..------.        
|W.--. ||A.--. ||R.--. |        
| :/\: || (\/) || :(): |        
| :\/: || :\/: || ()() |        
| '--'W|| '--'A|| '--'R|        
`------'`------'`------'        
.------..------.                
|O.--. ||F.--. |                
| :/\: || :(): |                
| :\/: || ()() |                
| '--'O|| '--'F|                
`------'`------'                
.------..------..------..------.
|W.--. ||I.--. ||T.--. ||S.--. |
| :/\: || (\/) || :/\: || :/\: |
| :\/: || :\/: || (__) || :\/: |
| '--'W|| '--'I|| '--'T|| '--'S|
`------'`------'`------'`------ ");
         
        }

        /// <summary>
        /// Prints a custom message but spells it out letter by letter for dramatic effect.
        /// </summary>
        /// <param name="message"></param>
        private void PrintMessage(string message)
        {
            PrintMessage(message, 25);
        }

        private void PrintMessage(string message, int sleepTime)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(sleepTime);
            }
            Console.Write("\n");
        }
    }
}
