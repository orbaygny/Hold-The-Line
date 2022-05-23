using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    NavMeshAgent agent;
    float distance;
    Animator animator;
    Vector3 destination;

    [HideInInspector] public Transform target;
    public GameObject AiSpawner;
   
    // Start is called before the first frame update
    void Start()
    {   animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(CharController.Instance.transform.position);
        
        destination = agent.destination;
    }

    // Update is called once per frame
    void Update()
    {  
        if(!GameManager.Instance.levelEnded)
        {
            if(PlayerHp.Instance.isDead){BreakRoute();}
        
        if(agent.enabled)
        {
            target = AiSpawner.GetComponent<EnemyTargetPicker>().currentTarget;
            distance = Vector3.Distance(transform.position,target.position);
            destination = target.position;
            agent.destination = destination;
        //agent.SetDestination(CharController.Instance.transform.position);
        transform.GetChild(5).LookAt(Camera.main.transform);

        if(distance<= agent.stoppingDistance)
        {
            animator.SetBool("Attack",true);
        }
        else if(distance > agent.stoppingDistance)
        {
            animator.SetBool("Attack",false);
        }
        }
        }
        else
        {
             animator.SetBool("Attack",false);
             BreakRoute();
            animator.SetBool("Stop",true);
        }
        
    }

    public void BreakRoute()
    {
        if(agent.enabled)
        {
            agent.isStopped = true;
        agent.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        }
    }
}
