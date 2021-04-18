using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] public float currentTime = 0f;
    [SerializeField] private float startingTime = 120f;
	[SerializeField] private MazeGoalScript mazeGoalScript;
	[SerializeField] public Text goalText;
	[SerializeField] private TimerActivationScript TimerActivationScript;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private MazeGoalSetPosition mazeGoalSetPosition;
	[SerializeField] private Text countdownText;

	public AudioSource timerSound;
	public float timerSpeed = 0f;
	
   	private IEnumerator mazeFailWait()
    {
		yield return new WaitForSecondsRealtime(3f);
		mazeGoalSetPosition.ResetPlayerPosition();
		ResetTimer(true);
		SetTimer(false);
		playerMovement.canMove = true;
	}
	
	private void Start()
    {
		ResetTimer();
		timerSound = GetComponent<AudioSource>();
	}

	private void Update()
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
			timerSound.Stop();
			timerSpeed = 0f;
			playerMovement.canMove = false;
			countdownText.gameObject.SetActive(enabled);
			goalText.text = "TIME'S UP";
			StartCoroutine(mazeFailWait());
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

	public void ResetTimer(bool startEnabled=false)
	{
		SetTimer(startEnabled);
		currentTime = startingTime;
		mazeGoalScript.goalText.text = "";
	}
}