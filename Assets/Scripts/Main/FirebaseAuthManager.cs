using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using TMPro;
using System;
using Firebase;

public class FirebaseAuthManager
{

    private static FirebaseAuthManager instance = null;
    public bool loginCheck = false;

    public static FirebaseAuthManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new FirebaseAuthManager();
            }
            return instance;
        }
    }


    private FirebaseAuth auth; // 로그인 / 회원가입 등
    private FirebaseUser user; // 인증이 완료된 유저 정보

    public string UserId => user.UserId;

    public Action<bool> LoginState;

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;

        auth.StateChanged += Onchanged;
    }

    public void Onchanged(object sender, EventArgs e)
    {
        if(auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if(!signed && user != null)
            {
                Debug.Log("로그아웃");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if (signed)
            {
                Debug.Log("로그인");
                LoginState?.Invoke(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Create(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                // task.Exception에서 상세 오류 정보를 출력
                Debug.LogError("회원가입 실패: " + task.Exception);

                foreach (var exception in task.Exception.Flatten().InnerExceptions)
                {
                    FirebaseException firebaseEx = exception as FirebaseException;
                    if (firebaseEx != null)
                    {
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                        // 오류 코드에 따라 문제를 세분화하여 처리
                        switch (errorCode)
                        {
                            case AuthError.InvalidEmail:
                                Debug.LogError("잘못된 이메일 형식입니다.");
                                break;
                            case AuthError.EmailAlreadyInUse:
                                Debug.LogError("이미 가입된 이메일입니다.");
                                break;
                            default:
                                Debug.LogError("기타 오류 발생: " + firebaseEx.Message);
                                break;
                        }
                    }
                }
                return;
            }

            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.Log("회원가입 완료: " + newUser.Email);
        });
    }


    public void LogIn(string email, string password)
    {

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
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
            Debug.Log("로그인 완료");
        });
    }

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
    }
}
