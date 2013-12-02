using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
    public class Alien
    {
        GamePadState lastGPS;
        private PrisonGame game;
        private AnimatedModel model;
        private Spit spit;

        private Matrix transform;
        private float orientation = 1.6f;
        private Vector3 location = new Vector3(256, 0, 1000);

        public Alien(PrisonGame game)
        {
            this.game = game;
            spit = new Spit(this.game);
            model = new AnimatedModel(game, "Alien");
            model.AddAssetClip("catcheat", "Alien-catcheat");
            model.AddAssetClip("stance", "Alien-stance");
            model.AddAssetClip("tantrum", "Alien-trantrum");
            model.AddAssetClip("ob", "Alien-ob");

            SetAlienTransform();
           
        }

        public void Initialize()
        {
            lastGPS = GamePad.GetState(PlayerIndex.One);
        }

        private void SetAlienTransform()
        {
            transform = Matrix.CreateRotationY(orientation);
            transform.Translation = location;
        }
        public void LoadContent(ContentManager content)
        {
            model.LoadContent(content);
            spit.LoadContent(content);

            //AnimationPlayer player = model.PlayClip("tantrum");
            
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardstate = Keyboard.GetState();
            if(keyboardstate.IsKeyDown(Keys.Space))
            {
                Matrix orientation = transform;
                orientation.Translation = Vector3.Zero;
                spit.ShootSpit(location + new Vector3(0, 50, 0), orientation, 2f);
                AnimationPlayer player = model.PlayClip("tantrum");
                

            }


            model.Update(gameTime.ElapsedGameTime.TotalSeconds);
            spit.Update(gameTime);

        }

        public void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            Matrix transform = Matrix.CreateRotationY(orientation);
            transform.Translation = location;
            model.Draw(graphics, gameTime, transform);
            spit.Draw(graphics, gameTime);
        }

    }
}
