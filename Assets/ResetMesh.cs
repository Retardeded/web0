using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    public void StretchMesh()
    {
        Vector3[] vertices = EditMesh.mesh.vertices;
        
        for (var i = 0; i < vertices.Length; i++)
        {
            //if (baseMesh.vertices[i].x > 0)
            //    vertices[i] = baseMesh.vertices[i] + up * Mathf.Sin(Time.time);
            //else
            //    vertices[i] = baseMesh.vertices[i];

 

        }
    
    }
}
