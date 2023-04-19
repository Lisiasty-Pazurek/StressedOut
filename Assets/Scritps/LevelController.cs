using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float stressLevel;
    public float progressLevel;
    public int beatRate;
    private bool gameStarted = true;
    public float breathTimer;

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
            gameStarted = false;
        }
    }

    private void Tick()
    {
        // only for testing purpose 
        progressLevel += .1f;
    }
}
