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

    
    public List<Spawner> spawners = new List<Spawner>();

    void Start()
    {
        StartCoroutine(Heartbeat());
    }


    void Update()
    {
        
    }

    private IEnumerator Heartbeat ()
    {
        while (gameStarted)
        {
            Debug.Log("Coroutine after waiting starting tick");
            Tick();
            yield return new WaitForSeconds(beatRate);
        }

        if (progressLevel >=1)
        {
            gameEnded = true;
        }
    }

    private void Tick()
    {
        if (gameStarted && !gameEnded)
        {
            progressLevel += .1f;
            
        }
    }
}
