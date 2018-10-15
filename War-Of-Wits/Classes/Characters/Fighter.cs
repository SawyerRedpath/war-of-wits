using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_combat.Classes.Weapons;

namespace csharp_combat.Classes.Characters
{
    /// <summary>
    /// Creates a new fighter
    /// </summary>
    public class Fighter : Combatant
    {
        const int StartingHealth = 80;


        // Creates a new fighter where you can specify the name
        // but calls the base constructor with a value of 100 for health.
        public Fighter(string name) 
            : base(name, StartingHealth)
        {
        }


        public override int DamageModifier { get { return 3; } }

        /// <summary>
        /// Determines how a fighter takes damage
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damageType"></param>
        /// <returns></returns>
        protected override int CalculateTakenDamage(int damage, DamageType damageType)
        {
            int totalDamage = damage;

            if (damageType == DamageType.Cold)
            {
                totalDamage *= 2;
            }

            return totalDamage;
        }
    }
}
