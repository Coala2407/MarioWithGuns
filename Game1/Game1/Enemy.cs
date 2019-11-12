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
    class Enemy : Entity
    {
        //No fields


        public Enemy()
        { }

        public Enemy(Vector2 position)
        {
            this.position = position;
        }

        public Enemy(Texture2D sprite, Vector2 position)
        {
            this.position = position;
            this.sprite = sprite;
        }

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
            if (otherEntity is Bullet)
            {
                Die();
            }
        }

        /// <summary>
        /// Player dies
        /// </summary>
        public override void Die()
        {
            GameWorld.RemoveEntity(this);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Cray");
        }
    }
}
