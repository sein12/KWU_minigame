using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogInSystem : MonoBehaviour
{
    public TMP_InputField login_email;
    public TMP_InputField login_password;

    public TMP_InputField signup_email;
    public TMP_InputField signup_password;

    // public TMP_Text outputText;

    // Start is called before the first frame update
    void Start()
    {
        // FirebaseAuthManager.Instance.LoginState += OnChangedState;
        FirebaseAuthManager.Instance.Init();
    }
    /*
    private void OnChangedState(bool sign)
    {
        outputText.text = sign ? "로그인 : " : "로그아웃 : ";
        outputText.text += FirebaseAuthManager.Instance.UserId;
    }
    */
    public void Create()
    {
        string e = signup_email.text;
        string p = signup_password.text;

        FirebaseAuthManager.Instance.Create(e, p);
    }
    public void LogIn()
    {
        FirebaseAuthManager.Instance.LogIn(login_email.text, login_password.text);
    }
    public void LogOut()
    {
        FirebaseAuthManager.Instance.LogOut();
    }
}
