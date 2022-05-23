using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpNpc : MonoBehaviour
{
    public int hp;
    public Slider hpSlider;

      Animator animator;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
         //isDead = false;
        //hp = 3;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.GetChild(5).LookAt(Camera.main.transform);
        hpSlider.value = hp;
        if(hp<=0 && !isDead)
        {
            transform.parent.GetComponent<UnlockSoldier>().WhenDead();
            GetComponent<BoxCollider>().enabled = false;
            gameObject.SetActive(false);
            //animator.SetBool("Death",true);
            isDead = true;
        }
    }

    void OnEnable()
    {
        isDead = false;
        hp = 3;
    }
}
