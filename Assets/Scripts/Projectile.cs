using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [HideInInspector] public GameObject parent;
    Transform currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
       if(parent != null)
        {
            if (parent.GetComponent<SoldierAttack1>().currentEnemy != null)
            {
                currentEnemy = parent.GetComponent<SoldierAttack1>().currentEnemy;
            }

            else { Destroy(gameObject); }
        }
    }

    // Update is called once per frame
    void Update()
    {   if(parent!=null)
    {
         if(currentEnemy != null)
        {
            Vector3 target =currentEnemy.transform.position;
            target.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position,target,120f*Time.deltaTime);
        } 
        else if(parent.GetComponent<SoldierAttack1>().currentEnemy == null)
        {
            Destroy(gameObject);
        }
    }
       
       
    }
    void OnTriggerEnter(Collider other)
    {
          if(other.gameObject.CompareTag("Enemy"))
          {
            if(parent.transform.parent.GetChild(6).GetComponent<SoldierUpgrade>().soldierLvl == 4) 
            {
                other.gameObject.GetComponent<EnemyHP>().hp -= 2;
            }
            else 
            {
                other.gameObject.GetComponent<EnemyHP>().hp--;
            }
              Destroy(gameObject);
          } 
    }
}
