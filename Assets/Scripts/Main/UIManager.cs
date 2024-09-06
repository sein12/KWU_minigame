using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject signupPanel;
    public GameObject loginPanel;
    public GameObject loadingPanel; // �ε� �г� �߰�

    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� �� �ε� �г��� ���� ������
        ShowLoadingPanel();

        // 2�� �� ���� �г��� �����ִ� �ڷ�ƾ ����
        StartCoroutine(ShowMainPanelAfterDelay(1f)); // 2�� ��� �� ���� �г� �����ֱ�
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
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    // �α��� �г� �����ֱ�
    public void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    // ���� �г� �����ֱ�
    public void ShowMainPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        mainPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }

    // �ε� �г� �����ֱ�
    public void ShowLoadingPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        mainPanel.SetActive(false);
        loadingPanel.SetActive(true);
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
