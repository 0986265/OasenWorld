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

    private bool zoomEnabled = true;

    public static ZoomControl2 instance;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 150;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.rotation.x >= 0)
        { // rotates down
            Debug.Log("limit down");
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.rotation.x <= 0.2716)
        { // rotates up
            transform.Rotate(-Vector3.left * speed * Time.deltaTime);
            Debug.Log("limit up");
        }

        // Debug.Log(transform.rotation.x);

        if (Input.GetMouseButtonDown(0) && zoomEnabled)
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

    public void ZoomChange(bool enabledBool)
    {
        zoomEnabled = enabledBool;
    }
}
