using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    


    public class PlayerController : MonoBehaviour
    {
        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
        }
        void Update()
        {
            if (health.isDead()) return;

            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
           // print("Nothing to do.");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                //  print(target);
                if (target == null) continue;

                
                if (!GetComponent<Fighter>().CanAttack(target.gameObject)) continue;

                if (Input.GetMouseButtonDown(0)) 
                {

                    //print(target);
                    
                   GetComponent<Fighter>().Attack(target.gameObject);
                    
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
           // print("hi");
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point,1f);
                }
                return true;
            }
            return false;
        }

        /*private void MoveToCursor()
        {
            //param : Ray ray, out RaycastHit HitInfo
            //out : 넣을 때 인자가 빈값이어도 된다는 규정인듯
           
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if (Input.GetMouseButtonDown(0)) 
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                }
               
            }
        }*/

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}