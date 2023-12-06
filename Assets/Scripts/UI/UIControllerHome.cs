using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControllerHome : MonoBehaviour
{ 
    [SerializeField] private TMP_Text toastMessageText;
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_InputField newUsernameInput;
    [SerializeField] private TMP_InputField newPasswordInput;
    [SerializeField] private GameObject logInScreen;
    [SerializeField] private GameObject signUpScreen;


    public void ChangeLogInScreen(bool state) {
        logInScreen.SetActive(state);
        resetToastMessage();
    }
    public void ChangeSignUpScreen(bool state) {
        signUpScreen.SetActive(state);
        resetToastMessage();
    }
    private void resetToastMessage()
    {
        toastMessageText.text = "";

    }

    public void ShowWarn(string message)
    {
        toastMessageText.text = message;
    }

    public string GetPasswordValue()
    {
        return passwordInput.text;
    }
    public string GetUsernameValue()
    {
        return usernameInput.text;
    }

    public string GetNewPasswordValue()
    {
        return newPasswordInput.text;
    }
    public string GetNewUsernameValue()
    {
        return newUsernameInput.text;
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}
