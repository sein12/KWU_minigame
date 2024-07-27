using System.Collections;
using TMPro;
using UnityEngine;

public class GradeBall : MonoBehaviour
{
    public enum GradeLevel
    {
        F, D, C, B, A, Aplus, S, SIZE
    }

    public bool isDrag;
    public bool isMerge;
    public int level;
    public GameManager gameManager;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Animator anim;
    TextMeshPro textMeshPro;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    // OnEnable is called script is enabled
    void OnEnable()
    {
        anim.SetInteger("Level", level);
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -3.8f + transform.localScale.x / 2f;
            float rightBorder = 3.8f - transform.localScale.x / 2f;

            // Restrict x border
            if (mousePos.x < leftBorder)
                mousePos.x = leftBorder;
            else if (mousePos.x > rightBorder)
                mousePos.x = rightBorder;

            // Follow mouse position
            mousePos.y = 7.5f;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
        }
    }

    public void Drag()
    {
        isDrag = true;
    }

    public void Drop()
    {
        isDrag = false;
        rb.simulated = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "GradeBall")
        {
            GradeBall otherBall = other.gameObject.GetComponent<GradeBall>();

            if (level == otherBall.level && !isMerge && !otherBall.isMerge && level < (int)GradeLevel.SIZE)
            {
                float x = transform.position.x;
                float y = transform.position.y;
                float otherBallX = otherBall.transform.position.x;
                float otherBallY = otherBall.transform.position.y;

                // Position of below and rigth than other
                if (y < otherBallY || (y == otherBallY && x > otherBallX))
                {
                    // Hide other
                    otherBall.Hide(transform.position);

                    // Level up
                    LevelUp();
                }
            }
        }
    }

    public void Hide(Vector3 targetPos)
    {
        isMerge = true;

        rb.simulated = false;
        circleCollider.enabled = false;

        StartCoroutine(HideRoutine(targetPos));
    }

    IEnumerator HideRoutine(Vector3 targetPos)
    {
        int frameCnt = 0;

        while (frameCnt < 20)
        {
            frameCnt++;
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
            yield return null;
        }

        isMerge = false;
        gameObject.SetActive(false);
    }

    void LevelUp()
    {
        isMerge = true;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        StartCoroutine(LevelUpRoutine());
    }

    IEnumerator LevelUpRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        anim.SetInteger("Level", level + 1);

        // Wait for animation
        yield return new WaitForSeconds(0.3f);
        level++;
        SetText();

        gameManager.maxLevel = Mathf.Max(gameManager.maxLevel, level);

        isMerge = false;
    }

    void SetText()
    {
        string text;
        switch ((GradeLevel)level)
        {
            case GradeLevel.F:
                text = "F";
                break;
            case GradeLevel.D:
                text = "D";
                break;
            case GradeLevel.C:
                text = "C";
                break;
            case GradeLevel.B:
                text = "B";
                break;
            case GradeLevel.A:
                text = "A";
                break;
            case GradeLevel.Aplus:
                text = "A+";
                break;
            case GradeLevel.S:
                text = "S";
                break;
            default:
                text = "Error";
                break;
        }
        textMeshPro.text = text;
    }
}
