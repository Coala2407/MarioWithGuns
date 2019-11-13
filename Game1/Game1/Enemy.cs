using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private Entity currentPlatform;

        public Enemy()
        { }

        public Enemy(Vector2 position)
        {
            this.position = position;
            this.position.Y -= 79; /*Adjust for sprite height, so it's the feet at this position*/
            drawLayer = 0.7f;
        }

        public Enemy(Texture2D sprite, Vector2 position)
        {
            this.position = position;
            this.position.Y -= 79; /*Adjust for sprite height, so it's the feet at this position*/
            this.sprite = sprite;
            drawLayer = 0.7f;
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
            if (currentPlatform != null)
            {
                if (GetCollisionBox.Left > platform.GetCollisionBox.Left && !movingRight)
                {
                    velocity.X = -1;
                    sprite = sprites[0];
                }
                else if (GetCollisionBox.Right < platform.GetCollisionBox.Right)
                {
                    movingRight = true;
                    velocity.X = +1;
                    sprite = sprites[1];
                }
                else
                {
                    movingRight = false;
                    velocity.X = 0;
                }
            }

            //Move enemy to the top of the platform
            if (collisionBox.Bottom - platformCollisionBox.Top > 1)
            {
                position.Y -= 1;
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
                //Remvoe bullet/laser
                GameWorld.RemoveEntity(otherEntity);
                //Enemy dies
                Die();
            }

            if (otherEntity is Platform)
            {
                currentPlatform = otherEntity;
                velocity.Y = 0;
                CalculateNextMove(otherEntity);
            }
        }

        public override void CheckCollision(Entity otherEntity)
        {
            if (GetCollisionBox.Intersects(otherEntity.GetCollisionBox))
            {
                OnCollision(otherEntity);
            }
            else if (currentPlatform == null)
            {
                velocity.Y = +10;
                velocity.X = 0;
            }
            else if (currentPlatform != null && currentPlatform == otherEntity)
            {
                currentPlatform = null;
            }
        }

        /// <summary>
        /// Enemy dies
        /// </summary>
        public override void Die()
        {
            //Teleport enemy to top
            position.Y = -sprite.Height;
            position.X = RandomInteger(0, GameWorld.Width - sprite.Width);
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[2];
            sprites[0] = content.Load<Texture2D>("Cray");
            sprites[1] = content.Load<Texture2D>("CrayFlipped");
            sprite = sprites[0];
        }

        // Random number
        private RNGCryptoServiceProvider Rand =
            new RNGCryptoServiceProvider();

        // Random number between 2 values
        private int RandomInteger(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }
            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }
    }
}
