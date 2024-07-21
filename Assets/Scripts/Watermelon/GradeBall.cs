using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class GradeBall : MonoBehaviour
{
    public enum GradeLevel
    {
        F, D, C, B, A, Aplus, S
    }

    public bool isDrag;
    public int level;
    Rigidbody2D rb;
    Animator anim;
    TextMeshPro textMeshPro;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    // OnEnable is called script is enabled
    void OnEnable()
    {
        anim.SetInteger("Level", level);

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
}
