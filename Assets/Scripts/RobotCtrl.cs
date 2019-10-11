using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class RobotCtrl : MonoBehaviour {
    public Transform FollowedCamera;
    protected Animator m_Anim;
    CharacterController m_Ctrl;
    public float m_Speed = 10f;

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
        if (Input.GetKey (KeyCode.W)) {
            Debug.Log ("Move w");
            transform.Translate (Vector3.forward * m_Speed);
        }
        if (Input.GetKey (KeyCode.A)) {
            Debug.Log ("Move A");
            transform.Translate (Vector3.left * m_Speed);
        }
        if (Input.GetKey (KeyCode.S)) {
            Debug.Log ("Move S");
            transform.Translate (Vector3.back * m_Speed);
        }
        if (Input.GetKey (KeyCode.D)) {
            Debug.Log ("Move D");
            transform.Translate (Vector3.right * m_Speed);
        }

        //上
        if (Input.GetKey (KeyCode.UpArrow)) {
            transform.eulerAngles = new Vector3 (0, 270, 0);
            transform.position += transform.forward * m_Speed;
        }
        //下
        else if (Input.GetKey (KeyCode.DownArrow)) {
            transform.eulerAngles = new Vector3 (0, 180, 0);
            transform.position += transform.forward * m_Speed;
        }
        //左
        else if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.eulerAngles = new Vector3 (0, 270, 0);
            transform.position += transform.forward * m_Speed;
        }
        //右
        else if (Input.GetKey (KeyCode.RightArrow)) {
            transform.eulerAngles = new Vector3 (0, 90, 0);
            transform.position += transform.forward * m_Speed;
        }
    }
}