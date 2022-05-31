using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarProjectille : MonoBehaviour
{
    [HideInInspector] public GameObject parent;
    Transform currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        if(parent != null)
        {
            if (parent.GetComponent<SoldierAttack1>().currentEnemy != null) { currentEnemy = parent.GetComponent<SoldierAttack1>().currentEnemy; }
            else { Destroy(gameObject); }
        }
      
    }

    void Update()
    {
        if (parent != null)
        {
            if (currentEnemy != null)
            {
                Vector3 target =currentEnemy.transform.position;
                //target.y = transform.position.y;
                transform.position = Vector3.MoveTowards(transform.position, target, 100f * Time.deltaTime);
                
            }
            else if (parent.GetComponent<SoldierAttack1>().currentEnemy == null)
            {
                Destroy(gameObject);
            }
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHP>().hp-=4;
            Destroy(gameObject);
        }
    }
}
