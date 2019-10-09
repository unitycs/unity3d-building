using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCampus : MonoBehaviour
{

    private float speed = 4;
    bool isMouseDown = false;
    // Start is called before the first frame update
    Vector3 pos;
    Vector3 dis;
    float s = 0.5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //    var v = Input.GetAxis("Mouse Y") * speed;
        //     var h = Input.GetAxis("Mouse X") * speed;
            
        //     transform.localEulerAngles +=new Vector3(v,h,0);
        // }
        if (Input.GetMouseButtonDown(0))
        {
            pos = Input.mousePosition;
            isMouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        if (isMouseDown)
        {
            dis = Input.mousePosition - pos;
            transform.Rotate(0, -dis.x * s, dis.y * s, Space.World);
            pos = Input.mousePosition;
        }


    }
}
