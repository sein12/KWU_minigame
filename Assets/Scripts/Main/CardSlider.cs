using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlider : MonoBehaviour
{
    public RectTransform[] cards;  // �����̵��� ī����� RectTransform �迭
    public float swipeThreshold = 50f;  // �������� ���� �Ӱ谪
    public float cardMoveSpeed = 10f;   // ī�� �̵� �ӵ�
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private int currentCardIndex = 0;   // ���� ���� �ִ� ī���� �ε���

    void Update()
    {
        // ��ġ �Է��� �����Ͽ� ó��
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // ��ġ�� ���۵� ��ġ ���
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    // ��ġ�� ���� ��ġ ���
                    touchEndPos = touch.position;
                    HandleSwipe();
                    break;
            }
        }
    }

    // �������� ������ ó���ϴ� �޼���
    void HandleSwipe()
    {
        float swipeDistance = touchEndPos.x - touchStartPos.x;

        // �������� �Ÿ��� �Ӱ谪���� ũ�� ī�� �ѱ��
        if (Mathf.Abs(swipeDistance) > swipeThreshold)
        {
            if (swipeDistance > 0)
            {
                // ���������� �������� (���� ī���)
                ShowPreviousCard();
            }
            else
            {
                // �������� �������� (���� ī���)
                ShowNextCard();
            }
        }
    }

    // ���� ī�带 �����ִ� �޼���
    void ShowPreviousCard()
    {
        if (currentCardIndex > 0)
        {
            currentCardIndex--;
            StartCoroutine(SlideToCard(cards[currentCardIndex]));
        }
    }

    // ���� ī�带 �����ִ� �޼���
    void ShowNextCard()
    {
        if (currentCardIndex < cards.Length - 1)
        {
            currentCardIndex++;
            StartCoroutine(SlideToCard(cards[currentCardIndex]));
        }
    }

    // ī�带 �ε巴�� �����̵��ϴ� �ڷ�ƾ
    IEnumerator SlideToCard(RectTransform targetCard)
    {
        Vector2 targetPos = -targetCard.anchoredPosition;
        while (Vector2.Distance(transform.localPosition, targetPos) > 0.01f)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, targetPos, Time.deltaTime * cardMoveSpeed);
            yield return null;
        }

        // ��Ȯ�� ��ġ�� �����ϵ��� ����
        transform.localPosition = targetPos;
    }
}
