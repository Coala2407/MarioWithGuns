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
    class Bullet : Entity
    {
        private Vector2 targetCoords;
        private float speed;
        /// <summary>
        /// This is the constructor for the bullet.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public Bullet(Texture2D sprite, Vector2 position)
        {

            this.sprite = sprite;
            this.position = position;

        }

        /// <summary>
        /// WIP >:(
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {

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
        public virtual void Draw(SpriteBatch spriteBatch)
        {

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




            spriteBatch.Draw(sprite, position, null, Color.White, angleRadiansF, origin, 1, SpriteEffects.None, drawLayer);
        }
    }
}



