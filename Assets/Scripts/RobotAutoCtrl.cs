using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (Animator))]
public class RobotAutoCtrl : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform FollowedCamera;
    protected Animator m_Anim;
    CharacterController m_Ctrl;
    public float m_Speed = 0.1f;

    // Start is called before the first frame update
    void Start () {
        m_Anim = GetComponent<Animator> ();
        m_Ctrl = GetComponent<CharacterController> ();
        //  HeartMax = 4;
        //  HeartNow = 3;
    }

    // Update is called once per frame
    void Update () {

        var h = Input.GetAxis ("Horizontal");
        var v = Input.GetAxis ("Vertical");

        if (h != 0 || v != 0) {
            var mDir = new Vector3 (v * FollowedCamera.transform.forward.x + h * FollowedCamera.transform.right.x,
                0, v * FollowedCamera.transform.forward.z + h * FollowedCamera.transform.right.z);
            Quaternion newRotation = Quaternion.LookRotation (mDir);
            transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, 0.9f);

            m_Ctrl.Move (mDir * Time.deltaTime);
            if (!m_Anim.GetBool ("Run")) m_Anim.SetBool ("Run", true);
        } else {
            if (m_Anim.GetBool ("Run")) m_Anim.SetBool ("Run", false);
        }

        if (Input.GetMouseButtonDown (0)) {
            var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            //    RaycastHit hit;
            if (Physics.Raycast (ray, out RaycastHit hit)) {

                agent.SetDestination (hit.point);
            }
        }
    }
}