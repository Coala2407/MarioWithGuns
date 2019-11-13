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
        /// <summary>
        /// Flying speed of the bullet
        /// </summary>
        private float speed = 1400;

        // Converts the position of the player and crosshair to int values (used for calculating the angle between them)
        private double xPlayer = (double)Player.PlayerPosition.X;
        private double yPlayer = (double)Player.PlayerPosition.Y;
        private double xCrosshair = (double)Crosshair.currentPosition.X;
        private double yCrosshair = (double)Crosshair.currentPosition.Y;
        private Vector2 movement = Crosshair.currentPosition - Player.PlayerPosition;
        
        //Value to store the slope between 2 points in
        private double angleRadians;

        public Bullet(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = Player.PlayerPosition;
            CalculateAngle(xPlayer, yPlayer, xCrosshair, yCrosshair, out angleRadians);
            newRotation = (float)angleRadians;
            drawLayer = 0.8f;
        }

        /// <summary>
        /// Calculates the angle between two Vector2 points and returns the slope and angle in rad
        /// </summary>
        /// <param name="posX1"></param>
        /// <param name="posY1"></param>
        /// <param name="posX2"></param>
        /// <param name="posY2"></param>
        /// <param name="m"></param>
        /// <param name="angleRad"></param>
        protected void CalculateAngle(double posX1, double posY1, double posX2, double posY2, out double angleRad)
        {
            double slope = 0;

            //Checks if coords are valid (to avoid division by 0)
            if (posX1 != posX2 && posY1 != posY2 || (posY2 - posY1 != 0) || (posX2 - posX1) != 0)
            {
                slope = (posY2 - posY1) / (posX2 - posX1);
            }
            angleRad = Math.Atan(slope);
            double rad = 0;

            //Calculates which quadrant the crosshair is in, in correlation to the player's coordinates & sets the angle to go
            //directly from the player origin to the crosshair origin
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
            //Normalizes movement of the bullet, ensuring it moves in one direction
            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }
            //Gives the bullet movement
            position += movement * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Deletes the bullet the moment its hitbox collides with the edge of the screen
            if (position.Y <= 0 || position.X <= 0 || position.Y >= GameWorld.Height || position.X >= GameWorld.Width)
            {
                GameWorld.RemoveEntity(this);
            }
        }

        public override void OnCollision(Entity otherEntity)
        {
        }

        public override void Shoot()
        {
        }

        public override void Die()
        {
        }
    }
}
