using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
    

    public class Bazooka
    {

        Model model;
        Player player;       

        public Bazooka(Player player)
        {
            this.player = player;           
            
        }


        public void LoadContent(ContentManager content)
        {
            model = content.Load<Model>("PieBazooka");
        }

        public void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            
        }

        private void DrawModel()
        {
            
        }


    }


}
