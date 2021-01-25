using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothPart : MonoBehaviour
{
    Collider m_Collider;
    private ClothPartData data;
    
    public struct ClothPartData {
        public Vector3 borderPoint;
        public Vector3 stretchAxis;
        public List<Vector3> vertices;
        
        public ClothPartData(Vector3 stretchAxis, Vector3 borderPoint, List<Vector3> vertices)
        {
            this.borderPoint = borderPoint;
            this.stretchAxis = stretchAxis.normalized;
            this.vertices = vertices;
        }
    }

    public void markVertecies(Mesh baseMesh, Mesh mesh)
    {
        Vector3 borderPoint = Vector3.zero;
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            borderPoint = transform.GetChild(i).gameObject.transform.position;
        }

        Vector3 stretchAxis = transform.position - borderPoint;
        
        m_Collider = GetComponent<BoxCollider>();
        List<Vector3> vertices = new List<Vector3>();

        for (var i = 0; i < baseMesh.vertices.Length; i++)
        {
            if (m_Collider.bounds.Contains(baseMesh.vertices[i]))
                vertices.Add(baseMesh.vertices[i]);
        }
        data = new ClothPartData(stretchAxis, borderPoint, vertices);
    }

    public ClothPartData getData()
    {
        return data;
    }
}
