using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DataManager dataManager => DataManager.Instance;


    private void Start()
    {
        Debug.Log(dataManager.GetUsername());

        if(dataManager.user == null)
        {
            SceneManager.LoadScene(0);

        }
        if(dataManager.GetUsername() == "")
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }


}
