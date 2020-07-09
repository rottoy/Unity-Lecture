using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
   // [SerializeField] Transform target;

    Ray lastRay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();       
        }
        AnimationUpdate();
    }

    private void MoveToCursor()
    {
        //param : Ray ray, out RaycastHit HitInfo
        //out : 넣을 때 인자가 빈값이어도 된다는 규정인듯
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void AnimationUpdate()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity; // 전역 속도를 반환함
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); // 플레이어가 움직일 로컬 속도를 반환함
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed); //blend 변수 설정

    }
   // lastRay = 

   // GetComponent<NavMeshAgent>().destination = target.position;
}
