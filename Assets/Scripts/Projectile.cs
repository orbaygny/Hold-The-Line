using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [HideInInspector] public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(parent!=null)
    {
         if(parent.GetComponent<SoldierAttack1>().currentEnemy != null)
        {
            Vector3 target = parent.GetComponent<SoldierAttack1>().currentEnemy.transform.position;
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
              other.gameObject.GetComponent<EnemyHP>().hp--;
              Destroy(gameObject);
          } 
    }
}
