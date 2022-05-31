using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTvfxDel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyVfx", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyVfx() 
    {
        Destroy(gameObject);
    }
}
