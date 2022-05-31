using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOpener : MonoBehaviour
{
    public GameObject failPanel;
    public GameObject winPanel;
    
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHp.Instance.isDead)
        {
            failPanel.SetActive(true);
            GameManager.Instance.levelEnded = true;
        }
         if(AiSpawner.Instance.CheckIfAllDies())
        {
            winPanel.SetActive(true);
            GameManager.Instance.levelEnded = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
