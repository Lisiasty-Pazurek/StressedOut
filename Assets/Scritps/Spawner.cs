using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public int spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, this.transform);
        //spawnedEnemy.GetComponent<EnemyController>().RandomType();
    }
}
