using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletStart : MonoBehaviour
{
    public Transform jumpPoint;
    Vector3 goPos; 
    // Start is called before the first frame update
   /* void Start()
    {
        goPos = transform.localPosition;
        transform.localPosition = jumpPoint.localPosition;
        transform.DOLocalJump(goPos,5,1,1);
    }
*/
   void OnEnable()
   {
       goPos = transform.localPosition;
        transform.localPosition = jumpPoint.localPosition;
        transform.DOLocalJump(goPos,5,1,1);
   }
}
