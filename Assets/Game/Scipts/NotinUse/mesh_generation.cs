/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class mesh_generation : MonoBehaviour
{
    Mesh mesh;
    
    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        createShape();
        UpdateMesh();
    }


   void createShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

     

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }
    }


    void UpdateMesh()
    {
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
*/