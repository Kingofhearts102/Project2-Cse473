using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrisonStep
{
    public class BoundingCylindar 
    {
        BoundingBox box;

        public BoundingCylindar()
        {
            
        }

        public void TestForSphereCollision()
        {


        }

        public void TestForRayCollision()
        {

        }

        public void CalculateBoundingBox(Model model, Matrix worldTransform)
        {
            /* Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
             Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

             // For each mesh of the model
             foreach (ModelMesh mesh in model.Meshes)
             {
                 foreach (ModelMeshPart meshPart in mesh.MeshParts)
                 {
                     // Vertex buffer parameters
                     int vertexStride = meshPart.VertexBuffer.VertexDeclaration.VertexStride;
                     int vertexBufferSize = meshPart.NumVertices * vertexStride;

                     // Get vertex data as float
                     float[] vertexData = new float[vertexBufferSize / sizeof(float)];
                     meshPart.VertexBuffer.GetData<float>(vertexData);

                     // Iterate through vertices (possibly) growing bounding box, all calculations are done in world space
                     for (int i = 0; i < vertexBufferSize / sizeof(float); i += vertexStride / sizeof(float))
                     {
                         Vector3 transformedPosition = Vector3.Transform(new Vector3(vertexData[i], vertexData[i + 1], vertexData[i + 2]), worldTransform);

                         min = Vector3.Min(min, transformedPosition);
                         max = Vector3.Max(max, transformedPosition);
                     }
                 }
             }
             box = new BoundingBox(min, max);
             box.GetCorners();
             foreach(Vector3 vec in box.GetCorners())
             {
                 VertexPositionColor color = new VertexPositionColor(vec, Color.Green);
             }


         }*/
        }
    }
}
