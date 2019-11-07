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
        private const float maxJumpTime = .5f;
        private float jumpTime;
        /// <summary>
        /// Sets the strength of gravity for the player (field of class Player, type: int)
        /// </summary>
        private float gravity;

        /// <summary>
        /// Set to true when the player holds down the jump key
        /// </summary>
        private bool isJumping;
        /// <summary>
        /// Set to true when the player has just jumped. Forces the player to press the jump key again
        /// </summary>
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
                //Starts jump timer to allow jumps
                if ((!wasJumping && position.Y == 300) || jumpTime > 0.0f)
                {
                    jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                //Jump. Stay within max jump time. Jump physics below
                if (jumpTime > 0.0f && jumpTime <= maxJumpTime)
                {
                    velocityY = -2f * (1 - (float)Math.Pow(jumpTime / maxJumpTime, .33f));
                }
                //Reached the top of jump.
                else
                {
                    jumpTime = 0.0f;
                }
            }
            //Isn't jumping
            else
            {
                jumpTime = 0.0f;
            }

            wasJumping = isJumping;

            return velocityY;
        }

        private void ApplyPhysics(GameTime gameTime)
        {
            //Get inputs
            HandleInput(gameTime);

            //Temp gravity, replace with an isOnGround method?
            if (position.Y < 300)
            {
                velocity.Y = gravity;
            }
            if (position.Y > 300)
            {
                position.Y = 300;
            }

            //Update y velocity value for potential jumps
            velocity.Y = Jump(velocity.Y, gameTime);

            //Move
            Move(gameTime);

            //Reset jumps
            isJumping = false;
        }

        public override void Update(GameTime gameTime)
        {
            ApplyPhysics(gameTime);
        }
        /// <summary>
        /// Method to collect user input, used for movement and shooting
        /// </summary>
        /// <param name="gameTime"></param>
        private void HandleInput(GameTime gameTime)
        {
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
                //Jump
                isJumping = true;
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
