using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float r = 4f;

    public float mouseSpeed = 6.0f;
    public float wheelSpeed = 0.1f;

    public Vector3 offset = new Vector3(0, 1, 0);

    public float lat = 0; //latitude
    public float lon = 0; //longitude

    void Update()
    {

        float dr = r * Input.mouseScrollDelta.y * wheelSpeed;
        if (r - dr > 1f)
            r -= dr;

        if (Input.GetKey(KeyCode.Mouse1) || Input.mouseScrollDelta.y != 0)
        {
            float dlat = mouseSpeed * Input.GetAxis("Mouse Y");
            float dlon = mouseSpeed * Input.GetAxis("Mouse X");

            if (lat + dlat < 88 && lat + dlat > -88)
                lat += dlat;

            lon += dlon;

            updateCamera();
        }
    }

    public void updateCamera()
    {
        Vector3 equatorPosition = Quaternion.AngleAxis(lon, Vector3.up) * Vector3.forward;

        Vector3 right = Vector3.Cross(Vector3.up, equatorPosition);

        Vector3 pos = Quaternion.AngleAxis(lat, right) * equatorPosition * r + offset;

        transform.position = pos;
        transform.LookAt(Vector3.zero + offset, Vector3.up);
    }

    public void setPosition(float r, float lat, float lon)
    {
        this.r = r;
        this.lat = lat;
        this.lon = lon;

        updateCamera();
    }
}
