using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        public override void OnCollision(GameObject otherEntity)
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

        /// <summary>
        /// Like content, like sprites, for the player
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("KaliKula");
        }
    }
}
