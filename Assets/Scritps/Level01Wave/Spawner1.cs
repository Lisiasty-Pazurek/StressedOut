using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : ISpawner
{
    public GameObject enemyPrefab;

    private int count = 0;
    public int spawnRate;

    public float spawnRange;

    public List<Transform> moveTargetTransformList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public bool SpawnEnemy()
    {
        if (!transform.gameObject.activeSelf)
            return false;
        if (count < moveTargetTransformList.Count)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, this.transform);

            spawnedEnemy.GetComponent<EnemyControllerTowardTarget>().moveDestination = moveTargetTransformList[count].transform;

            Vector3 vector3 = spawnedEnemy.GetComponent<EnemyControllerTowardTarget>().moveDestination.transform.position;
            spawnedEnemy.transform.position = new Vector3(vector3.x + Random.Range(-spawnRange, spawnRange), vector3.y + Random.Range(-spawnRange, spawnRange), 0) ;

            count++;
            return true;
        }

        return false;
        //spawnedEnemy.GetComponent<EnemyController>().RandomType();
    }
}
