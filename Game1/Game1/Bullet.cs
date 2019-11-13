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
        private float speed = 1400;
        private int xPlayer = (int)Player.PlayerPosition.X;
        private int yPlayer = (int)Player.PlayerPosition.Y;
        private int xCrosshair = (int)Crosshair.currentPosition.X;
        private int yCrosshair = (int)Crosshair.currentPosition.Y;
        private Vector2 movement = Crosshair.currentPosition - Player.PlayerPosition;
        private float slope = 0;
        private double slopeV;
        private double angleRadians;

        public Bullet(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = Player.PlayerPosition;
            CalculateAngle(xPlayer, yPlayer, xCrosshair, yCrosshair, out slopeV, out angleRadians);
            newRotation = (float)angleRadians;
            slope = (float)slopeV;
        }

        protected void CalculateAngle(int posX1, int posY1, int posX2, int posY2, out double m, out double angleRad)
        {
            double posX1D = (double)posX1;
            double posX2D = (double)posX2;
            double posY1D = (double)posY1;
            double posY2D = (double)posY2;

            //Checks if coords are valid (to avoid division by 0)
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

            //Calculate quadrant in correlation to player point & sets the angle to go directly from the player origin to the crosshair origin
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
            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }
            position += movement * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Removes the bullets that leave the screen for better performance
            if (position.Y <= 0 || position.X <= 0 || position.Y >= GameWorld.Height || position.X >= GameWorld.Width)
            {
                GameWorld.RemoveEntity(this);
            }
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
        }
        
        
        
        public override void Die()
        {
            throw new NotImplementedException();
        }
    }
}
