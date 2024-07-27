using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GradeBall lastGradeBall;
    public GameObject gradeBallPrefab;
    public Transform gradeBallGroup;

    public int maxLevel;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        NextGradeBall();
    }

    GradeBall GetGradeBall()
    {
        GameObject instant = Instantiate(gradeBallPrefab, gradeBallGroup);
        GradeBall instantGradeBall = instant.GetComponent<GradeBall>();
        return instantGradeBall;
    }

    void NextGradeBall()
    {
        GradeBall newGradeBall = GetGradeBall();
        lastGradeBall = newGradeBall;
        lastGradeBall.gameManager = this;
        lastGradeBall.level = Random.Range(0, maxLevel);   // defaut max level: 3
        lastGradeBall.gameObject.SetActive(true);

        StartCoroutine("WaitNextGradeBall");
    }

    IEnumerator WaitNextGradeBall()
    {
        while (lastGradeBall != null)
            yield return null;

        yield return new WaitForSeconds(2.5f);

        NextGradeBall();
    }

    public void TouchDown()
    {
        if (lastGradeBall == null) return;

        lastGradeBall.Drag();
    }

    public void TouchUp()
    {
        if (lastGradeBall == null) return;

        lastGradeBall.Drop();
        lastGradeBall = null;
    }
}
