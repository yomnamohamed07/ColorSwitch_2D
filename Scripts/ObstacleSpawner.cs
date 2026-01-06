
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab & Spawn Settings")]
    public GameObject obstaclePrefab;
    public float spawnInterval = 0.6f; 
    public float spawnXMin;
    public float spawnXMax;
    private float spawnY;

    [Header("Obstacle Colors & Chance")]
    public Color[] obstacleColors;
    [Range(0f, 1f)]
    public float deadlyChance = 0.2f;

    private float camHalfWidth;

    void Start()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle Prefab is not assigned!");
            enabled = false; 
            return;
        }

        
        Camera mainCam = Camera.main;
        if (mainCam == null)
        {
            Debug.LogError("Main camera not found!");
            enabled = false;
            return;
        }

        camHalfWidth = mainCam.orthographicSize * mainCam.aspect;
        spawnXMin = -camHalfWidth + 0.5f;
        spawnXMax = camHalfWidth - 0.5f;
        spawnY = mainCam.orthographicSize + 1f; 

        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        Debug.Log("Obstacle spawner started.");
        while (true)
        {
            try
            {
                if (obstaclePrefab != null)
                {
                    SpawnObstacle();
                }
                else
                {
                    Debug.LogWarning("Obstacle prefab became null during runtime!");
                    break;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Exception in spawner loop: " + e.Message + "\n" + e.StackTrace);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        float x = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPos = new Vector3(x, spawnY, 0);
        GameObject obs = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

       
        ObstacleColor oc = obs.GetComponent<ObstacleColor>();
        SpriteRenderer sr = obs.GetComponent<SpriteRenderer>();

        if (oc != null)
        {
            if (Random.value < deadlyChance)
            {
                oc.obstacleType = ObstacleColor.ObstacleType.DeadlyObstacle;
                if (sr != null) sr.color = Color.black;
            }
            else
            {
                if (obstacleColors.Length > 0)
                {
                    Color chosenColor = obstacleColors[Random.Range(0, obstacleColors.Length)];
                    oc.obstacleType = ObstacleColor.ObstacleType.ColorObstacle;
                    oc.obstacleColor = chosenColor;
                    if (sr != null) sr.color = chosenColor;
                }
                else
                {
                    Debug.LogWarning("No obstacle colors assigned!");
                    if (sr != null) sr.color = Color.white;
                }
            }
        }
        else
        {
            
            if (sr != null && obstacleColors.Length > 0)
            {
                sr.color = obstacleColors[Random.Range(0, obstacleColors.Length)];
            }
        }
        if (obs.GetComponent<ObstacleMovement>() == null)
        {
            obs.AddComponent<ObstacleMovement>();
        }
    }
}