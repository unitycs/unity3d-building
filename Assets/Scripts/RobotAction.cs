using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAction : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    public float pushPower = 2.0F;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {
        var controller = GetComponent<CharacterController> ();
        if (controller.isGrounded) {
            moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
            moveDirection = transform.TransformDirection (moveDirection);
            moveDirection *= speed;
            if (Input.GetButton ("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move (moveDirection * Time.deltaTime);
    }

    void OnControllerColliderHit (ControllerColliderHit hit) {
        var body = hit.collider.attachedRigidbody; //没有刚体返回空
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F) //被碰撞物体在它下面
            return;

        Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
}