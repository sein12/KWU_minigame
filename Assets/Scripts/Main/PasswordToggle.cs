using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PasswordToggle : MonoBehaviour
{
    // InputField 및 Button 연결

    public TMP_InputField signup_passwordInputField;
    public Button signup_toggleButton;

    public TMP_InputField login_passwordInputField;
    public Button login_toggleButton;

    private bool isPasswordVisible = false; // 비밀번호 보이기 상태를 추적

    void Start()
    {
        // 버튼 클릭 시 ToggleVisibility 메서드 실행
        login_toggleButton.onClick.AddListener(LoginToggleVisibility);
        signup_toggleButton.onClick.AddListener(SignUpToggleVisibility);
    }

    // 비밀번호 보이기/숨기기 전환
    void SignUpToggleVisibility()
    {
        if (isPasswordVisible)
        {
            // 현재 비밀번호가 보이는 상태일 경우 다시 숨기기 (Password 형식으로 변경)
            signup_passwordInputField.contentType = TMP_InputField.ContentType.Password;
            isPasswordVisible = false;
        }
        else
        {
            // 현재 비밀번호가 숨겨진 상태일 경우 보이기 (Standard 형식으로 변경)
            signup_passwordInputField.contentType = TMP_InputField.ContentType.Standard;
            isPasswordVisible = true;
        }

        // 변경 사항 즉시 반영
        signup_passwordInputField.ForceLabelUpdate();
    }

    void LoginToggleVisibility()
    {
        if (isPasswordVisible)
        {
            // 현재 비밀번호가 보이는 상태일 경우 다시 숨기기 (Password 형식으로 변경)
            login_passwordInputField.contentType = TMP_InputField.ContentType.Password;
            isPasswordVisible = false;
        }
        else
        {
            // 현재 비밀번호가 숨겨진 상태일 경우 보이기 (Standard 형식으로 변경)
            login_passwordInputField.contentType = TMP_InputField.ContentType.Standard;
            isPasswordVisible = true;
        }

        // 변경 사항 즉시 반영
        login_passwordInputField.ForceLabelUpdate();
    }
}
