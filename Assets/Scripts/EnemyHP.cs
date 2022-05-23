using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public int hp;
    Animator animator;
    public bool isDead;
    public Slider hpSlider;

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
        hpSlider.value = hp;
        if(hp<=0 && !isDead)
        {
            animator.SetBool("Death",true);
            GetComponent<AIMove>().BreakRoute();
            PlayerMpney.Instance.money += 5;
            isDead = true;
        }
    }

}
