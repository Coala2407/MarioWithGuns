using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    abstract class Entity : GameObject
    {
        //Fields
        private Vector2 velocity;
        private float moveSpeed;
        private float shootCooldown;
        private int health;

        //From GameObject:
        public override void LoadContent(ContentManager content)
        {}

        public override void Update(GameTime gameTime)
        {}
         
        /// <summary>
        /// Shoot a bullet
        /// </summary>
        public abstract void Shoot();

        /// <summary>
        /// Runs on collision with another entity
        /// </summary>
        public abstract void OnCollision();

        /// <summary>
        /// Removes entity
        /// </summary>
        public abstract void Die();

        /// <summary>
        /// Move entity
        /// </summary>
        public virtual void Move()
        {}

        /// <summary>
        /// Get/make a collision box for the entity
        /// </summary>
        public virtual Rectangle GetCollisionBox
        {
            get
            {
                return new Rectangle();
            }
        }

        //Checks for collision with another entity
        public void CheckCollision(Entity otherEntity)
        {}

        /// <summary>
        /// Updates the health of the entity
        /// </summary>
        /// <returns>The the new health value</returns>
        protected int UpdateHealth()
        {
            return health;
        }
    }
}
