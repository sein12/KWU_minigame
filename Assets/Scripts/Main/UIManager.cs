using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject signupPanel;
    public GameObject signupCompletePanel; // 회원가입 완료 시 패널
    public GameObject loginPanel;
    public GameObject loadingPanel; // 로딩 패널 추가
    public GameObject selectCardPanel; // 카드 선택 패널 추가

    // Start is called before the first frame update
    void Start()
    {
        // 로딩 패널 먼저 보여주기
        ShowLoadingPanel();

        // 1초 후 메인 패널을 보여주는 코루틴
        StartCoroutine(ShowMainPanelAfterDelay(1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 회원가입 패널 보여주기
    public void ShowSignupPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }

    // 회원가입 완료 시 패널
    public void ShowSignupCompletePanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(true);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }

    // 로그인 패널 보여주기
    public void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }

    // 메인 패널 보여주기
    public void ShowMainPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(true);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }
    public void ShowSelectCardPanel()
    {
        loginPanel.SetActive(false);
        selectCardPanel.SetActive(true);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }


    // 로딩 패널 보여주기
    public void ShowLoadingPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(true);
        selectCardPanel.SetActive(false);
    }

    // 2초 후에 메인 패널을 보여주는 코루틴
    IEnumerator ShowMainPanelAfterDelay(float delay)
    {
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // 메인 패널을 보여줌
        ShowMainPanel();
    }
}
