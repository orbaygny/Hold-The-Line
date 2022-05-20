using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{
    Animator animator;
    public Transform currentSoldier;
    public Transform currentEnemy;
    GameObject lvlParent;
    // Start is called before the first frame update
    void Start()
    {
      
        animator = transform.GetChild(lvlParent.GetComponent<SoldierUpgrade>().soldierLvl).gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        currentSoldier = transform.GetChild(lvlParent.GetComponent<SoldierUpgrade>().soldierLvl);
        animator = transform.GetChild(lvlParent.GetComponent<SoldierUpgrade>().soldierLvl).gameObject.GetComponent<Animator>();
        if(currentEnemy != null)
        {
            animator.SetBool("Shoot",true);
            currentSoldier.LookAt(currentEnemy);
        }
        else
        {
            animator.SetBool("Shoot",false);
        }
    }
}
