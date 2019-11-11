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
