using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowingTimer : MonoBehaviour
{
    [SerializeField] public float currentTime = 0f;
    [SerializeField] private float startingTime = 120f;
    [SerializeField] private RowingMovement rowingMovement;
    [SerializeField] private Text countdownText;
    [SerializeField] public Text startCountdown;

    public float timerSpeed = 0f;

    private IEnumerator rowingFail()
    {
        yield return new WaitForSecondsRealtime(3f);
        ResetTimer(true);
        SetTimer(false);
        rowingMovement.canMove = true;
    }

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        TimerCountdown();
    }

    private void TimerCountdown()
    {
        if (timerSpeed == 0f) return;

        currentTime -= timerSpeed * Time.deltaTime;
        countdownText.text = currentTime.ToString("00.00");

        if (currentTime <= 0)
        {
            timerSpeed = 0f;
            rowingMovement.canMove = false;
            countdownText.gameObject.SetActive(enabled);
            startCountdown.text = "TIME'S UP";
            StartCoroutine(rowingFail());
        }
    }
    public void SetTimer(bool enabled)
    {
        if (enabled)
        {
            timerSpeed = 1f;
            countdownText.gameObject.SetActive(enabled);
        }
        else
        {
            timerSpeed = 0f;
            countdownText.gameObject.SetActive(enabled);
        }
    }
    public void ResetTimer(bool startEnabled = false)
    {
        SetTimer(startEnabled);
        currentTime = startingTime;
    }
}
