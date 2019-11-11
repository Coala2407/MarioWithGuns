using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    public abstract class GameObject
    {
        //Fields
        protected Texture2D sprite;
        protected Texture2D[] sprites;
        protected Vector2 position;
        protected float drawLayer;
        protected Vector2 origin;
        protected float newRotation;

        //Constructor


        /*
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
        */
        //Abstract
        /// <summary>
        /// Update method. Runs every frame
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);
        /// <summary>
        /// Used to load content
        /// </summary>
        /// <param name="content"></param>
        public abstract void LoadContent(ContentManager content);

        //Virtual
        /// <summary>
        /// Used to draw a sprite on the screen
        /// </summary>
        /// <param name="spriteBatch">Access spritebatch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            /*
            //HUSK AT KOORDINATSYSTEMET ER PÅ HOVEDET!
            float newAngle = 0;
            float slope = 0;
            double slopeV;
            double angleDegrees;
            double angleRadians;
            CalculateAngle(0, 0, 0, 0, out slopeV, out angleDegrees, out angleRadians);
            float angleRadiansF = (float)angleRadians;
            slope = (float)slopeV;
            newAngle = (float)angleDegrees;
            
            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

            
            */




            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, drawLayer);
        }

        public virtual void Draw(SpriteBatch spriteBatch, bool flipped)
        {
            if (flipped)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.FlipHorizontally, drawLayer);
            }
            else
            {
                spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, drawLayer);
            }
        }
    }
}
