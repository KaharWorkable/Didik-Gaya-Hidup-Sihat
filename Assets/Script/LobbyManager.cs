using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class LobbyManager : MonoBehaviour
{
    public static FirebaseManager instance;

    public FirebaseAuth auth;
    public FirebaseUser user;

    private void InitializeFirebase()
    {

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

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
    public void Foodflight()
    {
        GameManager.instance.ChangeScene(2);
    }

    public void kuiz()
    {
        GameManager.instance.ChangeScene(3);
    }

    public void PapanSkor()
    {
        GameManager.instance.ChangeScene(5);
    }

    public void profil()
    {
        GameManager.instance.ChangeScene(4);
    }

    public void LogOut()
    {
        //auth.SignOut();
        //user.DeleteAsync();

        ////yield return new WaitForSeconds(2);
        //GameManager.instance.ChangeScene(0);

        FirebaseAuth.DefaultInstance.SignOut();
        GameManager.instance.ChangeScene(0);
    }
}
