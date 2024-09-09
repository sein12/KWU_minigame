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


    private FirebaseAuth auth; // �α��� / ȸ������ ��
    private FirebaseUser user; // ������ �Ϸ�� ���� ����

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
                Debug.Log("�α׾ƿ�");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if (signed)
            {
                Debug.Log("�α���");
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
                Debug.LogError("ȸ������ ���");
                return;
            }
            if (task.IsFaulted)
            {
                // task.Exception���� �� ���� ������ ���
                Debug.LogError("ȸ������ ����: " + task.Exception);

                foreach (var exception in task.Exception.Flatten().InnerExceptions)
                {
                    FirebaseException firebaseEx = exception as FirebaseException;
                    if (firebaseEx != null)
                    {
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                        // ���� �ڵ忡 ���� ������ ����ȭ�Ͽ� ó��
                        switch (errorCode)
                        {
                            case AuthError.InvalidEmail:
                                Debug.LogError("�߸��� �̸��� �����Դϴ�.");
                                break;
                            case AuthError.EmailAlreadyInUse:
                                Debug.LogError("�̹� ���Ե� �̸����Դϴ�.");
                                break;
                            default:
                                Debug.LogError("��Ÿ ���� �߻�: " + firebaseEx.Message);
                                break;
                        }
                    }
                }
                return;
            }

            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.Log("ȸ������ �Ϸ�: " + newUser.Email);
        });
    }


    public void LogIn(string email, string password)
    {

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("�α��� ���");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("�α��� ����");
                return;
            }

            AuthResult authResult = task.Result;
            FirebaseUser user = authResult.User;
            Debug.Log("�α��� �Ϸ�");
        });
    }

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("�α׾ƿ�");
    }
}
