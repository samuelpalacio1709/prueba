using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] private string gameSceneName;

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
