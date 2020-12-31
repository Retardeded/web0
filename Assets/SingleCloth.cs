using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCloth : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<ClothPart.ClothPartData> clothParts = new List<ClothPart.ClothPartData>();
    
    Mesh baseMesh;
    Mesh mesh;
    bool stretching = true;
    Vector3[] vertices;
    private ClothPart.ClothPartData currentClothPart;
    
    void Awake()
    {
        baseMesh = (Mesh)Instantiate(GetComponent<MeshFilter>().sharedMesh);
        mesh = GetComponent<MeshFilter>().sharedMesh;
    }
    
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            ClothPart clothPart = transform.GetChild(i).GetComponent <ClothPart>();
            clothPart.markVertecies(baseMesh, mesh);
            var data = clothPart.getData();
            clothParts.Add(data);
        }

        currentClothPart = clothParts[0];
        
        Debug.Log("ALL  " + mesh.vertices.Length);
        Debug.Log("som  " + currentClothPart.vertices.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stretching)
            return;
        
        //mesh.Clear();
        //Vector3[] normals = mesh.normals;


    }

    public void changeClothPart(int index)
    {
        currentClothPart = clothParts[index];
    }

    public void lengthenClothPart(float scaleFactor)
    {
        vertices = mesh.vertices;

        Vector3 stretchVector = currentClothPart.stretchAxis;
        
        Debug.Log("stretch  " + stretchVector);

        for (var i = 0; i < vertices.Length; i++)
        {
            Vector3 currVector = baseMesh.vertices[i];
            
            if (currentClothPart.vertices.Contains(currVector))
            {
                if (currVector.y < currentClothPart.clothPartCenter.y)
                {
                    //vertices[i] = baseMesh.vertices[i] - Vector3.Distance(currVector, currentClothPart.clothPartCenter) *
                    //    stretchVector * Mathf.Sin(Time.time);
                    vertices[i] = baseMesh.vertices[i] - Vector3.Distance(currVector, currentClothPart.clothPartCenter) *
                    stretchVector * scaleFactor;
                }
            }
            
        }
        
        mesh.vertices = vertices;
    }


    void OnApplicationQuit()
    {
        stretching = false;
        mesh.vertices = baseMesh.vertices;
    }
}
