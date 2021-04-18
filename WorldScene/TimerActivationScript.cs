using UnityEngine;

public class TimerActivationScript : MonoBehaviour
{
	[SerializeField] private CountdownTimer countdownTimer;
    public AudioSource timerSound;
    public float x, y;

    private void Start()
    {
        timerSound = countdownTimer.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timerSound.Play();
        x = transform.position.x;
        y = transform.position.y;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);

        countdownTimer.SetTimer(true);
    }

}
