using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    const float textureSize = 64f;
    float per = 1f / textureSize;

    protected Vector3[] GetCubVertices(Vector3 size)
    {
        List<Vector3> vertices = new List<Vector3>();

        Vector3[] front = new Vector3[]
        {
           new Vector3(-size.x,-size.y,-size.z),
           new Vector3(-size.x,size.y,-size.z),
           new Vector3(size.x,size.y,-size.z),
           new Vector3(size.x,-size.y,-size.z)
        };
        vertices.AddRange(front);

        Vector3[] Top = new Vector3[]
        {
           new Vector3(-size.x,size.y,-size.z),
           new Vector3(-size.x,size.y,size.z),
           new Vector3(size.x,size.y,size.z),
           new Vector3(size.x,size.y,-size.z)
        };
        vertices.AddRange(Top);

        Vector3[] Left = new Vector3[]
        {
           new Vector3(-size.x,-size.y,size.z),
           new Vector3(-size.x,size.y,size.z),
           new Vector3(-size.x,size.y,-size.z),
           new Vector3(-size.x,-size.y,-size.z)
        };
        vertices.AddRange(Left);

        Vector3[] Right = new Vector3[]
        {
           new Vector3(size.x,-size.y,-size.z),
           new Vector3(size.x,size.y, -size.z),
           new Vector3(size.x,size.y,size.z),
           new Vector3(size.x,-size.y,size.z)
        };
        vertices.AddRange(Right);

        Vector3[] Back = new Vector3[]
        {
           new Vector3(size.x,-size.y,size.z),
           new Vector3(size.x,size.y,size.z),
           new Vector3(-size.x,size.y,size.z),
           new Vector3(-size.x,-size.y,size.z)
        };
        vertices.AddRange(Back);

        Vector3[] Bottom = new Vector3[]
        {
           new Vector3(size.x,-size.y,-size.z),
           new Vector3(size.x,-size.y,size.z),
           new Vector3(-size.x,-size.y,size.z),
           new Vector3(-size.x,-size.y,-size.z)

        };
        vertices.AddRange(Bottom);

        return vertices.ToArray();
    }

    protected int[] GetCubeTriangles(int count)
    {
        List<int> triangles = new List<int>();

        for (int i = 0; i < count / 4; i++)
        {
            int index = i * 4;
            int[] t = new int[]
            {
                index,index+1,index+2, index,index+2,index+3
            };
            triangles.AddRange(t);
        }

        return triangles.ToArray();
    }

    // UV 배열 반환(픽셀사이즈,시작점(왼쪽아래))
    protected Vector2[] GetUVArray(Vector3 px, Vector2 point)
    {

        Vector3 size = per * px;
        List<Vector2> uvs = new List<Vector2>();

        Vector2[] Front = new Vector2[]
        {
           new Vector2(point.x + size.z,point.y),
           new Vector2(point.x + size.z,point.y+size.y),
           new Vector2(point.x + size.z+size.x,point.y+size.y),
           new Vector2(point.x + size.z+size.x,point.y)
        };
        uvs.AddRange(Front);

        Vector2[] top = new Vector2[]
        {
           new Vector2(point.x + size.z,point.y+size.y),
           new Vector2(point.x + size.z,point.y+size.y+size.z),
           new Vector2(point.x + size.z+size.x,point.y+size.y+size.z),
           new Vector2(point.x + size.z+size.x,point.y+size.y)
        };
        uvs.AddRange(top);

        Vector2[] Left = new Vector2[]
       {
           new Vector2(point.x,point.y),
           new Vector2(point.x,point.y+size.y),
           new Vector2(point.x + size.z,point.y+size.y),
           new Vector2(point.x + size.z,point.y)
       };
        uvs.AddRange(Left);
        Vector2[] Right = new Vector2[]
        {
           new Vector2(point.x + size.z+size.x,point.y),
           new Vector2(point.x + size.z+size.x,point.y+size.y),
           new Vector2(point.x + size.x+(2*size.z),point.y+size.y),
           new Vector2(point.x + size.x+(2*size.z),point.y)
        };
        uvs.AddRange(Right);

        Vector2[] Back = new Vector2[]
        {
           new Vector2(point.x + size.x+(2*size.z),point.y),
           new Vector2(point.x + size.x+(2*size.z),point.y+size.y),
           new Vector2(point.x + (2*size.x)+(2*size.z),point.y+size.y),
           new Vector2(point.x + (2*size.x)+(2*size.z),point.y)
        };
        uvs.AddRange(Back);
        Vector2[] Bottom = new Vector2[]
{
           new Vector2(point.x + size.z+size.x,point.y+size.y),
           new Vector2(point.x + size.z+size.x,point.y+size.y+size.z),
           new Vector2(point.x + size.x+(2*size.z),point.y+size.y+size.z),
           new Vector2(point.x + size.x+(2*size.z),point.y+size.y)
};
        uvs.AddRange(Bottom);

        return uvs.ToArray();
    }


    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();

        m.vertices = GetCubVertices(new Vector3(4f, 4f, 4f));
        m.triangles = GetCubeTriangles(m.vertices.Length);

        m.uv = GetUVArray(new Vector3(8f,8f,8f), new Vector2(0f, 0.75f));
        m.RecalculateNormals();

        mf.mesh = m;
    }
}
