using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogInSystem : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;

    public TMP_Text outputText;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseAuthManager.Instance.Init();
    }

    public void Create()
    {
        string e = email.text;
        string p = password.text;

        FirebaseAuthManager.Instance.Create(e, p);
    }
    public void LogIn()
    {
        FirebaseAuthManager.Instance.LogIn(email.text, password.text);
    }
    public void LogOut()
    {
        FirebaseAuthManager.Instance.LogOut();
    }
}
