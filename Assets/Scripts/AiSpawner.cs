using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpawner : MonoBehaviour
{  
    public static AiSpawner Instance;
    public GameObject prefab;
    int pointer;
    bool _spawn;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0 ; i<20 ; i++)
        {
            GameObject tmp = Instantiate(prefab,prefab.transform.position,prefab.transform.rotation);
            tmp.transform.parent = transform;
           
        }
        _spawn = true;
        pointer = 0;
        StartCoroutine(Spawn(2));
    }

    // Update is called once per frame
    void Update()
    {
        if(pointer>=19)
        {
            _spawn =false;
        }

       
    }

    private IEnumerator Spawn(float waitTime)
    {
        while (_spawn)
        {
            yield return new WaitForSeconds(waitTime);
            if(CharController.Instance.move)
            {
                transform.GetChild(pointer).gameObject.SetActive(true);
                pointer++;
            }
        }
    }

   public bool CheckIfAllDies(){
           foreach(Transform child in transform)
        {
            if(!child.GetComponent<EnemyHP>().isDead)
            {
                return false;
            }
        }
        return true;
          }
          
           
      }

 
