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
        hp = 4 + 2* (PlayerPrefs.GetInt("Level", 0));
        hpSlider.maxValue = hp;
        hpSlider.value = hp;
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
            GetComponent<AIMove>().BreakRoute();
            PlayerMpney.Instance.money += 2 * (PlayerPrefs.GetInt("Level", 0)+1); 
            isDead = true;
        }
    }

}
