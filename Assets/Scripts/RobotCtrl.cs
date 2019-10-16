using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class RobotCtrl : MonoBehaviour {
    public Transform FollowedCamera;
    protected Animator m_Anim;
    CharacterController m_Ctrl;
    public float m_Speed = 5f;

    public GameObject kaifuku;

    public int HeartMax;
    public int HeartNow;
    // Start is called before the first frame update
    void Start () {
        m_Anim = GetComponent<Animator> ();
        m_Ctrl = GetComponent<CharacterController> ();
        HeartMax = 4;
        HeartNow = 3;
    }

    // Update is called once per frame
    void Update () {

        MoveTargetByKeyCode ();
        //MoveTargetByKeyCode2();
    }

    void MoveTargetByKeyCode2 () {

        if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
            Debug.Log ("Move w");
            transform.eulerAngles = new Vector3 (0, 270, 0);
            transform.Translate (Vector3.forward * m_Speed);
        }
        //back
        if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
            Debug.Log ("Move S");
            transform.eulerAngles = new Vector3 (0, 90, 0);
            transform.Translate (Vector3.forward * m_Speed);
        }
        //left
        if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
            Debug.Log ("Move A");
            transform.eulerAngles = new Vector3 (0, 180, 0);
            transform.Translate (Vector3.forward * m_Speed);
        }
        if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
            Debug.Log ("Move D");
            transform.eulerAngles = new Vector3 (0, 0, 0);
            transform.Translate (Vector3.forward * m_Speed);
        }
    }

    void MoveTargetByKeyCode () {

        var h = Input.GetAxis ("Horizontal");
        var v = Input.GetAxis ("Vertical");

        if (h != 0 || v != 0) {
            var mDir = new Vector3 (v * FollowedCamera.transform.forward.x + h * FollowedCamera.transform.right.x,
                0, v * FollowedCamera.transform.forward.z + h * FollowedCamera.transform.right.z);
            Quaternion newRotation = Quaternion.LookRotation (mDir);
            transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, 0.9f);
            m_Ctrl.Move (mDir * Time.deltaTime);
            // m_Anim.SetInteger("Speed", 2);
            m_Anim.Play ("Run");
        } else {
            //m_Anim.SetInteger("Speed", 0);
            m_Anim.Play ("Idle");
        }

    }
}