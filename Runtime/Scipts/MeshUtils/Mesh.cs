using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh
{
    #region Structs
    private struct Tri{
        public Vector3[] Vertices;
        public Vector3[] Normals;
        public bool Clockwise;
        public Tri(Vector3[] Vertices, Vector3[] Normals, bool Clockwise){
            this.Vertices = Vertices;
            this.Normals = Normals;
            this.Clockwise = Clockwise;
        }
    }
    private struct Quad{
        public Vector3[] Vertices;
        public Vector3[] Normals;
        public bool Clockwise;
        public Quad(Vector3[] Vertices, Vector3[] Normals, bool Clockwise){
            this.Vertices = Vertices;
            this.Normals = Normals;
            this.Clockwise = Clockwise;
        }
        public AppendQuadTo(out Mesh mesh, Quad quad){
            int meshlength = mesh.vertices.Length;
            int meshlength2nd = meshlength + 3;
            
            mesh.vertices = mesh.vertices.Concat(quad.Vertices);
            mesh.normals = mesh.normals.Concat(quad.Normals);
            
            mesh.triangles = mesh.triangles.Concat(new int[]{meshlength,quad.Clockwise ? meshlength+1 : meshlength+2, quad.Clockwise ? meshlength+2 : meshlength +1,meshlength2nd,quad.Clockwise ? meshlength2nd+1 : meshlength2nd+2, quad.Clockwise ? meshlength2nd+2 : meshlength2nd +1});
        }
    }
    #endregion
    #region Geometry

    #endregion
    #region Quads
    private Mesh unitQuad;
    public Mesh UnitQuad()
    {
        if (unitQuad == null)
        {
            unitQuad = new Mesh();
            unitQuad.name = "UnitQuad";
            unitQuad.color = new Color(0, 0, 0, 0);
            unitQuad.vertices = new Vector3[] {
                new Vector3(0, 1, 0), new Vector3(1, 1, 0),
                new Vector3(0, 0, 0), new Vector3(1, 0, 0)
                };
            unitQuad.normals = new Vector3[] { 
                Vector3.up, Vector3.up,
                Vector3.up, Vector3.up };
            unitQuad.triangles = new int[] {
                2, 3, 1,
                2, 1, 0
                };
            unitQuad.recalculateBounds();
        } 
        return unitQuad;
    }
    #endregion
    #region Volumes
    private Mesh unitCube;
    public Mesh UnitCube()
    {
        if (unitCube == null)
        {
            unitCube = new Mesh();
            unitCube.name = "UnitCube";
            unitCube.color = new Color(0, 0, 0, 0);
            unitCube.vertices = new Vector3[] {
                new Vector3(0, 1, 0), new Vector3(1, 1, 0),
                new Vector3(0, 0, 0), new Vector3(1, 0, 0)
                };
            unitCube.normals = new Vector3[] { 
                Vector3.down, Vector3.down,
                Vector3.down, Vector3.down };
            unitCube.triangles = new int[] {
                2, 3, 1,
                2, 1, 0
                };
            unitCube.recalculateBounds();
        } 
        return unitCube;
    }
    #endregion
}
