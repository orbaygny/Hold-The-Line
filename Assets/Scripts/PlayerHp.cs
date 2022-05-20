using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp Instance {get; private set;}
    public int hp;
    public Slider hpSlider;

      Animator animator;
    public bool isDead;

    

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
         isDead = false;
        hp = 3;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(6).LookAt(Camera.main.transform);
        hpSlider.value = hp;
        if(hp<=0 && !isDead)
        {
            animator.SetBool("Death",true);
            isDead = true;
        }
    }
}
