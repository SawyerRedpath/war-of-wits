using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_combat.Classes.Weapons;

namespace csharp_combat.Classes.Characters
{
    public class Rogue : Combatant
    {
        const int StartingHealth = 70;

        /// <summary>
        /// Creates a new rogue.
        /// </summary>
        /// <param name="name"></param>
        public Rogue(string name) : base(name, StartingHealth)
        {
        }


        public override int DamageModifier
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Calculuates the damage taken for a rogue.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damageType"></param>
        /// <returns></returns>
        protected override int CalculateTakenDamage(int damage, DamageType damageType)
        {
            if (damage > 20)
            {
                return 0;
            }
            else
            {
                return damage / 2;
            }
        }
    }
}
