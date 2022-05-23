using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTake : MonoBehaviour
{
    bool giveAmmo;
    int maxAmmo;

    public Image cooldown;
      float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(giveAmmo)
        {   
            if(PlayerAmmo.Instance.currentAmmo==PlayerAmmo.Instance.maxAmmo)
            {   
                giveAmmo = false;
            }
           else if(cooldown.fillAmount<1)
            {
              cooldown.fillAmount += 1.0f/waitTime * Time.deltaTime;
            }
            
         else if(PlayerAmmo.Instance.currentAmmo<PlayerAmmo.Instance.maxAmmo && cooldown.fillAmount>=1)
            {
                PlayerAmmo.Instance.ammoParent.GetChild(PlayerAmmo.Instance.currentAmmo).gameObject.SetActive(true);
                PlayerAmmo.Instance.currentAmmo++;
                cooldown.fillAmount = 0;
            }

        else{
            cooldown.fillAmount = 0;
            giveAmmo = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           if(PlayerAmmo.Instance.currentAmmo<PlayerAmmo.Instance.maxAmmo)
           {
                giveAmmo = true;
           }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            giveAmmo = false;
            cooldown.fillAmount =0;
        }
    }
}
