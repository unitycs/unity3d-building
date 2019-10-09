using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBuilding : MonoBehaviour
{
    public float s;
    bool isMouseDown = false;
    Vector3 pos;
    Vector3 dis;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
