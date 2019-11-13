using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
   public abstract class Entity : GameObject
    {
        //Fields
        protected Vector2 velocity;
        protected float moveSpeed;
        protected float shootCooldown;
        protected int health;

        public Entity()
        {
            health = 100;
            moveSpeed = 100;
            shootCooldown = 0.33F;
        }

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
        public abstract void OnCollision(Entity otherEntity);

        /// <summary>
        /// Removes entity
        /// </summary>
        public abstract void Die();

        /// <summary>
        /// Move entity
        /// </summary>
        public virtual void Move(GameTime gameTime)
        {
            //deltaTime based on gameTime
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Moves the player based on velocity, speed, and deltaTime
            position += ((velocity * moveSpeed) * deltaTime);
        }

        /// <summary>
        /// Get/make a collision box for the entity
        /// </summary>
        public virtual Rectangle GetCollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }

        //Checks for collision with another entity
        public virtual void CheckCollision(Entity otherEntity)
        {
            if (GetCollisionBox.Intersects(otherEntity.GetCollisionBox))
            {
                OnCollision(otherEntity);
            }
        }

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
