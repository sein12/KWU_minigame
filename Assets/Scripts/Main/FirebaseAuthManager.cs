using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using TMPro;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth; // 로그인 / 회원가입 등
    private FirebaseUser user; // 인증이 완료된 유저 정보

    public TMP_InputField email;
    public TMP_InputField password;

    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => 
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                // 회원가입 실패 이유 => 이메일이 비정상 / 비밀번호가 너무 간단 / 이미 가입된 이메일 등등...
                Debug.LogError("회원가입 실패");
                return;
            }

            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.LogError("회원가입 완료");
        });
    }

    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("로그인 실패");
                return;
            }

            AuthResult authResult = task.Result;
            FirebaseUser user = authResult.User;
            Debug.LogError("로그인 완료");
        });
    }

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
    }
}
