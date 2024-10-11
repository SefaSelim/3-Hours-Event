using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSC : MonoBehaviour
{
    float timer = 0;
    float enemyspawntime = 2;
    [SerializeField]
    GameObject enemyprefab;
    [SerializeField]
    Vector3 enemySpawnPoint;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            enemyspawntime *= 0.9f;
            timer = 0;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            enemySpawnPoint = new Vector3(Random.Range(-2.5f, 2.5f),6.0f,0.03955882f);
            Instantiate(enemyprefab,enemySpawnPoint,Quaternion.identity);
            Debug.Log("enemy spawned");
            yield return new WaitForSeconds(enemyspawntime); //zamanla artırılabilir
        }

    }
}
