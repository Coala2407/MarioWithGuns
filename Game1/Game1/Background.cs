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
        

        private float movementSpeed = 500;
        private string spriteName;
        private string[] spriteNames;
        public BackGround(string spriteName)
        {
            this.spriteName = spriteName;
        }
        public BackGround(string spriteName, float movementSpeed)
        {
            this.spriteName = spriteName;
            this.movementSpeed = movementSpeed;

        }
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);

        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
            this.position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y - sprite.Height / 2);
            this.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
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
        private void Move(GameTime gameTime)
        {
                                     
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ((velocity * movementSpeed) * deltaTime);

        }

    }

}
