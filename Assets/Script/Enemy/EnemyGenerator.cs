using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{
    public bool spawnEnabled = false;//ƒXƒ|[ƒ“ON OFF
    [SerializeField] int maxEnemies = 1000;//Å‘å”
    [SerializeField] float minPositionX = -10;//
    [SerializeField] float maxPositonX = 10;//
    [SerializeField] float minPositionZ = -10;//
    [SerializeField] float maxPositonZ = 10;//
    [SerializeField] float minSpawnInterval = 1;//
    [SerializeField] float maxSpawnInterval = 5;//
    [SerializeField] GameObject[] enemyPrefabs;//
    bool spawning = false;
    void Update()
    {
        if (spawnEnabled)
        {
            StartCoroutine(SpawnTimer());
        }
    }
    IEnumerator SpawnTimer()
    {
        if (!spawning)
        {
            if (SpawnEnemy())
            {
                spawning = true;
                float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(interval);
                spawning = false;
            }
            else
            {
                yield return null;
            }
        }
        yield return null;
    }
    bool SpawnEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length >= maxEnemies)
        {
            return false;
        }
        else
        {
            int choosedIndex = Random.Range(0, enemyPrefabs.Length);
            int enemyvolume = Random.Range(1, 30);
            for (var i = 0; i < enemyvolume; i++)
            {
                float diffPositionX = Random.Range(minPositionX, maxPositonX);
                float diffPositionZ = Random.Range(minPositionZ, maxPositonZ);
                float RotationY = Random.Range(0, 360);
                float RotationZ = Random.Range(0, 360);
                Vector3 position = new Vector3(transform.position.x + diffPositionX, transform.position.y, transform.position.z + diffPositionZ);
                Vector3 rotation = new Vector3(transform.rotation.y + RotationY, transform.rotation.z + RotationZ);
                //, transform.rotation.y + RotationY, transform.rotation.z + RotationZ
            
                Instantiate(enemyPrefabs[choosedIndex], position, Quaternion.Euler(rotation));
            }
            return true;
        }
    }
}