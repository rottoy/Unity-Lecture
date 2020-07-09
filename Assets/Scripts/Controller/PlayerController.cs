using RPG.Combat;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
              //  print(target);
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0)) 
                {

                   print(target);
                   GetComponent<Fighter>().Attack(target);
                }
            }
        }

        private void InteractWithMovement()
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
           
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}