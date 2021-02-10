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
    public static SingleCloth currentTop;
    public static SingleCloth currentBottom;

    public static Dictionary<string, int> top2ix = new Dictionary<string, int>();
    public static Dictionary<string, int> bottom2ix = new Dictionary<string, int>();

    public static GameObject objWithNewParts;

    void Start()
    {
        currentTop = topHolder.transform.GetChild(0).GetComponent<SingleCloth>();
        currentBottom = bottomHolder.transform.GetChild(0).GetComponent<SingleCloth>();
        SetupNewCloth(currentTop, topSingleCloths, 0);
        SetupNewCloth(currentBottom, bottomSingleCloths, 0);

        int i = 0;
        foreach (Transform child in topSingleCloths.transform)
        {
            //Debug.Log("TOPIX: " + child.gameObject.name );
            top2ix[child.gameObject.name] = i++;
        }

        i = 0;
        foreach (Transform child in bottomSingleCloths.transform)
        {
            bottom2ix[child.gameObject.name] = i++;
        }

       //Debug.Log("TOPIX: " + Serialize(top2ix.ToList()));
        //Debug.Log("BOTIX: " + Serialize(bottom2ix.ToList()));
    }
    
    public void changeTop(int index)
    {
        SetupNewCloth(currentTop, topSingleCloths, index);
    }
    
    public void changeBottom(int index)
    {
        SetupNewCloth(currentBottom, bottomSingleCloths, index);
    }

    private static void SetupNewCloth(SingleCloth singleCloth, GameObject singleCloths, int index)
    {   
        if(singleCloth.baseMesh != null)
            singleCloth.baseMesh.vertices = singleCloth.mesh.vertices;
        
        objWithNewParts = singleCloths.transform.GetChild(index).gameObject;

        ClothPool.RelaseCloth(singleCloth.currentClothName);
        ClothPool.ClothPartFullData clothData = ClothPool.Acquire(objWithNewParts.name);

        singleCloth.SetupMesh(objWithNewParts.name, clothData);
    }
}
