using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 2f;
    private ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        //scoreKeeper.ResetScore();
        SceneManager.LoadScene("Level1");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("EndMenu", sceneLoadDelay));
    } 
    
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
