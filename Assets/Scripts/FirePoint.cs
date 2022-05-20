using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public  GameObject projectile;
    public static bool _fire;
    public GameObject parent;
    public GameObject ammoPlace;
    // Start is called before the first frame update
    void Start()
    {
        _fire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_fire )
        {
            Fire();
            _fire = false;
        }
    }

    public void Fire()
    {
        if(ammoPlace.GetComponent<GiveSoldierAmmo>().ammoCount>0)
        {
            GameObject tmp = Instantiate(projectile,transform.position,projectile.transform.rotation);
            tmp.GetComponent<Projectile>().parent = parent;
        }
      
    }
    
}
