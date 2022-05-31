using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGunFireP : MonoBehaviour
{
    public GameObject projectile;
    public static bool _fire;
    public GameObject parent;
    public GameObject ammoPlace;
    Animator parentAnim;
    public Transform leftTop;
    public Transform leftBottom;
    public Transform rightTop;
    public Transform rightBottom;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        _fire = false;
        parentAnim = parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentAnim.GetBool("Firing"))
        {
            StartCoroutine(Fire());
            parentAnim.SetBool("Firing", false);
        }
    }

    public IEnumerator Fire()
    {
        GameObject tmp = Instantiate(projectile, leftTop.position, projectile.transform.rotation);
        tmp.GetComponent<Projectile>().parent = parent;
      GameObject exp = Instantiate(explosion, leftTop.position, explosion.transform.rotation);
        exp.AddComponent<BigTvfxDel>();
        tmp = Instantiate(projectile, leftBottom.position, projectile.transform.rotation);
        tmp.GetComponent<Projectile>().parent = parent;
       exp = Instantiate(explosion, leftBottom.position, explosion.transform.rotation);
        exp.AddComponent<BigTvfxDel>();
        ammoPlace.GetComponent<GiveSoldierAmmo>().ammoCount--;
        yield return new WaitForSeconds(0.05f);

        tmp = Instantiate(projectile, rightTop.position, projectile.transform.rotation);
        tmp.GetComponent<Projectile>().parent = parent;
      exp=  Instantiate(explosion, rightTop.position, explosion.transform.rotation);
        exp.AddComponent<BigTvfxDel>();
        tmp = Instantiate(projectile, rightBottom.position, projectile.transform.rotation);
        tmp.GetComponent<Projectile>().parent = parent;
        exp =Instantiate(explosion, rightTop.position, explosion.transform.rotation);
        exp.AddComponent<BigTvfxDel>();
        ammoPlace.GetComponent<GiveSoldierAmmo>().ammoCount--;

    }
}
