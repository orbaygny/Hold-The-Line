using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElephantSDK;

public class CharController : MonoBehaviour
{   
    public static CharController Instance{get; private set;}
    public Joystick joystick;
    float speed;
    Rigidbody rBody;
    Animator animator;
     [HideInInspector] public bool move;

    bool started;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        started = true;
        move = false;
        rBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (started)
        {
            if (Input.GetMouseButton(0))
            {
                Elephant.LevelStarted((PlayerPrefs.GetInt("Level", 1) + 1));
                Debug.Log("Baþladý");
                started = false;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!GameManager.Instance.levelEnded)
        {
             var pos = transform.position;
         pos.z =  Mathf.Clamp(transform.position.z, -0.5f, 12.0f);
          pos.x =  Mathf.Clamp(transform.position.x, -12.8f, 12.8f);
         transform.position = pos;
        speed = 10;
       
             if(joystick.Horizontal >.2f || joystick.Vertical >.2f ||joystick.Horizontal <-.2f || joystick.Vertical <-.2f )
      {
          move = true;
               
                rBody.velocity = new Vector3(joystick.Horizontal*speed,rBody.velocity.y,joystick.Vertical*speed);
          animator.SetBool("Move",true);
          transform.localRotation = Quaternion.LookRotation(rBody.velocity);
      }
        
      else{animator.SetBool("Move",false); rBody.velocity = Vector3.zero; }
        }

        else{
            rBody.velocity = Vector3.zero;
            animator.SetBool("Move",false);
            animator.SetBool("Attack",false);
        }

    }
}
