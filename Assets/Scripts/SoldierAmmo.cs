using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAmmo : MonoBehaviour
{
   public GameObject ammoPlace;
   int fireCount;
    // Start is called before the first frame update
    void Start()
    {
        fireCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(FirePoint._fire && ammoPlace.GetComponent<GiveSoldierAmmo>().ammoCount>0)
        {
            if(fireCount<3)
            {
                fireCount++;
            }
           else if(fireCount == 3)
            {
             ammoPlace.GetComponent<GiveSoldierAmmo>().ammoCount--;
             fireCount = 0;
            }
            
        }
    }
}
