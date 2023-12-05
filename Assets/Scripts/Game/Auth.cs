using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auth : MonoBehaviour
{

    [SerializeField] UIControllerHome uiController;
    [SerializeField] string wrongUsernameMessage;
    [SerializeField] string wrongPasswordMessage;
    [SerializeField] string userAlreadyExistsMessage;
    [SerializeField] string emptyUsernameMessage;
    [SerializeField] string emptyPasswordMessage;



    public void LogIn()
    {

        string username = uiController.GetUsernameValue();
        string password = uiController.GetPasswordValue();

        if (username == "")
        {
            uiController.ShowWarn(emptyUsernameMessage);
            return;
        }

        if (!DataManager.Instance.AllUsers.ContainsKey(username))
        {
            uiController.ShowWarn(wrongUsernameMessage);
            return;
        }
        User user = DataManager.Instance.AllUsers[username];

        if (password == "")
        {
            uiController.ShowWarn(emptyPasswordMessage);
            return;
        }

        if (user.password != password)
        {
            uiController.ShowWarn(wrongPasswordMessage);
            return;
        }

        //The user has logged in and can enter the game
        DataManager.Instance.SaveUser(user);
        SceneLoader.Instance.LoadGame();


    }

    public void SignUp()
    {
        string username = uiController.GetNewUsernameValue();
        string password = uiController.GetNewPasswordValue();

        if (username == "")
        {
            uiController.ShowWarn(emptyUsernameMessage);
            return;
        }

        if (DataManager.Instance.AllUsers.ContainsKey(username))
        {
            uiController.ShowWarn(userAlreadyExistsMessage);
            return;
        }

        if (password == "")
        {
            uiController.ShowWarn(emptyPasswordMessage);
            return;
        }

        //User can be created
        User user = new User(username, password);

        DataManager.Instance.SaveUser(user);
        SceneLoader.Instance.LoadGame();
        

    }


}



