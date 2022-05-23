using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EnemyPool : MonoBehaviour
{
    public bool spawnEnabled = false;//�X�|�[��ON OFF
    [SerializeField] int maxEnemies = 1000;//�ő吔
    [SerializeField] float minPositionX = -10;//
    [SerializeField] float maxPositonX = 10;//
    [SerializeField] float minPositionZ = -10;//
    [SerializeField] float maxPositonZ = 10;//
    [SerializeField] float minSpawnInterval = 1;//
    [SerializeField] float maxSpawnInterval = 5;//
    [SerializeField] EnemyController[] enemyPrefabs;//
    bool spawning = false;

    // �����̃v�[���T�C�Y
    public int DefaultCapacity = 10;
    // �v�[���T�C�Y���ő�ǂꂾ���傫�����邩
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

        // �v�[������p�[�e�B�N���V�X�e�����؂��Ƃ���
        // ���̃I�u�W�F�N�g�̃A�N�e�B�u��ON�ɂ���
        enemy.gameObject.SetActive(true);
        //SpawnEnemy();
    }

    void OnReturnedToPool(EnemyController enemy)
    {

        // �t�Ƀv�[���Ƀp�[�e�B�N���V�X�e����ԋp����Ƃ���
        // ���̃I�u�W�F�N�g�̃A�N�e�B�u��OFF�ɂ���

        enemy.gameObject.SetActive(false);
    }

    void OnDestroyPoolObject(EnemyController enemy)
    {

        // �v�[�����ꂽ�p�[�e�B�N���̍폜���v������Ă���̂ŁA
        // �I�u�W�F�N�g��j������B
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