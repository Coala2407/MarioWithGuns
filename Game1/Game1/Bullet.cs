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
    class Bullet : Entity
    {
        private Vector2 targetCoords;
        /// <summary>
        /// This is the constructor for the bullet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public Bullet(Texture2D sprite, Vector2 position)
        {



        }

        /// <summary>
        /// WIP >:(
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {

        }
        /// <summary>
        /// This is where the movment and collision is calculated and used..
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
        }
        /// <summary>
        /// This is where it checks to see if it collides with anything
        /// in the gameworld..
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject otherEntity)
        {

        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }
    }
}



