using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (Animator))]
public class RobotAutoNav : MonoBehaviour {

    protected NavMeshAgent agent;
    public Transform FollowedCamera;
    protected Animator m_Anim;
    CharacterController m_Ctrl;
    // public float m_Speed = 0.1f;

    // Start is called before the first frame update
    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        m_Anim = GetComponent<Animator> ();
        m_Ctrl = GetComponent<CharacterController> ();

        // agent.updatePosition = false; // Don’t update position automatically
        //  HeartMax = 4;
        //  HeartNow = 3;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown (0)) {
            MoveToTargetByNavMesh (1);

        } else if (Input.GetMouseButtonDown (1)) {
            MoveToTargetByNavMesh (2);
        }


    }


    void MoveToTargetByNavMesh (int speed) {

        var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        //    RaycastHit hit;

        if (Physics.Raycast (ray, out RaycastHit hit)) {
            agent.SetDestination (hit.point);
            //judge goal
            var distance = agent.transform.position - hit.point;
            if (distance.magnitude < 1) {
                //m_Anim.SetInteger("Speed", 0);
                m_Anim.Play ("Idle");
            }
        }

    }
}