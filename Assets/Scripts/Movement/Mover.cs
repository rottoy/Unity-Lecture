using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movement 
{

    public class Mover : MonoBehaviour , IAction
    {
        // Start is called before the first frame update
        // [SerializeField] Transform target;
        // Ray lastRay;
        NavMeshAgent navMeshAgent;
        Health health;
        private void Start()
        {
            health = GetComponent<Health>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        // Update is called once per frame
        void Update()
        {

            navMeshAgent.enabled = !health.isDead();
            
            //Player 에게만 있는 로직이므로 따로 빼서 사용.
            //if (Input.GetMouseButtonDown(0))
            //{
            //    MoveToCursor();       
            //}
            AnimationUpdate();
        }

      
        public void Cancel() 
        {
            navMeshAgent.isStopped = true;
           // print("stopped");
        }

        public void StartMoveAction(Vector3 destination) 
        {
         
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }
        public void MoveTo(Vector3 destination)
        {
          //  print("moving");
           // print(navMeshAgent.isStopped);
            
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
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
}
