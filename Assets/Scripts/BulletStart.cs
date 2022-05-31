using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletStart : MonoBehaviour
{
    public Transform jumpPoint;
    GameObject tmp;
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
        GetComponent<MeshRenderer>().enabled = true;
        transform.localPosition = jumpPoint.localPosition;
        transform.DOLocalJump(goPos,0.05f,1,0.5f);
   }

   public void Jump(Vector3 targetPos)
   {

        // goPos = transform.localPosition;
        //transform.localPosition = f_jumpPoint.localPosition;
         tmp = Instantiate(gameObject, transform.localPosition, transform.rotation,transform.parent);
        GetComponent<MeshRenderer>().enabled = false;
        tmp.transform.DOJump(targetPos-Vector3.down,3,1,0.5f);
        Invoke("ActiveFalse", 0.5f);
   }

   public void ActiveFalse()
   {
        tmp.transform.DOKill();
        Destroy(tmp);
        gameObject.SetActive(false);
        
        
   }

  
}
