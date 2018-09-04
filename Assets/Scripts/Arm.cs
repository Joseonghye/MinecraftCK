using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : Cube {

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();

        m.vertices = GetCubVertices(new Vector3(2f, 6f, 2f));
        m.triangles = GetCubeTriangles(m.vertices.Length);

        m.uv = GetUVArray(new Vector3(4f, 12f, 4f), new Vector2(0.625f, 0.5f));
        m.RecalculateNormals();

        mf.mesh = m;
    }

}
