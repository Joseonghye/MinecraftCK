using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    Vector3[] GetCubVertices(Vector3 size)
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

    int[] GetCubeTriangles(int index)
    {
        List<int> triangles = new List<int>();

        for(int i=0; i < index; i+=4)
        {
            int[] t = new int[]
            {
                i,i+1,i+2, i,i+2,i+3
            };
            triangles.AddRange(t);
        }

        return triangles.ToArray();
    }

    Vector2[] GetCubeUV(Vector3 size, Vector2 point)
    {
        List<Vector2> uvs = new List<Vector2>();

        Vector2[] Front = new Vector2[]
        {
           new Vector2(point.x + size.z,point.y),
           new Vector2(point.x + size.z,point.y+size.y),
           new Vector2(point.x + size.z+size.x,point.y+size.y),
           new Vector2(point.x + size.z+size.x,point.y)
        };
        uvs.AddRange(Front);
        Vector2[] Top = new Vector2[]
        {
           new Vector2(point.x + size.z,point.y+size.y),
           new Vector2(point.x + size.z,point.y+size.y+size.z),
           new Vector2(point.x + size.z+size.x,point.y+size.y+size.z),
           new Vector2(point.x + size.z+size.x,point.y+size.y)
        };
        uvs.AddRange(Top);

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

    void Start ()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();
    
        m.vertices = GetCubVertices(new Vector3(4f,4f,4f));
        m.triangles =GetCubeTriangles(m.vertices.Length);

        m.uv = GetCubeUV(new Vector3(0.125f, 0.125f, 0.125f), new Vector2(0f, 0.75f));
        // m.uv2 = 두장의 텍스쳐를 사용할때, 하지만 보통 uv2는 라이트맵에 사용된다.
        m.RecalculateNormals(); // 알아서 노말을 계산해줌

        mf.mesh = m;
    }


}
