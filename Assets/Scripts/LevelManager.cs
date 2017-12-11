using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Brick.BrickCount = 0;
        Debug.Log($"Requesting for level {name}");
        SceneManager.LoadScene(name);
    }

    internal void LoadNextLevel()
    {
        Brick.BrickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.BrickCount <= 0) LoadNextLevel();
    }
}
