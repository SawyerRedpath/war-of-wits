using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_combat.Classes.Weapons
{
    /// <summary>
    /// A ranged weapon.
    /// </summary>
    public class RangedWeapon : Weapon
    {
        public RangedWeapon(string name, DamageType damageType, int numberOfDie, int numberOfFaces, int startingAmmunition) 
            : base(name, damageType, numberOfDie, numberOfFaces)
        {
            Ammunition = startingAmmunition;
        }

        /// <summary>
        /// Determines how much ammunition remains.
        /// </summary>
        public int Ammunition { get; private set; }


        public override int DealDamage()
        {
            if (Ammunition > 0)
            {
                Ammunition--;
                return base.DealDamage();
            }
            else
            {
                Ammunition = 0;
                return 0;
            }
        }
    }
}
