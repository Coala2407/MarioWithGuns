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
        private const float maxJumpTime = .5f;
        private float jumpTime;
        /// <summary>
        /// Sets the strength of gravity for the player (field of class Player, type: int)
        /// </summary>
        private float gravity;
        private float timeFalling;
        private Texture2D bulletSprite;

        private bool canShoot = true;
        private float shootDelay = 750f;
        private float timeElapsed;

        /// <summary>
        /// Set to true when the player holds down the jump key
        /// </summary>
        private bool isJumping;
        /// <summary>
        /// Set to true when the player has just jumped. Forces the player to press the jump key again
        /// </summary>
        private bool wasJumping;

        private bool isOnGround;

        //Player position
        public static Vector2 PlayerPosition;

        //Used to check which platform the player is on
        private Entity currentPlatform;

        public Player()
        {
            position = new Vector2(0, 0);
            gravity = 1f;
            moveSpeed = 500;
            drawLayer = 0.9f;
            PlayerPosition = position;
        }

        /// <summary>
        /// Method used to perform a jump for the player (method of class Player, no inputs or outputs)
        /// </summary>
        private float Jump(float velocityY, GameTime gameTime)
        {
            if (isJumping)
            {
                //Starts jump timer to allow jumps
                if ((!wasJumping && isOnGround) || jumpTime > 0.0f)
                {
                    jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                //Jump. Stay within max jump time. Jump physics below
                if (jumpTime > 0.0f && jumpTime <= maxJumpTime)
                {
                    velocityY = -2f * (1 - (float)Math.Pow(jumpTime / maxJumpTime, .66f));
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

            //Reset jumps
            isJumping = false;

            return velocityY;
        }

        private void ApplyPhysics(GameTime gameTime)
        {
            timeFalling += (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 prevPos = position;

            //Get inputs
            HandleInput(gameTime);

            //Gravity
            if (!isOnGround)
            {
                //Acceleration
                velocity.Y += (gravity * timeFalling);
            }
            //Replace with an isOnGround method?
            else
            {
                timeFalling = 0f;
            }

            //Update y velocity value for potential jumps
            velocity.Y = Jump(velocity.Y, gameTime);

            //Move
            Move(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            ShootTimer(gameTime);
            ApplyPhysics(gameTime);
            //Update player position
            PlayerPosition = position;
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

            if (keyState.IsKeyDown(Keys.D) && position.X <= (GameWorld.Width - sprite.Width))
            {
                velocity.X += 1;
            }
            if (keyState.IsKeyDown(Keys.A) && position.X >= 0)
            {
                velocity.X -= 1;
            }

            if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Space))
            {
                //Jump
                isJumping = true;
            }
            MouseState state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Pressed)
            {
                Shoot();
            }

        }

        /// <summary>
        /// Spawn bullet, shoot & start timer to limit amount of bullets
        /// </summary>
        public override void Shoot()
        {
            if (canShoot == true)
            {
                timeElapsed = 0;
                GameWorld.AddEntity(new Bullet(bulletSprite, position));
            }
        }

        /// <summary>
        /// Limits the amount of bullets the player can shoot within a small timeframe
        /// </summary>
        /// <param name="gameTime"></param>
        public void ShootTimer(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (shootDelay <= timeElapsed)
            {
                canShoot = true;
            }
            else
            {
                canShoot = false;
            }
        }

        /// <summary>
        /// Runs on collision with another entity
        /// </summary>
        /// <param name="otherEntity"></param>
        public override void OnCollision(Entity otherEntity)
        {
            if (otherEntity is Platform)
            {
                Rectangle collisionBox = GetCollisionBox;
                Rectangle otherCollisionBox = otherEntity.GetCollisionBox;
                currentPlatform = otherEntity;

                if (collisionBox.Bottom >= otherCollisionBox.Top && /*Player's collision box bottom is below is the same height as the platform top*/
                    (collisionBox.Bottom - otherCollisionBox.Top) < (otherCollisionBox.Height / 2))/*Player's collision box bottom is at least half way to platform top*/
                {
                    //Player is on the ground
                    velocity.Y = 0;
                    isOnGround = true;
                    timeFalling = 0f;

                    //Move player to the top of the platform
                    if (collisionBox.Bottom - otherCollisionBox.Top > 1)
                    {
                        position.Y -= 1;
                    }
                }
                else
                {
                    //Player is not properly on the platform
                    isOnGround = false;
                }
            }
            if (otherEntity is Enemy)
            {
                Die();
            }
        }


        /// <summary>
        /// Player dies
        /// </summary>
        public override void Die()
        {
            position.Y = 0;
            timeFalling = 0;
        }

        /// <summary>
        /// Load content, like sprites, for the player
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("KaliKula");
            //Loads the bullet sprite so that it is ready when we create new bullets
            bulletSprite = content.Load<Texture2D>("Laser");
        }

        public override void CheckCollision(Entity otherEntity)
        {
            if (GetCollisionBox.Intersects(otherEntity.GetCollisionBox))
            {
                OnCollision(otherEntity);
            }
            else if (currentPlatform != null && otherEntity == currentPlatform)
            {
                isOnGround = false;
                currentPlatform = null;
            }
        }
    }
}
