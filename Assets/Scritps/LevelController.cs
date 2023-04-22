using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelController : MonoBehaviour
{
    public PlayerController player;
    public float stressLevel;
    public float progressLevel;
    public int beatRate;
    private bool gameStarted = true;
    public bool gameEnded = false;
    public float breathTimer;
    public float globalTimer;

    [SerializeField]
    public List<ISpawner> spawners = new List<ISpawner>();

    void Start()
    {
        StartCoroutine(Heartbeat());
    }


    void FixedUpdate()
    {
        if (gameStarted && !gameEnded)
        {
            globalTimer += Time.deltaTime;
            //stressLevel += Time.deltaTime;
            stressLevel = Mathf.Clamp (stressLevel,0,100);
            progressLevel += Time.deltaTime;
            progressLevel = Mathf.Clamp (progressLevel,0,100);

            if (stressLevel >= 100)
            {
                gameEnded = true;
                // lose
            }

            if (progressLevel >= 100)
            {
                gameEnded = true;

                // win
            }

        }

    }


    private IEnumerator Heartbeat()
    {
        while (gameStarted)
        {
            //player.RandomizeMovementDirection();
            bool spawnedOrCannotSpawn = false;
            int failedCount = 0;
            do
            {
                spawnedOrCannotSpawn = spawners[Random.Range(0, spawners.Count)].SpawnEnemy();
                if (!spawnedOrCannotSpawn)
                    failedCount++;
                if (failedCount > 20)
                    spawnedOrCannotSpawn = true;
                Debug.Log("Coroutine after waiting starting tick");

            } while (!spawnedOrCannotSpawn);
            yield return new WaitForSeconds(beatRate);
        }

    }


}
