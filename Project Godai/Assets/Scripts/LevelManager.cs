using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    public static bool cameFromOptionsMenu = false;
    public string battleType;


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Autoload disabled, use positive number in seconds");
        }
        else Invoke("LoadNextLevel", autoLoadNextLevelAfter);

    }

    public void LoadStart(string name) //USE IF LOADING TO START SCREEN
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            cameFromOptionsMenu = true;
            Debug.Log("Came from Options True)");
        }
        else
        {
            cameFromOptionsMenu = false;
            Debug.Log("Came from Options False");
        }

        Debug.Log("Level Load Requested for: " + name);
        SceneManager.LoadScene(name);
    }


    public void LoadLevel(string name) //USE IF LOADING A LEVEL
    {
        
        SceneManager.LoadScene(name);
       
    }

    public void LoadBattle(string battleIndex)
    {
        battleType = battleIndex;
        SceneManager.LoadScene("02a_BattleScene");
    }

    public void QuitRequest() {
        Debug.Log("Quit Request logged");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

}
