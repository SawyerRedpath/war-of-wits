using csharp_combat.Classes.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_combat.Classes.Characters
{
    /// <summary>
    /// A generic combatant
    /// </summary>
    public abstract class Combatant
    {
        /// <summary>
        /// The combatant's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The combatant's health
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Indicates if the combatant is dead.
        /// </summary>
        public bool IsDead
        {
            get
            {
                // return (Health <= 0);

                if (Health <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Creates a new combatant
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        public Combatant(string name, int health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// The combatant's weapon that they carry.
        /// </summary>
        public Weapon Weapon { get; set; }

        /// <summary>
        /// The combatant's damage modifier added after each attack.
        /// </summary>
        public abstract int DamageModifier { get; }


        /// <summary>
        /// Determines how much damage a combatant will deal (using their weapon and modifier) when it is their turn.
        /// </summary>
        /// <returns></returns>
        public int DealDamage()
        {
            return Weapon.DealDamage() + DamageModifier;
        }

        /// <summary>
        /// Forces the subclasses to calculate the final damage that they take.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damageType"></param>
        /// <returns></returns>
        protected abstract int CalculateTakenDamage(int damage, DamageType damageType);


        /// <summary>
        /// Determines how much damage the combatant takes.
        /// </summary>
        /// <param name="damage">The damage roll from the attacker</param>
        /// <param name="damageType">The type of damage the attacker issued.</param>
        /// <returns></returns>
        public int TakeDamage(int damage, DamageType damageType)
        {
            int finalDamage = CalculateTakenDamage(damage, damageType); //call the subclass to determine the actual taken damage
            Health -= finalDamage;

            return finalDamage;
        }

        public override string ToString()
        {
            string output = $"{Name} ({GetType().Name.ToString().ToUpper()}) - {Health}hp\n";
            

            return output;
        }
    }
}
