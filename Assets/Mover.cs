using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;

    Ray lastRay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();       
        }
      
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
   // lastRay = 

   // GetComponent<NavMeshAgent>().destination = target.position;
}
