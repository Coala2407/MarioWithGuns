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
        //Fields
        private bool movingRight;
        private float time;

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

        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Move(gameTime);
        }

        /// <summary>
        /// Method for checking the ground beneath and next to
        /// an enemy so it doesn't walk off a ledge or into a wall
        /// </summary>
        private void CalculateNextMove(Entity platform)
        {
            Rectangle collisionBox = GetCollisionBox;
            Rectangle platformCollisionBox = platform.GetCollisionBox;
            if (GetCollisionBox.Left > platform.GetCollisionBox.Left && !movingRight)
            {
                velocity.X = -1;
            }
            else if (GetCollisionBox.Right < platform.GetCollisionBox.Right)
            {
                movingRight = true;

                velocity.X = +1;
            }
            else
            {
                movingRight = false;
            }
        }

        /// <summary>
        /// Spawn bullet and shoot
        /// </summary>
        public override void Shoot()
        {

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

            if (otherEntity is Platform)
            {
                CalculateNextMove(otherEntity);
            }
        }

        public override void CheckCollision(Entity otherEntity)
        {
            if (GetCollisionBox.Intersects(otherEntity.GetCollisionBox))
            {
                OnCollision(otherEntity);
            }
        }

        /// <summary>
        /// Enemy dies
        /// </summary>
        public override void Die()
        {
            //Random rnd = new Random();
            //position.X = rnd.Next(0, 1840);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Cray");
        }
    }
}
