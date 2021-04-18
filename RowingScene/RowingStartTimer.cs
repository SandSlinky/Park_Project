using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowingStartTimer : MonoBehaviour

{
    [SerializeField] public float currentTime = 3f;
    [SerializeField] private float startingTime = 3;
    [SerializeField] private RowingMovement rowingMovement;
    [SerializeField] public Text startCountdown;
    [SerializeField] private RowingTimer rowingTimer;

    public float timerSpeed = 1f;

    private IEnumerator rowingGo()
    {
        yield return new WaitForSecondsRealtime(1f);
        rowingMovement.canMove = true;
        rowingTimer.SetTimer(true);
        startCountdown.text = "";        
    }

        // Start is called before the first frame update
        void Start()
    {
        rowingMovement.canMove = false;
    }

    private void Update()
    {
        if (timerSpeed == 0f)
        {
            return;
        }
        StartCountdown();
    }

    private void StartCountdown()
    {
        currentTime -= timerSpeed * Time.deltaTime;
        startCountdown.text = currentTime.ToString("0");

		if (currentTime <= 0.5)
		{
			timerSpeed = 0f;
			startCountdown.text = "GO!";
			StartCoroutine(rowingGo());
        }
    }
}