using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ElephantSDK;

public class PanelOpener : MonoBehaviour
{
    public GameObject failPanel;
    public GameObject winPanel;

    bool openned;
    
     // Start is called before the first frame update
    void Start()
    {
        openned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHp.Instance.isDead)
        {
            failPanel.SetActive(true);
            GameManager.Instance.levelEnded = true;

            if (openned) { Elephant.LevelFailed((PlayerPrefs.GetInt("Level", 0) + 1)); Debug.Log("Lose Panel"); openned = false; }
        }
         if(AiSpawner.Instance.CheckIfAllDies())
        {
            winPanel.SetActive(true);
            GameManager.Instance.levelEnded = true;
            if (openned) { Elephant.LevelFailed((PlayerPrefs.GetInt("Level", 0) + 1)); Debug.Log("Win Panel"); openned = false; }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
