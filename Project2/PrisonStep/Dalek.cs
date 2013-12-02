using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
    class Dalek
    {
        GamePadState lastGPS;
        private PrisonGame game;
        private AnimatedModel model;

        private Matrix transform;
        private float orientation = 1.6f;
        private Vector3 location = new Vector3(275, 0, 1053);

        private int headBone;
        private int destructorArm;
        private float headOrientation = 0f;
        private ModelBone headBase;
        private Matrix headBaseBind;
        private float destructorOrientation = 0;
        private Matrix destructorMatrix;

        Matrix headMatrix;
        private float rate = .25f;

        

        public Dalek(PrisonGame game)
        {
            this.game = game;
            model = new AnimatedModel(game, "Dalek"); 
            SetDalekTransform();
            
        }


        public void Initialize()
        {
            lastGPS = GamePad.GetState(PlayerIndex.One);
        }


        private void SetDalekTransform()
        {
            transform = Matrix.CreateRotationY(orientation);
            transform.Translation = location;
        }



        public void LoadContent(ContentManager content)
        {
            model.LoadContent(content);

            headBone = model.GetIndexOfBone("Head");
            destructorArm = model.GetIndexOfBone("Arm2");
           // headBase = model.BonesTransforms[headBone];
            headBaseBind = model.BonesTransforms[headBone];
        }

        public void Update(GameTime gameTime)
        {
            model.Update(gameTime.ElapsedGameTime.TotalSeconds);
            headOrientation += .01f;
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            SetDalekTransform();

            
            //headOrientation += (float)(2 * Math.PI * rate * delta);

            Vector3 dirToPoint = game.Player.Location - location;

            dirToPoint /= dirToPoint.Length();

            Vector3 xDirection = Vector3.Cross(new Vector3(0, 1, 0), dirToPoint);
            xDirection /= xDirection.Length();

            Vector3 y = Vector3.Cross(dirToPoint, xDirection);
            destructorMatrix = new Matrix();
            //destructorMatrix.Translation = location;
            destructorMatrix.Backward = dirToPoint;
            destructorMatrix.Up = y;
            destructorMatrix.Right = xDirection;

           // model.AbsoTransforms[destructorArm] = destructorMatrix *transform;

            

           // headMatrix = model.GetBoneAbsoluteTransform(headBone);
            //headMatrix = Matrix.CreateRotationZ(headOrientation) * model.BindTransforms[headBone];
            
        }

        public void Draw(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            Matrix[] transforms = model.AbsoTransforms;
            transforms[headBone] = Matrix.CreateRotationZ(headOrientation) *transforms[headBone];
            transforms[destructorArm] = destructorMatrix * transforms[destructorArm];
            model.AbsoTransforms = transforms;
           // Matrix headTransform = model.AbsoTransforms[headBone];
            //headTransform =  Matrix.CreateRotationY(30);
           // model.AbsoTransforms[headBone] = headTransform;
            //transform.Translation = location;
            model.Draw(graphics, gameTime, transform);
        }






    }
}
