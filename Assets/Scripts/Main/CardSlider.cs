using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlider : MonoBehaviour
{
    public RectTransform[] cards;  // 슬라이드할 카드들의 RectTransform 배열
    public float swipeThreshold = 50f;  // 스와이프 감지 임계값
    public float cardMoveSpeed = 10f;   // 카드 이동 속도
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private int currentCardIndex = 0;   // 현재 보고 있는 카드의 인덱스

    void Update()
    {
        // 터치 입력을 감지하여 처리
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // 터치가 시작된 위치 기록
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    // 터치가 끝난 위치 기록
                    touchEndPos = touch.position;
                    HandleSwipe();
                    break;
            }
        }
    }

    // 스와이프 동작을 처리하는 메서드
    void HandleSwipe()
    {
        float swipeDistance = touchEndPos.x - touchStartPos.x;

        // 스와이프 거리가 임계값보다 크면 카드 넘기기
        if (Mathf.Abs(swipeDistance) > swipeThreshold)
        {
            if (swipeDistance > 0)
            {
                // 오른쪽으로 스와이프 (이전 카드로)
                ShowPreviousCard();
            }
            else
            {
                // 왼쪽으로 스와이프 (다음 카드로)
                ShowNextCard();
            }
        }
    }

    // 이전 카드를 보여주는 메서드
    void ShowPreviousCard()
    {
        if (currentCardIndex > 0)
        {
            currentCardIndex--;
            StartCoroutine(SlideToCard(cards[currentCardIndex]));
        }
    }

    // 다음 카드를 보여주는 메서드
    void ShowNextCard()
    {
        if (currentCardIndex < cards.Length - 1)
        {
            currentCardIndex++;
            StartCoroutine(SlideToCard(cards[currentCardIndex]));
        }
    }

    // 카드를 부드럽게 슬라이드하는 코루틴
    IEnumerator SlideToCard(RectTransform targetCard)
    {
        Vector2 targetPos = -targetCard.anchoredPosition;
        while (Vector2.Distance(transform.localPosition, targetPos) > 0.01f)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, targetPos, Time.deltaTime * cardMoveSpeed);
            yield return null;
        }

        // 정확한 위치에 도달하도록 보정
        transform.localPosition = targetPos;
    }
}
