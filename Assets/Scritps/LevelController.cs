using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelController : MonoBehaviour
{
    public PlayerController player;
    public UIController uiController;
    public float stressLevel;
    public float progressLevel;
    public int beatRate;
    public bool gameStarted = true;
    public bool gameEnded = false;
    public bool win = false;
    public float breathTimer;
    public float globalTimer;

    [SerializeField]
    public List<ISpawner> spawners = new List<ISpawner>();
    public GameObject currentLevel;

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
                win = false;
                uiController.EndLevel(win);
            }

            if (progressLevel >= 100)
            {
                gameEnded = true;
                win = true;
                uiController.EndLevel(win);
            }
        }
    }

    public void ResetProgress()
    {
        stressLevel = 0;
        progressLevel = 0;
        gameEnded = false;
        win = false;
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
