using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl2 : MonoBehaviour
{
    public float zoomChange;
    public float smoothChange;
    public float minSize, maxSize;

    private Camera cam;
    private bool zoomedIn;

    public float zoomTo = 30;



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

        if (Input.GetMouseButtonDown(0))
        {
            if (zoomedIn)
            {
                zoomTo = 30;
                zoomedIn = false;
            }
            else
            {
                zoomTo = 10;
                zoomedIn = true;
            }

            
        }
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomTo, 5f * Time.deltaTime);



    }
}