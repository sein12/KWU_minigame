using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject signupPanel;
    public GameObject signupCompletePanel; // ȸ������ �Ϸ� �� �г�
    public GameObject loginPanel;
    public GameObject loadingPanel; // �ε� �г� �߰�
    public GameObject selectCardPanel; // ī�� ���� �г� �߰�

    // Start is called before the first frame update
    void Start()
    {
        // �ε� �г� ���� �����ֱ�
        ShowLoadingPanel();

        // 1�� �� ���� �г��� �����ִ� �ڷ�ƾ
        StartCoroutine(ShowMainPanelAfterDelay(1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ȸ������ �г� �����ֱ�
    public void ShowSignupPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }

    // ȸ������ �Ϸ� �� �г�
    public void ShowSignupCompletePanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(true);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }

    // �α��� �г� �����ֱ�
    public void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
        selectCardPanel.SetActive(false);
    }

    // ���� �г� �����ֱ�
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


    // �ε� �г� �����ֱ�
    public void ShowLoadingPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        signupCompletePanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(true);
        selectCardPanel.SetActive(false);
    }

    // 2�� �Ŀ� ���� �г��� �����ִ� �ڷ�ƾ
    IEnumerator ShowMainPanelAfterDelay(float delay)
    {
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(delay);

        // ���� �г��� ������
        ShowMainPanel();
    }
}
