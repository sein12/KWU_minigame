using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject signupPanel;
    public GameObject loginPanel;
    public GameObject loadingPanel; // 로딩 패널 추가

    // Start is called before the first frame update
    void Start()
    {
        // 게임 실행 시 로딩 패널을 먼저 보여줌
        ShowLoadingPanel();

        // 2초 후 메인 패널을 보여주는 코루틴 시작
        StartCoroutine(ShowMainPanelAfterDelay(1f)); // 2초 대기 후 메인 패널 보여주기
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
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    // 로그인 패널 보여주기
    public void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    // 메인 패널 보여주기
    public void ShowMainPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        mainPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }

    // 로딩 패널 보여주기
    public void ShowLoadingPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(true);
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
