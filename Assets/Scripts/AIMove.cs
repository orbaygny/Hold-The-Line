using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    NavMeshAgent agent;
    float distance;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {   animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(CharController.Instance.transform.position);
    }

    // Update is called once per frame
    void Update()
    {   
        if(PlayerHp.Instance.isDead){BreakRoute();}
        
        if(agent.enabled)
        {
            distance = Vector3.Distance(transform.position,CharController.Instance.transform.position);
        agent.SetDestination(CharController.Instance.transform.position);
        transform.GetChild(5).LookAt(Camera.main.transform);

        if(distance<= agent.stoppingDistance)
        {
            animator.SetBool("Attack",true);
        }
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
