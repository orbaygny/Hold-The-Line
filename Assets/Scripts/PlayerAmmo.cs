using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public static PlayerAmmo Instance{get; private set;}

    public Transform ammoParent;
  [HideInInspector] public int maxAmmo;
  [HideInInspector] public int currentAmmo;

    void Awake()
    {
        Instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = 4;
        currentAmmo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
