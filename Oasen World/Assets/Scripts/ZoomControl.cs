using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    public float zoomChange;
    public float smoothChange;
    public float minSize, maxSize;

    private Camera cam;



    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
            cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        if (Input.mouseScrollDelta.y < 0)
            cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);

    }

    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            GameObject.Find("Main Camera").transform.rotation = new Quaternion(0, 45, 0, 0);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            GameObject.Find("Main Camera").transform.rotation = new Quaternion(0, 100, 0, 0);
        }
    }
}
