using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
   public class Gort
    {
       /* GamePadState lastGPS;
        private PrisonGame game;
        private AnimatedModel model;

        private Matrix transform;
        private float orientation = 1.6f;
        private Vector3 location = new Vector3(250, 0, 1000);

        public Gort(PrisonGame game)
        {
            this.game = game;
            model = new AnimatedModel(game, "Gort");

            //model.AddAssetClip("catcheat", "Gort-catcheat");
           // model.AddAssetClip("salute", "Gort-salute");
            //model.AddAssetClip("stance","Gort-stance");
           // model.AddAssetClip("walkloop", "Gort-walkloop");
           // model.AddAssetClip("walkstart", "Gort-walkstart");

            SetGortTransform();
        }


        public void Initialize()
        {
            lastGPS = GamePad.GetState(PlayerIndex.One);
        }

        private void SetGortTransform()
        {
            transform = Matrix.CreateRotationY(orientation);
            transform.Translation = location;
        }

        public void LoadContent(ContentManager content)
        {
            model.LoadContent(content);

            //AnimationPlayer player = model.PlayClip("tantrum");

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardstate = Keyboard.GetState();
            if (keyboardstate.IsKeyDown(Keys.Space))
            {
                //AnimationPlayer player = model.PlayClip("salute");
            }


            model.Update(gameTime.ElapsedGameTime.TotalSeconds);

        }

        public void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            Matrix transform = Matrix.CreateRotationY(orientation);
            transform.Translation = location;
            model.Draw(graphics, gameTime, transform);
        }*/



    }
}
