using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothPart : MonoBehaviour
{
    // Start is called before the first frame update
    Collider m_Collider;
    private ClothPartData data;
    [SerializeField] private Vector3 stretchAxis;

    public struct ClothPartData {
        //Variable declaration
        //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
        public Vector3 clothPartCenter;
        public Vector3 stretchAxis;
        public List<Vector3> vertices;
   
        //Constructor (not necessary, but helpful)
        public ClothPartData(Vector3 stretchAxis, Vector3 clothPartCenter, List<Vector3> vertices)
        {
            this.clothPartCenter = clothPartCenter;
            this.stretchAxis = stretchAxis;
            this.vertices = vertices;
        }
    }

    public void markVertecies(Mesh baseMesh, Mesh mesh)
    {
        //Vector3 stretchAxis = transform.rotation.eulerAngles;
        //stretchAxis = new Vector3(-1f, 1f,0f);

        //Debug.Log("stretch" + stretchAxis);

        Vector3 clothPartCenter = transform.position;
        //Debug.Log(clothPartCenter);

        m_Collider = GetComponent<BoxCollider>();
        List<Vector3> vertices = new List<Vector3>();

        for (var i = 0; i < baseMesh.vertices.Length; i++)
        {
            if (m_Collider.bounds.Contains(baseMesh.vertices[i]))
                vertices.Add(baseMesh.vertices[i]);
        }
        data = new ClothPartData(stretchAxis, clothPartCenter, vertices);
    }

    public ClothPartData getData()
    {
        return data;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
