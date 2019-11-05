using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    abstract class GameObject
    {
        //Fields
        protected Texture2D sprite;
        protected Texture2D[] sprites;
        protected Vector2 position;
        protected byte drawLayer;

        //Constructor

        //Abstract
        public abstract void Update(GameTime gameTime);

        public abstract void LoadContent(ContentManager content);

        //Virtual
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
