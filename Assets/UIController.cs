using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text toastMessage;
    [SerializeField] GameObject toastContainer;
    
    private Coroutine toastCoroutine = null;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        toastContainer.SetActive(false);
        username.text = DataManager.Instance.GetUsername();
    }

    public void ChangeToastMessage(string message, bool state)
    {
        toastContainer.gameObject.SetActive(state);
        toastMessage.text= message;
    }

    
}
