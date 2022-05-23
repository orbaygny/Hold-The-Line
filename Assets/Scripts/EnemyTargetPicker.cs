using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPicker : MonoBehaviour
{
    Vector3 center;
    float radius;
    public Transform currentTarget;
    LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        center = Vector3.zero;
        radius = 100000f;
        LayerMask mask = LayerMask.NameToLayer("Target");
        Debug.Log(mask);
    }

    // Update is called once per frame
    void Update()
    {
         if(!GameManager.Instance.levelEnded)
         {
             Collider[] hitColliders = Physics.OverlapSphere(center, radius,1<<6);
         if(hitColliders.Length > 0)
         {
             currentTarget = hitColliders[0].transform;
         }
         if(hitColliders.Length == 0)
         {
             currentTarget = CharController.Instance.transform;
         }
         }
         else
         {
             currentTarget = null;
         }
        
        
    }

    
}
