using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockSoldier : MonoBehaviour
{
    bool unlock;
    public Image cooldown;
    public GameObject fillParent;
    public float waitTime = 3.0f;
    public TextMeshProUGUI unlockCost; 
    public int _unlockCost;
    // Start is called before the first frame update
    void Start()
    {
        unlock = false;
        _unlockCost = 10*UnlocCost.Instance.unlockCount;
        unlockCost.text = _unlockCost.ToString()+"$";
    }

    // Update is called once per frame
    void Update()
    {
        _unlockCost = 10*UnlocCost.Instance.unlockCount;
        unlockCost.text = _unlockCost.ToString()+"$";
        if(unlock)
        {   
            
            if(_unlockCost > PlayerMpney.Instance.money)
            {
                unlock = false;
            }
            if(cooldown.fillAmount<1)
            {
              cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
            }
            
         else if( cooldown.fillAmount>=1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(true);
                transform.GetChild(7).gameObject.SetActive(true);
               // transform.GetChild(8).gameObject.SetActive(true);
                fillParent.SetActive(false);
                cooldown.fillAmount = 0;
                GetComponent<BoxCollider>().enabled = false;
                UnlocCost.Instance.Increase();
                unlock = false;

            }

        /*else{
            cooldown.fillAmount = 0;
            unlock = false;
            }*/
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            unlock = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            cooldown.fillAmount =0;
            unlock = false;
        }
    }
}