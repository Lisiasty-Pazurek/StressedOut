using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float stressLevel;
    public float progressLevel;



    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private IEnumerator Heartbeat ()
    {
        for (int i = 0; i < 1; i++ )
        {
            Tick();
        }
        yield return null;
    }

    private void Tick()
    {
        progressLevel += .1f;
    }
}
