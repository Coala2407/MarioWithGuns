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
    public class Level : GameObject
    {
        private Player player;
        public Background[] backgroundLayers;
        public Camera Camera { get; set; }
        private GameWorld game;
        public Level(GameWorld game)     
        {
            this.game = game;
            player = new Player();


            backgroundLayers = new Background[4];
            backgroundLayers[0] = new Background()
            {

                Texture = game.Content.Load<Texture2D>("Kalikula"),
                ScrollingSpeed = 0.1f,
                OffsetY = 300

            };
            backgroundLayers[1] = new Background()
            {

                Texture = game.Content.Load<Texture2D>("Kalikula"),
                ScrollingSpeed = 0.2f,
                OffsetY = 700

            };
            backgroundLayers[2] = new Background()
            {

                Texture = game.Content.Load<Texture2D>("Kalikula"),
                ScrollingSpeed = 0.4f,
                OffsetY = 800

            };
            backgroundLayers[3] = new Background()
            {

                Texture = game.Content.Load<Texture2D>("Kalikula"),
                ScrollingSpeed = 0.8f,
                OffsetY = 900

            };


            Camera = new Camera(this);
        }

        public Level()
        {
        }

        public override void Update(GameTime gameTime)
        {

            
            

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            int cameraX = (int)Camera.Position.X;
            int cameraY = (int)Camera.Position.Y;
            foreach (Background layer in backgroundLayers)
            {
                if (layer.Texture != null)
                {
                    int bgRepeatsX = (int)GameWorld.ScreenSize.X / layer.Texture.Width + 1;
                    int bgRepeatsY = (int)GameWorld.ScreenSize.Y / layer.Texture.Height + 1;
                    int bgStartX = cameraX / layer.Texture.Width;
                    for (int j = -1; j <bgStartX + bgRepeatsX; j++)
                    {
                        spriteBatch.Draw(layer.Texture, new Vector2(cameraX + layer.OffsetX + j * layer.Texture.Width, cameraY + layer.OffsetY), null, Color.White);
                    }
                }
            }
        }
        public override void LoadContent(ContentManager content)
        {
            
        }
    }
}
