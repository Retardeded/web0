using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClothManager : MonoBehaviour
{
    [SerializeField] public GameObject topSingleCloths;
    [SerializeField] public GameObject bottomSingleCloths;
    
    [SerializeField] private GameObject topHolder;
    [SerializeField] private GameObject bottomHolder;
    private SingleCloth currentTop;
    private SingleCloth currentBottom;

    void Start()
    {
        currentTop = topHolder.transform.GetChild(0).GetComponent<SingleCloth>();
        currentBottom = bottomHolder.transform.GetChild(0).GetComponent<SingleCloth>();
        SetupNewCloth(currentTop, topSingleCloths, 0);
        SetupNewCloth(currentBottom, bottomSingleCloths, 0);
    }
    
    public void changeTop(int index)
    {
        SetupNewCloth(currentTop, topSingleCloths, index);
    }
    
    public void changeBottom(int index)
    {
        SetupNewCloth(currentBottom, bottomSingleCloths, index);
    }

    private void SetupNewCloth(SingleCloth singleCloth, GameObject singleCloths, int index)
    {
        
        for (var i = singleCloth.transform.childCount - 1; i >= 0; i--)
        {
            var child = singleCloth.transform.GetChild(i);
            child.transform.parent = null;
            Destroy(child.gameObject);
        }

        GameObject objWithNewParts = singleCloths.transform.GetChild(index).gameObject;

        for (var i = objWithNewParts.transform.childCount - 1; i >= 0; i--)
        {
            var child = objWithNewParts.transform.GetChild(i);
            child.transform.parent = singleCloth.transform;
        }
        
        if(singleCloth.mesh != null)
            singleCloth.baseMesh.vertices = singleCloth.mesh.vertices;

        MeshFilter meshFilter = objWithNewParts.GetComponent<MeshFilter>();
        singleCloth.baseMesh = meshFilter.mesh;
        singleCloth.SetupClothParts(objWithNewParts.name);
    }
}
