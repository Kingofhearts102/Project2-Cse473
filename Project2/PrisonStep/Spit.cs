using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
   public class Spit
    {
       private PrisonGame game;
       private Model model;
       private LinkedList<SpitBall> laserBlasts = new LinkedList<SpitBall>();

       public class SpitBall
       {
           public Vector3 position;
           public Matrix orientation;
           public float speed;
           public float life;
       }


       public Spit(PrisonGame game)
       {
           this.game = game;
       }
       /// <summary>
       /// This is called to load content into our game
       /// </summary>
       /// <param name="content"></param>
       public void LoadContent(ContentManager content)
       {
           model = content.Load<Model>("Spit");
       }
       /// <summary>
       /// This function is called constantly to update the game
       /// </summary>
       /// <param name="gameTime"></param>
       public void Update(GameTime gameTime)
       {
           float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
           for (LinkedListNode<SpitBall> blastNode = laserBlasts.First; blastNode != null; )
           {
               //bastNode is the current node and we set
               // nextBlast to the next node in the list
               LinkedListNode<SpitBall> nextBlast = blastNode.Next;

               //this is the actual blast object we are working on
               SpitBall blast = blastNode.Value;

               //Update the position
               Vector3 direction = Vector3.TransformNormal(new Vector3(0, 0, 1), blast.orientation);
               blast.position += direction * blast.speed * delta;

               //decrease life of the blast

               blast.life -= delta;
               if (blast.life <= 0)
               {
                   laserBlasts.Remove(blastNode);
               }

               blastNode = nextBlast;
           //    Console.WriteLine(blast.position);
           }
          
       }
       /// <summary>
       /// Draws game objects
       /// </summary>
       /// <param name="graphics"></param>
       /// <param name="gameTime"></param>
       public void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
       {
           foreach (SpitBall blast in laserBlasts)
           {
               DrawModel(graphics, model, blast.orientation * Matrix.CreateTranslation(blast.position));
           }
       }


       private void DrawModel(GraphicsDeviceManager graphics, Model model, Matrix world)
       {
           Matrix[] transforms = new Matrix[model.Bones.Count];
           model.CopyAbsoluteBoneTransformsTo(transforms);
           graphics.GraphicsDevice.BlendState = BlendState.AlphaBlend;
           foreach (ModelMesh mesh in model.Meshes)
           {
               foreach (BasicEffect effect in mesh.Effects)
               {
                   effect.EnableDefaultLighting();
                   effect.World = transforms[mesh.ParentBone.Index] * world;
                   effect.View = game.Camera.View;
                   effect.Projection = game.Camera.Projection;

               }

               mesh.Draw();
           }
       }

       public void ShootSpit(Vector3 position, Matrix orientation, float speed)
       {
           SpitBall blast = new SpitBall();
           blast.position = position;
           blast.orientation = orientation;
           blast.speed =  4+speed;
           blast.life = 2.0f;
           Console.WriteLine(position);
           laserBlasts.AddLast(blast);
       }

       public LinkedList<SpitBall> LaserBlasts
       {
           get
           {
               return laserBlasts;
           }
       }

       public void Restart()
       {
           laserBlasts.Clear();
       }

    } // end of class
} // end of namespace
