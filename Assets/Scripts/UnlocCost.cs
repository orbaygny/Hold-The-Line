using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlocCost : MonoBehaviour
{
    public static UnlocCost Instance{get; private set;}
    public int unlockCount;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        unlockCount = 0;
    }

    // Update is called once per frame
    public void Increase()
    {
        unlockCount++;
    }
}
