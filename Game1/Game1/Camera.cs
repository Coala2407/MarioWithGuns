using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class Camera : GameObject
    {

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }

        }
        private Vector2 position;
        public float ScrollingSpeed { get; set; }
        private Level level;

        public Camera(Level level)
        {
            this.level = level;
            ScrollingSpeed = 100;
            position = Player.PlayerPosition;
        }
        public override void Update(GameTime gameTime)
        {
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float previousPosX = position.X;

            position.X -= ScrollingSpeed * elapsedSeconds;

            for (int i = 0; i < level.backgroundLayers.Length; i++)
            {
                Background layer = level.backgroundLayers[i];
                level.backgroundLayers[i].OffsetX -= layer.Texture.Width;


                if (level.backgroundLayers[i].OffsetX < layer.Texture.Width)
                {
                    level.backgroundLayers[i].OffsetX = 0;
                }
            }

        }
        public Matrix GetMatrix()
        {

            return Matrix.CreateTranslation(new Vector3(position, 0));

        }
        public override void LoadContent(ContentManager content)
        {
            
        }
    }
}
