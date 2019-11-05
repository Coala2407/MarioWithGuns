using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class Player : Entity
    {
        /// <summary>
        /// Interval between jumps (field of class Player, type: int)
        /// </summary>
        private float jumpCooldown;
        /// <summary>
        /// Sets the strength of gravity for the player (field of class Player, type: int)
        /// </summary>
        private int gravity;

        /// <summary>
        /// Method used to perform a jump for the player (method of class Player, no inputs or outputs)
        /// </summary>
        private void Jump()
        {

        }
        /// <summary>
        /// Method to collect user input, used for movement and shooting
        /// </summary>
        /// <param name="gameTime"></param>
        private void HandleInput(GameTime gameTime)
        {

        }
    }
}
