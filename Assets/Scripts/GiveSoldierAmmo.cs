using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GiveSoldierAmmo : MonoBehaviour
{
    public Transform soldier;
    public Transform upgradeCol;
    public Image cooldown;
    public float waitTime =0.000000001f;
    public TextMeshProUGUI ammoText;
    bool giveAmmo;
    public int ammoCount;
    // Start is called before the first frame update
    void Start()
    {
        giveAmmo = false;
        ammoCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(giveAmmo)
        {
            if(PlayerAmmo.Instance.currentAmmo<=0 || ammoCount== 10 )
            {
                giveAmmo = false;
            }
            else if(cooldown.fillAmount<1)
            {
              cooldown.fillAmount += 1f * Time.deltaTime;
            }
            else if( cooldown.fillAmount>=1)
            {
                
                PlayerAmmo.Instance.currentAmmo--;
                PlayerAmmo.Instance.ammoParent.GetChild(PlayerAmmo.Instance.currentAmmo).gameObject.GetComponent<BulletStart>().Jump(soldier.GetChild(upgradeCol.GetComponent<SoldierUpgrade>().soldierLvl).position);
                ammoCount+=5;
                cooldown.fillAmount = 0;
            }
        }
        if(ammoCount>10){ammoCount = 10;}
        ammoText.text = ammoCount+"/10";
    }

      void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && PlayerAmmo.Instance.currentAmmo > 0 && ammoCount <10)
        {
            giveAmmo = true;
        }
    }

        void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && PlayerAmmo.Instance.currentAmmo > 0 && ammoCount <10)
        {
            giveAmmo = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            cooldown.fillAmount =0;
            giveAmmo = false;
        }
    }

    void OnEnable()
    {
        giveAmmo = false;
        ammoCount = 10;
    }
}
