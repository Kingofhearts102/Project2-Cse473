using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace PrisonStep
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PrisonGame : Microsoft.Xna.Framework.Game
    {

        #region Fields


        private PSLineDraw lineDraw;
        public PSLineDraw LineDraw { get { return lineDraw; } }
        /// <summary>
        /// This graphics device we are drawing on in this assignment
        /// </summary>
        GraphicsDeviceManager graphics;

        /// <summary>
        /// The camera we use
        /// </summary>
        private Camera camera;

        /// <summary>
        /// The player in your game is modeled with this class
        /// </summary>
        private Player player;


        private Alien alien;
        private Dalek dalek;
        private Gort gort;

        private double[] lightData =
{   1,      568,      246,    1036,   0.53,   0.53,   0.53,     821,     224, 
  941,  14.2941,       45, 43.9412,    814,    224,   1275,    82.5,       0,  0,
    2,       -5,      169,     428, 0.3964,  0.503, 0.4044,    -5.4,     169,
 1020, 129.4902, 107.5686, 41.8039,   -5.4,    169,   -138, 37.8275,      91, 91,
    3,      113,      217,    -933,    0.5,      0,      0,    -129,     185,
-1085,	     50,        0,       0,    501,    185,  -1087,      48,       0,  0,
    4,      781,      209,    -998,    0.2, 0.1678, 0.1341,    1183,     209,
 -998,	     50,  41.9608, 33.5294,    984,    113,   -932,       0,      80,  0,
    5,      782,      177,    -463,   0.65, 0.5455, 0.4359,     563,     195,
 -197,	     50,        0,       0,   1018,    181,   -188,      80,       0,  0,
    6,     1182,      177,   -1577,   0.65, 0.5455, 0.4359,     971,     181,
-1801,        0,  13.1765,      80,   1406,    181,  -1801,       0, 13.1765,  80};

        public double[] LightData
        {
            get { return lightData; }
            set { lightData = value; }
        }

        /// <summary>
        /// This is the actual model we are using for the prison
        /// </summary>
        private List<PrisonModel> phibesModels = new List<PrisonModel>();



        #endregion

        #region Properties

        /// <summary>
        /// The game camera
        /// </summary>
        public Camera Camera { get { return camera; } }

        public List<PrisonModel> PhibesModels
        {
            get { return phibesModels; }
        }
        #endregion

        private bool slimed = false;
        public bool Slimed { get { return slimed; } set { slimed = value; } }

        private float slimeLevel = 1.0f;
        public float SlimeLevel { get { return slimeLevel; } }
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public PrisonGame()
        {
            // XNA startup
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Create objects for the parts of the ship
            for(int i=1;  i<=6;  i++)
            {
                phibesModels.Add(new PrisonModel(this, i));
            }

            // Create a player object
            player = new Player(this);
            alien = new Alien(this);
            dalek = new Dalek(this);
            //gort = new Gort(this);

            // Some basic setup for the display window
            this.IsMouseVisible = true;
			this.Window.AllowUserResizing = true;
			this.graphics.PreferredBackBufferWidth = 1024;
			this.graphics.PreferredBackBufferHeight = 768;

            // Basic camera settings
            camera = new Camera(graphics);


            camera.FieldOfView = MathHelper.ToRadians(42);
            camera.Eye = new Vector3(800, 180, 1053);
            camera.Center = new Vector3(275, 90, 1053);

            lineDraw = new PSLineDraw(this, Camera);
            this.Components.Add(lineDraw);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            camera.Initialize();
            player.Initialize();
            alien.Initialize();
            dalek.Initialize();
          //  gort.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            player.LoadContent(Content);
            alien.LoadContent(Content);
            dalek.LoadContent(Content);
            //gort.LoadContent(Content);
//
            foreach (PrisonModel model in phibesModels)
            {
                model.LoadContent(Content);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            //
            // Update game components
            //

            player.Update(gameTime);
            alien.Update(gameTime);
            dalek.Update(gameTime);
           // gort.Update(gameTime);

            foreach (PrisonModel model in phibesModels)
            {
                model.Update(gameTime);
            }

            camera.Update(gameTime);

            // Amount to change slimeLevel in one second
            float slimeRate = 2.5f;

            if (slimed && slimeLevel >= -1.5)
            {
                slimeLevel -= (float)gameTime.ElapsedGameTime.TotalSeconds * slimeRate;
            }
            else if (!slimed && slimeLevel < 1)
            {
                slimeLevel += (float)gameTime.ElapsedGameTime.TotalSeconds * slimeRate;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            foreach (PrisonModel model in phibesModels)
            {
                model.Draw(graphics, gameTime);
            }

            player.Draw(graphics, gameTime);
            alien.Draw(graphics, gameTime);
            dalek.Draw(graphics, gameTime);
           // gort.Draw(graphics, gameTime);
            base.Draw(gameTime);
        }

        public Vector3 LightInfo(int section, int item)
        {
            int offset = (section - 1) * 19 + 1 + (item * 3);
            return new Vector3((float)lightData[offset],
                               (float)lightData[offset + 1],
                               (float)lightData[offset + 2]);
        }
    }
}
