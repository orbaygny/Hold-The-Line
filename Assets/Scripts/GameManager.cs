using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public List<GameObject> levels = new List<GameObject>();
    [HideInInspector] public bool levelEnded;
    public GameObject CurrentLevel;
    public bool isTesting = false;
    public TextMeshProUGUI levelText;
    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        Debug.Log(PlayerPrefs.GetInt("Level", 0));
        if (isTesting == false)
        {
            if (levels.Count == 0)
            {
                foreach (Transform level in transform)
                {
                    levels.Add(level.gameObject);
                }
            }
             if(PlayerPrefs.GetInt("Level", 0)> levels.Count) 
            {
                CurrentLevel = levels[PlayerPrefs.GetInt("Level", 0) % levels.Count];
                levels[PlayerPrefs.GetInt("Level", 0) % levels.Count].SetActive(true);
            }

            else {
                CurrentLevel = levels[PlayerPrefs.GetInt("Level", 0) ];
                levels[PlayerPrefs.GetInt("Level", 0)].SetActive(true);
            }
            
        }
        else
        {
            CurrentLevel.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        levelEnded = false;
        //levelText.text = "Level " +(PlayerPrefs.GetInt("Level", 0) + 1);
    }

    public void NextLevel()
    {
        //StartCoroutine(LevelUp());
        if ((levels.IndexOf(CurrentLevel) + 1) == levels.Count)
        {
           PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level",0)+1);
            //  GameHandler.Instance.Appear_TransitionPanel();​
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            CurrentLevel = levels[(PlayerPrefs.GetInt("Level",0)) % levels.Count];
            //levels[(PlayerPrefs.GetInt("Level", 1)) % levels.Count].SetActive(false);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
            //levels[PlayerPrefs.GetInt("Level", 1) % levels.Count].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //UpdateLevelText();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
    void UpdateLevelText()
    {
        levelText.text = ("LVL " + PlayerPrefs.GetInt("Level" + 1));
    }
}
