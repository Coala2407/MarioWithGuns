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
        public Texture2D MouseSprite;
        public Vector2 pos;

        public override void LoadContent(ContentManager content)
        {
            MouseSprite = content.Load<Texture2D>("Corshair");
        }

        public override void Update(GameTime gameTime)
        {
            //Updates the current position of the mouse
            MouseState currentMouseState = Mouse.GetState();
            pos = new Vector2(currentMouseState.X, currentMouseState.Y);
          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Loads the position info of the mouse and places the sprite on top of it to make a functional crosshair
            spriteBatch.Draw(MouseSprite, pos, Color.White);
            
        }

    }
}
