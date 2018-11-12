
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{

    public MeshFilter meshFilter;

    public Mesh mesh;

    public List<Vector3> vertex;
    public List<Vector3> vertexMoved;
    public List<int> tris;

    public float minHeight = 0.9f;
    public float minWidth = 0.2f;

    public float maxHeight = 1.5f;
    public float maxWidth = 0.3f;

    public int index;

    public int bladeCount = 1000;

    public float aeraSize = 20;

    public float amplitude = 1;
    public float frequence = 1;
    public float waving = 1;

    public float scaleX;
    public float scaleY;


    [ContextMenu("Regenerate")]
    void Start()
    {
        vertex = new List<Vector3>();
        tris = new List<int>();
        vertexMoved = new List<Vector3>();
        index = 0;

        for (int i = 0; i < bladeCount; i++)
        {
            Vector2 point = Random.insideUnitCircle * aeraSize;

            GenerateBlade(new Vector3(point.x,0,point.y));
        }

        mesh = new Mesh();

        GenerateBlade(new Vector3(4, 0, 0));

        GenerateMesh();
    }

    private void GenerateMesh()
    {
        mesh = new Mesh();

        mesh.vertices = vertex.ToArray();
        mesh.triangles = tris.ToArray();

        meshFilter.mesh = mesh;
    }

    void GenerateBlade(Vector3 pos)
    {
        float usedWidth = Random.Range(minWidth, maxWidth);
        float usedHeight = Random.Range(minHeight, maxHeight);
        float randomAngle = Random.Range(0, 180);

        Vector3 a = new Vector3 (0, usedHeight, 0);
        Vector3 b = new Vector3(usedWidth * Mathf.Cos(randomAngle), 0, usedWidth * Mathf.Sin(randomAngle));
        Vector3 c = -b;

        a += pos;
        b += pos;
        c += pos;

        vertex.Add(a);
        vertex.Add(b);
        vertex.Add(c);

        vertexMoved.Add(a);
        vertexMoved.Add(b);
        vertexMoved.Add(c);

        tris.Add(0 + index * 3);
        tris.Add(1 + index * 3);
        tris.Add(2 + index * 3);

        tris.Add(0 + index * 3);
        tris.Add(2 + index * 3);
        tris.Add(1 + index * 3);

        index++;
    }

    void Update()
    {
        MoveGrass();
    }

    void MoveGrass()
    {
        for (int i = 0; i < bladeCount; i++)
        {
            MoveBlade(i);
        }
    }

    void MoveBlade(int i)
    {
        //vertex[i * 3] += new Vector3(Mathf.Sin(Time.time), 0, 0);

        vertexMoved[i * 3] = vertex[i*3] + new Vector3(Mathf.Sin(Time.time * frequence + vertex[i * 3].x * waving) * amplitude, 0, 0);

        float decal = Mathf.PerlinNoise(vertex[i * 3].x / scaleX, Time.time * frequence + vertex[i * 3].z / scaleY * waving * amplitude);

        UpdateMesh();
    }

    void UpdateMesh()
    {
        mesh.vertices = vertexMoved.ToArray();
    }
}
