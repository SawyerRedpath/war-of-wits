using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_combat.Classes.Weapons
{
    public class Weapon
    {
        /// <summary>
        /// The name of the weapon.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The damage type the weapon performs.
        /// </summary>
        public DamageType DamageType { get; }

        /// <summary>
        /// Creates a new weapon.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damageType"></param>
        public Weapon(string name, DamageType damageType, int numberOfDie, int numberOfFaces)
        {
            Name = name;
            DamageType = damageType;

            this.numberOfDie = numberOfDie;
            this.numberOfFaces = numberOfFaces;
        }

        // Private variables that are used for determining the damage
        private int numberOfDie;
        private int numberOfFaces;
        private Random random = new Random();


        /// <summary>
        /// Calculates the damage dealt by the weapon.
        /// </summary>
        /// <returns></returns>
        public virtual int DealDamage()
        {
            int total = 0;

            for(int i = 0; i < numberOfDie; i++)
            {
                int randomNumber = random.Next(1, numberOfFaces + 1);
                total += randomNumber;
            }

            return total;
        }

    }
}
