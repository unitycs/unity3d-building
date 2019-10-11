using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{

    public Transform Robot;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Robot.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Robot.position + offset;
    }
}
