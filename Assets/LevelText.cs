using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Lvl " + (PlayerPrefs.GetInt("Level", 0) + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
