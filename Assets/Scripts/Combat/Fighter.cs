using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{ 
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

       
        
        Transform target;
        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRamge())
            {
               // print("hi");
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool GetIsInRamge()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel() 
        {
            target = null;
        }
    }
}