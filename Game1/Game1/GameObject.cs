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

        //Constructor

        protected double CalculateAngle(int posX1, int posY1, int posX2, int posY2)
        {
            /*
            //Position 1
            int posX1 = ;
            int posY1 = ;

            //Position 2
            int posX2 = ;
            int posY2 = ;
            */

            //Angle deci (Radians)
            double m = (posY2 - posY1) / (posX2 - posX1);

            //Angle deci to degrees
            double angleRad = Math.Atan(m);
            double angleDeg = (180 / Math.PI) * angleRad;

            //Returns the degree in double
            return angleDeg;
        }

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
            float newAngle = 0;
            //newAngle = (float)CalculateAngle(10, 10, 20, 20);
            spriteBatch.Draw(sprite, position, null, Color.White, newAngle, origin, 1, SpriteEffects.None, drawLayer);
        }
    }
}
