using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RobotAutoCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit hit;
            if(Physics.Raycast(ray,out RaycastHit hit)){

                agent.SetDestination(hit.point);

            }
        }
    }
}
