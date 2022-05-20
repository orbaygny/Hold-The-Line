using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMpney : MonoBehaviour
{
    public static PlayerMpney Instance{get; private set;}
    public int money;
    public Text moneyText;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        moneyText.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
        
    }
}
