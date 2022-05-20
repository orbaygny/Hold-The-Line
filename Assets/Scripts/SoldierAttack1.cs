using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack1 : MonoBehaviour
{
    public GameObject aimCol;
    public Transform currentEnemy;
    Animator animator;
    public GameObject ammoCount;
    int _ammoCount;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _ammoCount = ammoCount.GetComponent<GiveSoldierAmmo>().ammoCount;
        if(aimCol.GetComponent<PickEnemy>().currentEnemy != null)
        {
            currentEnemy = aimCol.GetComponent<PickEnemy>().currentEnemy;
        }

        if(currentEnemy != null && _ammoCount>0 )
        {
            animator.SetBool("Shoot",true);
            transform.LookAt(currentEnemy);
        }

        if(aimCol.GetComponent<PickEnemy>().currentEnemy == null || _ammoCount == 0)
        {
            currentEnemy = null;
            animator.SetBool("Shoot",false);
            
        }
    }
}
