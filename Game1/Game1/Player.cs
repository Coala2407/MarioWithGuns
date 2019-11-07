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
        private const float maxJumpTime = 1f;
        private float jumpTime;
        /// <summary>
        /// Sets the strength of gravity for the player (field of class Player, type: int)
        /// </summary>
        private float gravity;

        private float timer;

        private bool isJumping;
        private bool wasJumping;

        public Player()
        {
            position = new Vector2(500, 300);
            gravity = 1f;
            jumpCooldown = 1;
            moveSpeed = 500;
            drawLayer = 0.0F;
        }

        /// <summary>
        /// WIP
        /// Method used to perform a jump for the player (method of class Player, no inputs or outputs)
        /// </summary>
        private float Jump(float velocityY, GameTime gameTime)
        {
            if (isJumping)
            {
                //Replace postion == 300 with isOnGround method?
                if ((!wasJumping && position.Y == 300) || jumpTime > 0.0f)
                {
                    jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (0.0f < jumpTime && jumpTime <= maxJumpTime)
                {
                    velocityY = -0.75f * (1 - (float)Math.Pow(jumpTime / maxJumpTime, 0.33));
                }

                else
                {
                    jumpTime = 0.0f;
                    timer = 0;
                }
            }
            else
            {
                jumpTime = 0.0f;
            }

            wasJumping = isJumping;

            return velocityY;
        }

        private void ApplyPhysics(GameTime gameTime)
        {
            HandleInput(gameTime);
            if (position.Y < 300)
            {
                velocity.Y = gravity;
            }
            if (position.Y > 300)
            {
                position.Y = 300;
            }

            //Update y value for potential jumps
            velocity.Y = Jump(velocity.Y, gameTime);

            Move(gameTime);

            isJumping = false;
        }

        public override void Update(GameTime gameTime)
        {
            ApplyPhysics(gameTime);

            isJumping = false;
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
                //if (timer > jumpCooldown)
                //{
                    isJumping = true;
                //}
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
