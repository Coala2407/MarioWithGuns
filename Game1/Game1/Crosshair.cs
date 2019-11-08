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
    class Crosshair : GameObject
    {
        public Crosshair()
        {
            drawLayer = 0.50f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Corshair");
        }

        public override void Update(GameTime gameTime)
        {
            //Updates the current position of the mouse
            MouseState currentMouseState = Mouse.GetState();
            position = new Vector2(currentMouseState.X, currentMouseState.Y);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, drawLayer);
        }

        private void HandleInput(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Pressed)
            {
                position = new Vector2(state.X, state.Y);
            }
        }


    }
}
