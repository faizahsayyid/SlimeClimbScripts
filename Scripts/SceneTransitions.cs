using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitions : MonoBehaviour
{
    private static int levelNum = 0;

    public void LevelOne()
    {
        levelNum = 1;
        Debug.Log("one");
        SceneManager.LoadScene(levelNum);
    }

    public void LevelTwo()
    {
        levelNum = 2;
        Debug.Log("two");
        SceneManager.LoadScene(levelNum);
    }

    public void LevelThree()
    {
        levelNum = 3;
        Debug.Log("three");
        SceneManager.LoadScene(levelNum);
    }

    public void Retry()
    {
        Debug.Log(levelNum);
        SceneManager.LoadScene(levelNum);
        levelNum = 0;
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
