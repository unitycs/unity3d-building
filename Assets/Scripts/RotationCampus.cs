using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCampus : MonoBehaviour
{

    private float x;
    private float speed = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            x = Input.GetAxis("Mouse Y") * speed;
            transform.localEulerAngles +=new Vector3(x,0,0);
        }

    }
}
