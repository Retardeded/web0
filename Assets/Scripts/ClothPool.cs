using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

using UnityEngine;

public class ClothPool : MonoBehaviour
{
    private static int maxPoolSize = 5;

    private static Dictionary<string, ClothPartFullData> clothPoolData = new Dictionary<string, ClothPartFullData>();
    private static List<string> locked = new List<string>();
    private static List<string> unlocked = new List<string>();

    public static ClothPartFullData Acquire(string name)
    {

        if (clothPoolData.ContainsKey(name))
        {
            Debug.Log("Data/MeshReUse");
            return clothPoolData[name];
        }
        else
        {
            if(locked.Count == maxPoolSize)
            {
                throw new Exception("Can't acquire because ClothPool is full");
            }

            if(clothPoolData.Count == maxPoolSize)
            {
                freeCloth(unlocked[0]); 
            }

            ClothPartFullData newCloth = initCloth(name);

            clothPoolData.Add(name, newCloth);
            locked.Add(name);

            Debug.Log("poolUP :" + clothPoolData.Count + "name::" + name);

            /*Debug.Log("ClothData: " + clothPoolData.Count);
            Debug.Log("locked: " + locked.Count + " : " + string.Join(",", locked.ToArray()));
            Debug.Log("unlocked: " + unlocked.Count + " : " + string.Join(",", unlocked.ToArray()));*/

            return newCloth;
        }
    }

    public static void RelaseCloth(string name)
    {
        if (clothPoolData.ContainsKey(name))
        {
            string exists = locked.FirstOrDefault(x => x == name);

            if (exists != null)
            {
                locked.Remove(name);
                unlocked.Add(name);
            }
        }
    }

    private static void freeCloth(string name)
    {
        Debug.Log("CacheRemoval");

        unlocked.Remove(name);
        clothPoolData.Remove(name);

        Debug.Log("poolDOWN :" + clothPoolData.Count + "name::" + name);
    }

    private static ClothPartFullData initCloth(string name)
    {
        Mesh meshToReturn = Resources.Load<Mesh>(name);
        Debug.Log("loadMesh: " + name);

        int children = ClothManager.objWithNewParts.transform.childCount;
        List<ClothPart.ClothPartData> list = new List<ClothPart.ClothPartData>();
        for (int i = 0; i < children; ++i)
        {
            ClothPart clothPart = ClothManager.objWithNewParts.transform.GetChild(i).gameObject.AddComponent<ClothPart>();
            clothPart.markVertecies(meshToReturn);
            var data = clothPart.getData();
            list.Add(data);
            Destroy(clothPart);
        }
        ClothPartFullData fullData = new ClothPartFullData(meshToReturn, list);
        return fullData;
    }

    public struct ClothPartFullData
    {
        public List<ClothPart.ClothPartData> list;
        public Mesh mesh;
        public ClothPartFullData(Mesh mesh, List<ClothPart.ClothPartData> list)
        {
            this.mesh = mesh;
            this.list = list;
        }
    }
}
