using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 resetCamera;
    private bool drag = false;

    // Start is called before the first frame update
    private void Start()
    {
        resetCamera = Camera.main.transform.position;
         
    }

    private void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Vector3 newPos = origin - difference;
            newPos.y = 10;

            Camera.main.transform.position = newPos;

            // TODO fix this to restrict drag area
            //Camera.main.transform.position = new Vector3(
            //Mathf.Clamp(Camera.main.transform.position.x, -1, 4),
            //Mathf.Clamp(Camera.main.transform.position.y, 0, 0), transform.position.z);
        }

        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = resetCamera;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
