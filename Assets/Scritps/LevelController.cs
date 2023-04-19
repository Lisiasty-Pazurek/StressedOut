using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public float stressLevel;
    public float progressLevel;
    public int beatRate;
    private bool gameStarted = true;
    public bool gameEnded = false;
    public float breathTimer;
    public float globalTimer;
    
    public List<Spawner> spawners = new List<Spawner>();

    void Start()
    {
        StartCoroutine(Heartbeat());
    }


    void Update()
    {
        if (gameStarted && !gameEnded)
        {
            globalTimer += Time.deltaTime;
            stressLevel += Time.deltaTime;
            progressLevel += Time.deltaTime;               

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


    private IEnumerator Heartbeat ()
    {
        while (gameStarted )
        {
            spawners[Random.Range(0,spawners.Count)].SpawnEnemy();
            Debug.Log("Coroutine after waiting starting tick");
            yield return new WaitForSeconds(beatRate);
        }

    }


}
