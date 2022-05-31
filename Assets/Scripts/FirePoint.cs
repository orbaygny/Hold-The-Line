using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public  GameObject projectile;
    public static bool _fire;
    public GameObject parent;
    public GameObject ammoPlace;
    public GameObject efect;
    public Transform efectPlace;
    Animator parentAnim;
    // Start is called before the first frame update
    void Start()
    {
        _fire = false;
        parentAnim = parent.GetComponent<Animator>();    
         }

    // Update is called once per frame
    void Update()
    {
        if(parentAnim.GetBool("Firing"))
        {
            Fire();
            parentAnim.SetBool("Firing",false);
        }
    }

    public void Fire()
    {
        
            GameObject tmp = Instantiate(projectile,transform.position,projectile.transform.rotation);
        if (tmp.CompareTag("Mortar")) { tmp.GetComponent<MortarProjectille>().parent = parent; tmp = Instantiate(efect, efectPlace.position, efect.transform.rotation); tmp.AddComponent<BigTvfxDel>(); }
        else { tmp.GetComponent<Projectile>().parent = parent; }
            ammoPlace.GetComponent<GiveSoldierAmmo>().ammoCount--;
      
    }
    
}
