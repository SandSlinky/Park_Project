using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeGoalScript : MonoBehaviour
{
    [SerializeField] private CountdownTimer countdownTimer;
    [SerializeField] public Text goalText;
    [SerializeField] public TimerActivationScript timerActivationScript;
    [SerializeField] public MazeGoalSetPosition mazeGoalSetPosition;
    [SerializeField] public PlayerMovement playerMovement;
    [SerializeField] public Image mazeMedal;
    public AudioSource goalSound;
    public AudioSource timerSound;
    
    private IEnumerator mazeGoalWait()
    {
        yield return new WaitForSecondsRealtime(3f);
        mazeGoalSetPosition.ResetPlayerPosition();
        countdownTimer.ResetTimer(true);
        countdownTimer.SetTimer(false);
        playerMovement.canMove = true;
    }

    private void Start()
    {
        goalSound = GetComponent<AudioSource>();
        timerSound = countdownTimer.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (countdownTimer.currentTime > 0)
        {
            timerSound.Stop();
            goalSound.Play();
            countdownTimer.timerSpeed = 0f;
            playerMovement.canMove = false;
            goalText.text = "GOAL!";
            mazeMedal.enabled = true;

            StartCoroutine(mazeGoalWait());
        }
    }    
}
