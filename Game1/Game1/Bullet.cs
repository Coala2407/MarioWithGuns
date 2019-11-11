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
    class Bullet : Entity
    {
        private Vector2 targetCoords;
        private float speed;
        private bool canShoot = true;
        private float shootDelay = 250;
        private float timeElapsed;

        private Vector2 movement = Player.CrosshairPosition - Player.PlayerPosition;


        public Bullet(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = Player.PlayerPosition;
            this.targetCoords = Player.CrosshairPosition;
        }

        protected void CalculateAngle(int posX1, int posY1, int posX2, int posY2, out double m, out double angleRad)
        {
            double posX1D = (double)posX1;
            double posX2D = (double)posX2;
            double posY1D = (double)posY1;
            double posY2D = (double)posY2;

            //Checks if coords are valid (no division by 0...)
            if (posX1 != posX2 && posY1 != posY2 || (posY2 - posY1 != 0) || (posX2 - posX1) != 0)
            {
                m = (posY2D - posY1D) / (posX2D - posX1D);
            }
            else
            {
                m = 0;
            }

            angleRad = Math.Atan(m);
            double rad = 0;

            //Calculate quadrant in correlation to player point
            if ((posX2 > posX1 && posY2 > posY1) || (posX2 > posX1 && posY2 < posY1))
            {
                rad = 0;
            }

            else
            {
                rad = 3.1415926536;
            }

            angleRad = angleRad + rad;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Laser");
        }


        public override void Update(GameTime gameTime)
        {
            speed = 5;

            float slope = 0;
            double slopeV;
            double angleRadians;

            int xPlayer = (int)Player.PlayerPosition.X;
            int yPlayer = (int)Player.PlayerPosition.Y;
            int xCrosshair = (int)targetCoords.X;
            int yCrosshair = (int)targetCoords.Y;

            CalculateAngle(xPlayer, yPlayer, xCrosshair, yCrosshair, out slopeV, out angleRadians);
            float angleRadiansF = (float)angleRadians;
            slope = (float)slopeV;

            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }

            Player.CrosshairPosition += movement * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        /// <summary>
        /// This is where it checks to see if it collides with anything
        /// in the gameworld..
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(Entity otherEntity)
        {

        }

        public override void Shoot()
        {
            if (canShoot == true)
            {
                GameWorld.Instantiate(new Bullet(sprite, position));
                /*
                while (canShoot == true)
                {
                    //BRUG DETTE TIL BULLET OG GANG DET MED VINKLEN :DDDDDDDD
                    position.X = position.X + 2;
                    //position.Y = position.Y - 3;
                    //targetCoords = movement;

                }
                canShoot = false;
                */
            }


        }

        public void ShootTimer(GameTime gameTime)
        {

            timeElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (shootDelay <= timeElapsed)
            {
                canShoot = true;
                timeElapsed = 0;
            }
            else
            {
                canShoot = false;
            }
        }

        private void HandleInput(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Pressed)
            {
                canShoot = true;
                Shoot();
            }
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }


        public override void Draw(SpriteBatch spriteBatch)
        {          
            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, 10f);
        }
    }
}
