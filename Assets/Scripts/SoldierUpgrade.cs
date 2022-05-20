using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoldierUpgrade : MonoBehaviour
{
    public Transform soldier;
    public Image cooldown;
    public float waitTime = 3.0f;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI upgradeCost;
    int _upgradeCost;
    bool upgrade;
    public int soldierLvl;


    // Start is called before the first frame update
    void Start()
    {
        upgrade = false;
        soldierLvl = 1;
        _upgradeCost = 10;
        upgradeCost.text = _upgradeCost.ToString()+"$";
    }

    // Update is called once per frame
    void Update()
    { 
        if(upgrade)
        {
            if(_upgradeCost > PlayerMpney.Instance.money)
            {
                upgrade = false;
            }
           else if(cooldown.fillAmount<1 && soldierLvl <5)
            {
              cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
            }
            else if( cooldown.fillAmount>=1)
            {
                soldier.GetChild(soldierLvl).gameObject.SetActive(false);
                soldierLvl++;
                soldier.GetChild(soldierLvl).gameObject.SetActive(true);
                //soldier.GetChild(soldierLvl).gameObject.GetComponent<Animator>().SetBool("Rifle",true);
                soldier.GetChild(soldierLvl).gameObject.GetComponent<Animator>().SetFloat("Speed",1+(0.25f*soldierLvl));
                cooldown.fillAmount = 0;
                PlayerMpney.Instance.money -= _upgradeCost;
                _upgradeCost += 10;
                 upgradeCost.text = _upgradeCost.ToString()+"$";
            }

            else
            {
                cooldown.fillAmount = 0;
                upgrade = false;
            }
        }

        levelText.text = "Lv. "+soldierLvl;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && _upgradeCost <= PlayerMpney.Instance.money)
        {
            upgrade = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            cooldown.fillAmount =0;
            upgrade = false;
        }
    }
}
