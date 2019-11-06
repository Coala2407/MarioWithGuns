using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Player : Entity
    {
        /// <summary>
        /// Interval between jumps (field of class Player, type: int)
        /// </summary>
        private float jumpCooldown;
        private const float maxJumpTime = 2f;
        private float jumpTime;
        /// <summary>
        /// Sets the strength of gravity for the player (field of class Player, type: int)
        /// </summary>
        private int gravity;

        private float timer;

        private float jumpSpeed;

        public Player()
        {
            position = new Vector2(500, 300);
            gravity = 50;
            jumpCooldown = 1;
            moveSpeed = 500;
            jumpSpeed = 100;
        }

        /// <summary>
        /// Method used to perform a jump for the player (method of class Player, no inputs or outputs)
        /// </summary>
        public void Jump(GameTime gameTime)
        {
            Vector2 currentPostion = position;
            jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (jumpTime < maxJumpTime)
            {
                velocity.Y -= 1;
            }
        }
        

        public override void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            Move(gameTime);
        }
        /// <summary>
        /// Method to collect user input, used for movement and shooting
        /// </summary>
        /// <param name="gameTime"></param>
        private void HandleInput(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Stop moving when you stop pressing a key
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity.X += 1;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                velocity.X -= 1;
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                if (timer > jumpCooldown)
                {
                    Jump(gameTime);
                    timer = 0;
                }
            }

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
