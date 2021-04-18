using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGoalSetPosition : MonoBehaviour
{
    [SerializeField] public MazeGoalScript mazeGoalScript;
    [SerializeField] public TimerActivationScript timerActivationScript;

    public void ResetPlayerPosition()
    {
        Vector2 LoadPosition = new Vector2(timerActivationScript.x, timerActivationScript.y-1);
        transform.position = LoadPosition;
    }
}