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
        private int height;
        Rectangle destination;

        public Platform(Vector2 position, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            destination = new Rectangle((int)position.X, (int)position.Y, width, height);
            drawLayer = 0.5f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("whitepixel");
        }

        public override void OnCollision(Entity otherEntity)
        {}

        public override void Die()
        {}

        public override void Shoot()
        {}

        public override Rectangle GetCollisionBox
        {
            get
            {
                return destination;
            }
        }
    }
}
