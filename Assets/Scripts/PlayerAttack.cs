using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance {get; private set;}
    public GameObject knife;
     Vector3 center;
    float radius;
    public Transform currentTarget;
    Animator animator;
    [HideInInspector]public bool attack;
    void Awake()
    {
        Instance = this;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        radius = 2f;
         attack = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        center = transform.position;
        if(!GameManager.Instance.levelEnded)
         {
             Collider[] hitColliders = Physics.OverlapSphere(center, radius,1<<7);
         if(hitColliders.Length > 0)
         {
             attack = true;
              animator.SetBool("Attack",true);
             knife.SetActive(true);
             currentTarget = hitColliders[0].transform;
             //transform.LookAt(currentTarget);
         }
         if(hitColliders.Length == 0)
         {
             attack = false;
            animator.SetBool("Attack",false);
             knife.SetActive(false);
             currentTarget = null;
         }
         }
         else
         {
             currentTarget = null;
         }
    }

     private void OnDrawGizmosSelected() {
     Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere (transform.position, 2f);
 }
}
