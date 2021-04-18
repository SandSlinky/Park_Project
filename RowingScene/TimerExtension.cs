using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerExtension : MonoBehaviour
{
    [SerializeField] public RowingTimer rowingTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rowingTimer.currentTime += 10;
        Destroy(gameObject);
    }

    public void SetRowingTimer(RowingTimer timer)
    {
        rowingTimer = timer;
    }
}
