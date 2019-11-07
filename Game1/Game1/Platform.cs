using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Platform : Entity
    {
        /// <summary>
        /// Width of the platform (field of class Platform)
        /// </summary>
        private int width;

        public Platform()
        {
            width = 1000;
            position = new Vector2(300, 300);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("whitepixel");
        }

        public override void OnCollision(GameObject otherEntity)
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, drawLayer);
        }
    }
}
