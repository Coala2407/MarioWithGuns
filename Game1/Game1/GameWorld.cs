using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {

        public const int Width = 1920;
        public const int Height = 1080;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //World fields
        public static List<GameObject> GameObjectList = new List<GameObject>();
        public static List<Entity> EntityList = new List<Entity>();
        //Used to add to the other while game is running
        public static List<GameObject> NewGameObjectList = new List<GameObject>();
        public static List<Entity> NewEntityList = new List<Entity>();

        //Screensize
        private static Vector2 screenSize;
        public static Vector2 ScreenSize { get => screenSize; }

        //Methods
        //Debug hitboxes
#if DEBUG
        Texture2D collisionTexture;
        private void DrawCollisionBox(Entity en)
        {
            Rectangle collisionBox = en.GetCollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
#endif


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.ApplyChanges();

            EntityList.Add(new Player());
            EntityList.Add(new Platform());
            GameObjectList.Add(new Crosshair());
            GameObjectList.Add(new BackGround("download"));
            

            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        public static void Instantiate(GameObject g)
        {
            NewGameObjectList.Add(g);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load all from gameobjects
            foreach (GameObject go in GameObjectList)
            {
                go.LoadContent(Content);
            }

            //Load all from entities
            foreach (GameObject go in EntityList)
            {
                go.LoadContent(Content);
            }

            //Load Debug hitbox
#if DEBUG
            collisionTexture = Content.Load<Texture2D>("whitepixel");
#endif

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update gameobjects
            foreach (GameObject go in GameObjectList)
            {
                go.Update(gameTime);
            }
            //Update entities
            foreach (Entity en in EntityList)
            {
                en.Update(gameTime);
                foreach (Entity other in EntityList)
                {
                    en.CheckCollision(other);
                }
            }
            
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //Draw all gameobjects on the list
            foreach (GameObject go in GameObjectList)
            {
                go.Draw(spriteBatch);
            }

            //Draw all entities on the list
            foreach (Entity en in EntityList)
            {
                en.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(en);
#endif
            }
            // TODO: Add your drawing code here

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}