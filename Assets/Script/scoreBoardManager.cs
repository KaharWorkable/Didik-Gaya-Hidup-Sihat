using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;


public class scoreBoardManager : MonoBehaviour
{
    //Firebase Variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;
    public DatabaseReference databaseReference;

    [Header("UserData")]
    public GameObject scoreElement;
    public Transform scoreBoardContent;

    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    private void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out ");
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log($"Signed in : {user.DisplayName}");
            }
        }
    }

    public void backButton()
    {
        GameManager.instance.ChangeScene(1);
    }

    public void SignOutButton()
    {
        auth.SignOut();
        GameManager.instance.ChangeScene(0);
        
    }

}
