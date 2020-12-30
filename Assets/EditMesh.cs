using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMesh : MonoBehaviour
{
    public static Mesh baseMesh;
    public static Mesh mesh;
    
    public static Vector3 stretchAxis;

    public static bool stretching = true;
    
    private Vector3[] vertices;
    
    
    // Start is called before the first frame update
    void Awake()
    {

        //baseMesh = (Mesh)Instantiate( GetComponent<MeshFilter>().mesh);
        
        baseMesh = (Mesh)Instantiate(GetComponent<MeshFilter>().sharedMesh);
        Debug.Log(baseMesh.vertices.Length);
        
        
        //Vector3 rotate = new Vector3(0f, 0f, -1f);

        Vector3 rotate = new Vector3(-1f, 1f,0f);
        
        stretchAxis = rotate;

        //mesh = GetComponent<MeshFilter>().mesh;
        mesh = GetComponent<MeshFilter>().sharedMesh;
       
    }

 

    // Update is called once per frame
    void Update()
    {
        if(!stretching)
            return;
        
        //Debug.Log(baseMesh.vertices.Length);



        //mesh.Clear();
        /*
        vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        Vector3 stretchVector = stretchAxis;

        for (var i = 0; i < vertices.Length; i++)
        {
            Vector3 currVector = baseMesh.vertices[i];

            if (ClothPart.vertices.Contains(currVector))

                if (currVector.y < ClothPart.clothPartCenter.y)
                {
                    vertices[i] = baseMesh.vertices[i] - Vector3.Distance(currVector, ClothPart.clothPartCenter) * stretchVector * Mathf.Sin(Time.time);
                }

            //baseMesh
        }

        */
 

        mesh.vertices = vertices;
        
    }
    

    void OnApplicationQuit()
    {
        stretching = false;
        mesh.vertices = baseMesh.vertices;
    }
}