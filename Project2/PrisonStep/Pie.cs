using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
    public class Pie
    {
        private PrisonGame game;
        private AnimatedModel model;
        private Vector3 location;

        public Pie(PrisonGame game)
        {
            this.game = game;
            model = new AnimatedModel(game, "pies");
            
        }

        public void LoadContent(ContentManager content)
        {
            model.LoadContent(content);


        }

        public void Update(GameTime gameTime)
        {

        }


        public void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            Matrix transform = Matrix.CreateTranslation(game.Player.Location);
            model.Draw(graphics, gameTime, transform);
            
        }

    }
}
