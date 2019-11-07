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
        private Vector2 crosshairPosition;
        /// <summary>
        /// This is the constructor for the bullet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public Bullet(Texture2D sprite, Vector2 position)
        {

            this.sprite = sprite;
            this.position = Player.PlayerPosition;

        }

        protected void CalculateAngle(int posX1, int posY1, int posX2, int posY2, out double m, out double angleDeg, out double angleRad)
        {
            double posX1D = (double)posX1;
            double posX2D = (double)posX2;
            double posY1D = (double)posY1;
            double posY2D = (double)posY2;


            if (posX1 != posX2 && posY1 != posY2 || (posY2 - posY1 != 0) || (posX2 - posX1) != 0)
            {
                m = (posY2D - posY1D) / (posX2D - posX1D);
            }
            else
            {
                m = 0;
            }

            //Angle deci to degrees
            angleRad = Math.Atan(m);

            //string quarter = "";
            int quad = 0;
            double rad = 0;

            //Calculate quadrant in correlation to player point
            if ((posX2 > posX1 && posY2 > posY1) || (posX2 > posX1 && posY2 < posY1))
            {
                //OK
                //quarter = "Bottom Right ++";
                rad = 0;
            }
            else
            {
                rad = 3.1415926536;
            }
            angleRad = angleRad + rad;
            //Returns the degree in double
            angleDeg = ((180 / Math.PI) * angleRad) + quad;
        }

        /// <summary>
        /// WIP >:(
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("KaliKula");
            //sprite = content.Load<Texture2D>("Bullet");
        }
        /// <summary>
        /// This is where the movment and collision is calculated and used..
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            speed = 500;
        }
        /// <summary>
        /// This is where it checks to see if it collides with anything
        /// in the gameworld..
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject otherEntity)
        {

        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        //Reads the current position of the Crosshair
        private void HandleInput(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Pressed)
            {
                crosshairPosition = new Vector2(state.X, state.Y);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

            //HUSK AT KOORDINATSYSTEMET ER PÅ HOVEDET!
            float newAngle = 0;
            float slope = 0;
            double slopeV;
            double angleDegrees;
            double angleRadians;
            int xPlayer = (int)Player.PlayerPosition.X;
            int yPlayer = (int)Player.PlayerPosition.Y;

            int xCrosshair = (int)crosshairPosition.X;
            int yCrosshair = (int)crosshairPosition.Y;

            CalculateAngle(xPlayer, yPlayer, xCrosshair, yCrosshair, out slopeV, out angleDegrees, out angleRadians);
            float angleRadiansF = (float)angleRadians;
            slope = (float)slopeV;
            newAngle = (float)angleDegrees;

            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);




            spriteBatch.Draw(sprite, position, null, Color.White, angleRadiansF, origin, 1, SpriteEffects.None, 10f);
        }
    }
}



