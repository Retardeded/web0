using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothFromMesh : MonoBehaviour
{

    public Transform prefab;

    void Start()
    {
        Vector3[] verts = GetComponent<MeshFilter>().sharedMesh.vertices;
        for(int i = 0; i < 2500; i++)
        {

            Vector3 pos = Quaternion.Euler(-90, 0, 0) * verts[i] / 10;
            Instantiate(prefab, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
