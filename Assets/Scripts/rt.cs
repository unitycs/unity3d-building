using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rt : MonoBehaviour
{
    public float s;
    bool md;
    Vector3 pos;
    Vector3 dis;
    void Start()
    {
        md = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pos = Input.mousePosition;
            md = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            md = false;
        }

        if(md)
        {
            dis = Input.mousePosition - pos;
            transform.Rotate(0,-dis.x*s,dis.y*s,Space.World);
            pos = Input.mousePosition;
        }
    }


}
