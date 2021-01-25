using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class SingleCloth : MonoBehaviour
{

    public Dictionary<string,List<ClothPart.ClothPartData>> clothPoolData = new Dictionary<string, List<ClothPart.ClothPartData>>();
    public Mesh mesh;
    public Mesh baseMesh;
    bool stretching = true;
    Vector3[] vertices;
    ClothPart.ClothPartData currentClothPart;
    public string currentClothName;

    public MeshFilter _meshFilter;
    public SkinnedMeshRenderer _skinnedMeshRenderer;

    void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    

    public void SetupClothParts(string clothName)
    {
        _meshFilter.sharedMesh = baseMesh;
        _skinnedMeshRenderer.sharedMesh = baseMesh;
        mesh = (Mesh) Instantiate(_meshFilter.sharedMesh);

        if (!clothPoolData.ContainsKey(clothName))
        {
            int children = transform.childCount;
            List<ClothPart.ClothPartData> list = new List<ClothPart.ClothPartData>();
            for (int i = 0; i < children; ++i)
            {
                ClothPart clothPart = transform.GetChild(i).gameObject.AddComponent<ClothPart>();
                clothPart.markVertecies(mesh, baseMesh);
                var data = clothPart.getData();
                list.Add(data);
                
            }
            clothPoolData.Add(clothName, list);
        }
        currentClothName = clothName;
    }

    public void changeClothPart(int index)
    {
        currentClothPart = clothPoolData[currentClothName][index];
    }

    public void lengthenClothPart(float scaleFactor, bool downScaleButton)
    {
        vertices = baseMesh.vertices;
        Vector3 stretchVector = currentClothPart.stretchAxis;

        for (var i = 0; i < vertices.Length; i++)
        {
            Vector3 currVector = mesh.vertices[i];
            
            if (currentClothPart.vertices.Contains(currVector))
            {
                if (downScaleButton)
                {
                    if (currVector.y <= currentClothPart.borderPoint.y)
                    {
                        vertices[i] = mesh.vertices[i] + Vector3.Distance(currVector, currentClothPart.borderPoint) *
                            stretchVector * scaleFactor;
                    }
                }
                else
                {
                    if (currVector.y >= currentClothPart.borderPoint.y)
                    {
                        vertices[i] = mesh.vertices[i] + Vector3.Distance(currVector, currentClothPart.borderPoint) *
                            stretchVector * scaleFactor;
                    }
                }
            }
        }

        baseMesh.vertices = vertices;
    }


    void OnApplicationQuit()
    {
        baseMesh.vertices = mesh.vertices;
    }
}
