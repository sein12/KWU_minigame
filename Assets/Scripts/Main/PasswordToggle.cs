using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PasswordToggle : MonoBehaviour
{
    // InputField �� Button ����

    public TMP_InputField signup_passwordInputField;
    public Button signup_toggleButton;

    public TMP_InputField login_passwordInputField;
    public Button login_toggleButton;

    private bool isPasswordVisible = false; // ��й�ȣ ���̱� ���¸� ����

    void Start()
    {
        // ��ư Ŭ�� �� ToggleVisibility �޼��� ����
        login_toggleButton.onClick.AddListener(LoginToggleVisibility);
        signup_toggleButton.onClick.AddListener(SignUpToggleVisibility);
    }

    // ��й�ȣ ���̱�/����� ��ȯ
    void SignUpToggleVisibility()
    {
        if (isPasswordVisible)
        {
            // ���� ��й�ȣ�� ���̴� ������ ��� �ٽ� ����� (Password �������� ����)
            signup_passwordInputField.contentType = TMP_InputField.ContentType.Password;
            isPasswordVisible = false;
        }
        else
        {
            // ���� ��й�ȣ�� ������ ������ ��� ���̱� (Standard �������� ����)
            signup_passwordInputField.contentType = TMP_InputField.ContentType.Standard;
            isPasswordVisible = true;
        }

        // ���� ���� ��� �ݿ�
        signup_passwordInputField.ForceLabelUpdate();
    }

    void LoginToggleVisibility()
    {
        if (isPasswordVisible)
        {
            // ���� ��й�ȣ�� ���̴� ������ ��� �ٽ� ����� (Password �������� ����)
            login_passwordInputField.contentType = TMP_InputField.ContentType.Password;
            isPasswordVisible = false;
        }
        else
        {
            // ���� ��й�ȣ�� ������ ������ ��� ���̱� (Standard �������� ����)
            login_passwordInputField.contentType = TMP_InputField.ContentType.Standard;
            isPasswordVisible = true;
        }

        // ���� ���� ��� �ݿ�
        login_passwordInputField.ForceLabelUpdate();
    }
}
