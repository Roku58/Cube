using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EnemyPool : MonoBehaviour
{
    public bool spawnEnabled = false;//スポーンON OFF
    [SerializeField] int maxEnemies = 1000;//最大数
    [SerializeField] float minPositionX = -10;//
    [SerializeField] float maxPositonX = 10;//
    [SerializeField] float minPositionZ = -10;//
    [SerializeField] float maxPositonZ = 10;//
    [SerializeField] float minSpawnInterval = 1;//
    [SerializeField] float maxSpawnInterval = 5;//
    [SerializeField] EnemyController[] enemyPrefabs;//
    bool spawning = false;

    // 初期のプールサイズ
    public int DefaultCapacity = 10;
    // プールサイズを最大どれだけ大きくするか
    public int MaxSize = 10;

    public ObjectPool<EnemyController> enemyPool = null;
    private int _nextId = 1;
    private Vector3 setposition;
    private Vector3 setrotation;
    private void Awake()
    {
        enemyPool = new ObjectPool<EnemyController>(OnCreatePoolObject, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, DefaultCapacity, MaxSize);

    }
    private void Update()
    {
        EnemyController pooledObject = enemyPool.Get();
        pooledObject.transform.position = setposition;
        pooledObject.transform.rotation = Random.rotation;
    }

     EnemyController OnCreatePoolObject()
    {

        SpawnEnemy();
        var enemy = Instantiate(enemyPrefabs[0], setposition, Quaternion.Euler(setrotation));
        return enemy;
    }



    void OnTakeFromPool(EnemyController enemy)
    {

        // プールからパーティクルシステムを借りるときに
        // そのオブジェクトのアクティブをONにする
        enemy.gameObject.SetActive(true);
        //SpawnEnemy();
    }

    void OnReturnedToPool(EnemyController enemy)
    {

        // 逆にプールにパーティクルシステムを返却するときに
        // そのオブジェクトのアクティブをOFFにする

        enemy.gameObject.SetActive(false);
    }

    void OnDestroyPoolObject(EnemyController enemy)
    {

        // プールされたパーティクルの削除が要求されているので、
        // オブジェクトを破棄する。
        Destroy(enemy.gameObject);
    }

    Vector3 SpawnEnemy()
    {
            int choosedIndex = Random.Range(0, enemyPrefabs.Length);
            int enemyvolume = Random.Range(1, 30);

                float diffPositionX = Random.Range(minPositionX, maxPositonX);
                float diffPositionZ = Random.Range(minPositionZ, maxPositonZ);
                float RotationY = Random.Range(0, 360);
                float RotationZ = Random.Range(0, 360);
                Vector3 setposition = new Vector3(transform.position.x + diffPositionX, transform.position.y, transform.position.z + diffPositionZ);
                Vector3 setrotation = new Vector3(transform.rotation.y + RotationY, transform.rotation.z + RotationZ);
        //, transform.rotation.y + RotationY, transform.rotation.z + RotationZ

        //Instantiate(enemyPrefabs[choosedIndex], position, Quaternion.Euler(rotation));
        return setposition;
        return setrotation;
    }


}