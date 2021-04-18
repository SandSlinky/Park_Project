using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private int numberOfObstacles;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float obstaclesStartWidth;
    [SerializeField] private float obstaclesWidthInterval;
    [SerializeField] private Vector2 gridWidth;
    [SerializeField] private Vector2 gridHeight;
    [SerializeField] private RowingTimer rowingTimer;    
    private List<GameObject> generatedObstacles = new List<GameObject>();

    private void Start()
    {
        GenerateObstacles();
    }

    private void GenerateObstacles()
    {
        var numObstacles = numberOfObstacles;
        if (numberOfObstacles == 0)
        {
            numObstacles = (int)(gridWidth.y - (gridWidth.x + obstaclesStartWidth)) / 2;
        }
        
        for (int i = 0; i < numObstacles; i++)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            var obj = obstacles[Random.Range(0, obstacles.Length)];
            var posBlock = new Vector3(obstaclesStartWidth + i * obstaclesWidthInterval, 0, transform.position.z);
            var pos = new Vector3(
                Random.Range(obstaclesStartWidth + obstaclesWidthInterval + gridWidth.x, gridWidth.y),
                Random.Range(gridHeight.x, gridHeight.y),
                transform.position.z);
            var spawnedObject = Instantiate(obj, posBlock, transform.rotation, transform);
            if (spawnedObject.GetComponent<TimerExtension>() == true)
            {
                spawnedObject.GetComponent<TimerExtension>().SetRowingTimer(rowingTimer);
            }
            generatedObstacles.Add(spawnedObject);
        }
    }
}
