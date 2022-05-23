using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{   
    public static CharController Instance{get; private set;}
    public Joystick joystick;
    float speed;
    Rigidbody rBody;
    Animator animator;
     [HideInInspector] public bool move;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        move = false;
        rBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.Instance.levelEnded)
        {
             var pos = transform.position;
         pos.z =  Mathf.Clamp(transform.position.z, -11.0f, 11.0f);
          pos.x =  Mathf.Clamp(transform.position.x, -11.0f, 11.0f);
         transform.position = pos;
        speed = 10;
       
             if(joystick.Horizontal >.2f || joystick.Vertical >.2f ||joystick.Horizontal <-.2f || joystick.Vertical <-.2f )
      {
          move = true;
           rBody.velocity = new Vector3(joystick.Horizontal*speed,rBody.velocity.y,joystick.Vertical*speed);
          animator.SetBool("Move",true);
          transform.localRotation = Quaternion.LookRotation(rBody.velocity);
      }
        
      else{animator.SetBool("Move",false);}
        }

        else{
            animator.SetBool("Move",false);
        }

    }
}
