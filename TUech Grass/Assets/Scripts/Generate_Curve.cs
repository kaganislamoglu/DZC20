using System;
using Unity.VisualScripting;
using UnityEngine;

public class Generate_Curve : MonoBehaviour
{
    private MeshFilter mf;
    private MeshCollider mc;
    private Mesh mesh;

    public float a = 0.2f;
    public float b = 0f;
    public float c = 0.5f;
    public float leftBound = -3f;
    public float rightBound = 3f;
    private float stepSize = 0.1f;
    private int steps;
    private float curveThickness = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        steps = (int)Math.Round((rightBound-leftBound)/stepSize);

        mesh = new Mesh();
        mesh.name = "Curve";

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        

        mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = mesh;

        mc = gameObject.AddComponent<MeshCollider>();
        mc.sharedMesh = mesh;
    }

    private Vector3[] GenerateVertices()
    {
        Vector3[] verts = new Vector3[(steps + 1) * 4];

        for(int i = 0; i <= steps; i++) {

            float x = leftBound + (i * stepSize);
            float y = (float)((a * Math.Pow(x,2)) + (b * x) + c);

            float dx = 1;
            float dy = (float)(2 * a * x + b);

            Vector2 tangent = new Vector2(dx, dy).normalized;

            Vector2 normal = new Vector2(-tangent.y, tangent.x);

            // x is on z cause thats how the curve is positioned in the world;
            Vector3 offset = new Vector3(normal.x, normal.y, 0) * curveThickness;

            verts[2 * i] = new Vector3(x, y, 0);
            verts[2 * i + 1] = new Vector3(x, y, 1);

            verts[(steps + 1) * 2 + 2 * i] = new Vector3(x, y, 0) - offset;
            verts[(steps + 1) * 2 + 2 * i + 1] = new Vector3(x, y, 1) - offset;
        }

        return verts;
        
    }

    private int[] GenerateTriangles()
    {
        int[] tris = new int[(steps * 8 + 4) * 3];

        int t = 0;

        for (int i = 0; i < steps; i++) {
        
            tris[t++] = 2 * i;
            tris[t++] = 2 * i + 1;
            tris[t++] = 2 * i + 2;
           
            tris[t++] = 2 * i + 1;
            tris[t++] = 2 * i + 3;
            tris[t++] = 2 * i + 2;
            
        }

        int bottomVertsOffset = (steps + 1) * 2;

        for (int i = 0; i < steps; i++) {
        
            tris[t++] = bottomVertsOffset + 2 * i;
            tris[t++] = bottomVertsOffset + 2 * i + 2;
            tris[t++] = bottomVertsOffset + 2 * i + 1;
           
            tris[t++] = bottomVertsOffset + 2 * i + 1;
            tris[t++] = bottomVertsOffset + 2 * i + 2;
            tris[t++] = bottomVertsOffset + 2 * i + 3;
            
        }

        for (int i = 0; i < steps; i++) {
        
            tris[t++] = 2 * i;
            tris[t++] = 2 * i + 2;
            tris[t++] = bottomVertsOffset + 2 * i;
            
            tris[t++] = bottomVertsOffset + 2 * i;
            tris[t++] = 2 * i + 2;
            tris[t++] = bottomVertsOffset + 2 * i + 2;
            

            tris[t++] = 2 * i + 1;
            tris[t++] = bottomVertsOffset + 2 * i + 1;
            tris[t++] = 2 * i + 3;
             
            tris[t++] = bottomVertsOffset + 2 * i + 1;
            tris[t++] = bottomVertsOffset + 2 * i + 3;
            tris[t++] = 2 * i + 3;
           
        }

            tris[t++] = 1;
            tris[t++] = 0;
            tris[t++] = bottomVertsOffset + 1;
            
            tris[t++] = 0;
            tris[t++] = bottomVertsOffset;
            tris[t++] = bottomVertsOffset + 1;

            int endIndex = steps * 2 + 1;
            tris[t++] = endIndex - 1;
            tris[t++] = endIndex;
            tris[t++] = bottomVertsOffset + endIndex - 1;
            
            tris[t++] = endIndex;
            tris[t++] = bottomVertsOffset + endIndex;
            tris[t++] = bottomVertsOffset + endIndex - 1;
        
        return tris;
    }

    // Update is called once per frame
    public void RegenerateCurve(float newA, float newB, float newC, float newLeftBound, float newRightBound) {
        a = newA;
        b = newB;
        c = newC;

        leftBound = newLeftBound;
        rightBound = newRightBound;

        steps = (int)Math.Round((rightBound-leftBound)/stepSize);

        mesh = new Mesh();
        mesh.name = "Curve";

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        
        mf.mesh = mesh;

        mc.sharedMesh = mesh;
    }
}
