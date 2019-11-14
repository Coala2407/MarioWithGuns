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
        //World size
        public const int Width = 1920;
        public const int Height = 1080;

        //Graphics device
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //World fields
        public static List<GameObject> GameObjectList = new List<GameObject>();
        public static List<Entity> EntityList = new List<Entity>();
        public static int enemiesShot;

        //Used to add game objects and entities while game is running
        public static List<GameObject> NewGameObjectList = new List<GameObject>();
        public static List<Entity> NewEntityList = new List<Entity>();

        //Used to remove game objects and entities while game is running
        public static List<GameObject> RemoveGameObjectList = new List<GameObject>();
        public static List<Entity> RemoveEntityList = new List<Entity>();

        //Screensize
        private static Vector2 screenSize;
        public static Vector2 ScreenSize { get => screenSize; }

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
        /// <summary>
        /// Used to add new gameobjects doing runtime
        /// </summary>
        /// <param name="go"></param>
        public static void AddGameObject(GameObject go)
        {
            NewGameObjectList.Add(go);
        }

        /// <summary>
        /// Used to add ned entities doing runtime
        /// </summary>
        /// <param name="en"></param>
        public static void AddEntity(Entity en)
        {
            NewEntityList.Add(en);
        }

        /// <summary>
        /// Used to remove gameobejcts doing runtime
        /// </summary>
        /// <param name="go"></param>
        public static void RemoveGameObject(GameObject go)
        {
            RemoveGameObjectList.Add(go);
        }

        /// <summary>
        /// Used to remove entities doing runtime
        /// </summary>
        /// <param name="en"></param>
        public static void RemoveEntity(Entity en)
        {
            RemoveEntityList.Add(en);
        }

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
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
            //Screen setup
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.ApplyChanges();
            
            //Player
            EntityList.Add(new Player());
            
            //Ground
            EntityList.Add(new Platform(new Vector2(0, 800), (int)Width - 1, 400));

            //Platforms
            EntityList.Add(new Platform(new Vector2(0, 550), 500, 50));
            EntityList.Add(new Platform(new Vector2(650, 395), 200, 50));
            EntityList.Add(new Platform(new Vector2(1100, 225), 300, 50));
            EntityList.Add(new Platform(new Vector2(650, 650), 200, 50));
            EntityList.Add(new Platform(new Vector2(1500, 650), 200, 50));
            EntityList.Add(new Platform(new Vector2(1619, 475), 300, 50));
            EntityList.Add(new Platform(new Vector2(1719, 300), 200, 50));

            //Enemies
            EntityList.Add(new Enemy(new Vector2(1000, 600)));
            EntityList.Add(new Enemy(new Vector2(200, 800)));
            EntityList.Add(new Enemy(new Vector2(1100, 225)));
            EntityList.Add(new Enemy(new Vector2(1800, 300)));
            GameObjectList.Add(new Crosshair());

            //Baggrunde
            GameObjectList.Add(new BackGround("Backgroundlayer03",0,0.1f));
            GameObjectList.Add(new BackGround("Backgroundlayer02", -50,0.2f));
            GameObjectList.Add(new BackGround("Backgroundlayer01", -55,0.3f));
            base.Initialize();
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
            //Quits the program/game when the 'Escape' button is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

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

            //Remove gameObjects
            foreach (GameObject go in RemoveGameObjectList)
            {
                GameObjectList.Remove(go);
            }

            //Remove entities
            foreach (Entity go in RemoveEntityList)
            {
                EntityList.Remove(go);
            }

            //Add new gameobjects to list
            GameObjectList.AddRange(NewGameObjectList);
            NewGameObjectList.Clear();

            //Add new entities to list
            EntityList.AddRange(NewEntityList);
            NewEntityList.Clear();

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
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
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
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}