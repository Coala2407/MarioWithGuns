using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Enemy : Entity
    {
        //No fields

        /// <summary>
        /// Method for checking the ground beneath and next to
        /// an enemy so it doesn't walk off a ledge or into a wall
        /// </summary>
        private void CalculateNextMove()
        {

        }

        /// <summary>
        /// Spawn bullet and shoot
        /// </summary>
        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Runs on collision with another entity
        /// </summary>
        /// <param name="otherEntity"></param>
        public override void OnCollision(Entity otherEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Player dies
        /// </summary>
        public override void Die()
        {
            throw new NotImplementedException();
        }
    }
}
