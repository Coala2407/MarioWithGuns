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
    class BackGround : GameObject
    {
        private Vector2 velocity;
        public float speed = 500;

        private float movementSpeed = 500;
        private string spriteName;
        private string[] spriteNames;

        public BackGround(string spriteName)
        {
            this.spriteName = spriteName;
        }

        public BackGround(Texture2D sprite, float movementSpeed)
        {
            this.sprite = sprite;
            this.movementSpeed = movementSpeed;

        }

        public override void Update(GameTime gameTime)
        {



        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }
        public void HandleInput()
        {

            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity.X += 1;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                velocity.X -= 1;
            }


        }

    }

}
