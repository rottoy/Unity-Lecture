﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{

   
    public class Health : MonoBehaviour
    {

        [SerializeField] float health = 100f;
        bool isDeath = false;


        public bool isDead() 
        {
            return isDeath;
        }
        public void TakeDamage(float damage) 
        {
           
            health =Mathf.Max(health - damage,0);
            print(health);
            if (health == 0 )
            {
        
                Die();
            }
        }

        private void Die()
        {
            if (isDeath) return;
            isDeath = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }

}