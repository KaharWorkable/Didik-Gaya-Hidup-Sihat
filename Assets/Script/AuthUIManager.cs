using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuthUIManager : MonoBehaviour
{
    public static AuthUIManager instance;

    [Header("Reference")]
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject registerUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
    }

    private void ClearUI()
    {
        registerUI.SetActive(false);
        loginUI.SetActive(false);
        FirebaseManager.instance.ClearOutPuts();
        //checkingForAccountUI.SetActive(false);
    }
    public void LoginScreen()
    {
        ClearUI();
        loginUI.SetActive(true);
    }

    public void RegisterScreen()
    {
        ClearUI();
        registerUI.SetActive(true);
    }
}
