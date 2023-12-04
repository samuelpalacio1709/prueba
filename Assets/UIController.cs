using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TMP_Text username;

    private void Start()
    {
        username.text = DataManager.Instance.GetUsername();
    }

    private void Init()
    {

    }
}
