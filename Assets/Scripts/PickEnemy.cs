using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickEnemy : MonoBehaviour
{
    int pointer = 0;
   public GameObject enemies;
    public Transform currentEnemy;

    void Start()
    {
        
    }

    void Update()
    {
        
      if(enemies.transform.GetChild(pointer).gameObject.activeSelf)
      {
          if(enemies.transform.GetChild(pointer).GetComponent<EnemyHP>().isDead)
          {
              pointer++;
              
          }
          else
          {
              currentEnemy = enemies.transform.GetChild(pointer);
          }
      }
    }
    void OnTriggerEnter(Collider other)
    {
        /*if(other.gameObject.CompareTag("Enemy") && currentEnemy == null)
        {
            currentEnemy = other.transform;
        }*/
    }

    void OnTriggerExit(Collider other)
    {
       /* if(other.transform == currentEnemy)
        {
            currentEnemy = null;
        }*/
    }
}
