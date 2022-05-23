//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Pool;
//public class ObjectPoolExample : MonoBehaviour
//{
//    public bool spawnEnabled = false;//�X�|�[��ON OFF
//    [SerializeField] int maxEnemies = 1000;//�ő吔
//    [SerializeField] float minPositionX = -10;//
//    [SerializeField] float maxPositonX = 10;//
//    [SerializeField] float minPositionZ = -10;//
//    [SerializeField] float maxPositonZ = 10;//
//    [SerializeField] float minSpawnInterval = 1;//
//    [SerializeField] float maxSpawnInterval = 5;//
//    [SerializeField] GameObject[] enemyPrefabs;//
//    bool spawning = false;

//    // �����̃v�[���T�C�Y
//    public int DefaultCapacity = 10;
//    // �v�[���T�C�Y���ő�ǂꂾ���傫�����邩
//    public int MaxSize = 100;

//    private ObjectPool<GameObject> _pool = null;

//    private int _nextId = 1;

//    public ObjectPool<GameObject> Pool
//    {
//        get
//        {
//            if (_pool == null)
//            {
//                _pool = new ObjectPool<GameObject>(OnCreatePoolObject, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, DefaultCapacity, MaxSize);
//            }

//            return _pool;
//        }
//    }



//    GameObject OnCreatePoolObject()
//    {
        
//        int choosedIndex = Random.Range(0, enemyPrefabs.Length);
//            int enemyvolume = Random.Range(1, 30);
//            //for (var i = 0; i < enemyvolume; i++)
//            //{
//                float diffPositionX = Random.Range(minPositionX, maxPositonX);
//                float diffPositionZ = Random.Range(minPositionZ, maxPositonZ);
//                float RotationY = Random.Range(0, 360);
//                float RotationZ = Random.Range(0, 360);
//                Vector3 positions = new Vector3(transform.position.x + diffPositionX, transform.position.y, transform.position.z + diffPositionZ);
//                Vector3 rotations = new Vector3(transform.rotation.y + RotationY, transform.rotation.z + RotationZ);

//                //Instantiate(enemyPrefabs[choosedIndex], position, Quaternion.Euler(rotation));

//            //}

//        // �v�[������p�[�e�B�N���V�X�e���̍쐬
//        var go = new GameObject($"Enemy: {_nextId++}");
//        go = enemyPrefabs[choosedIndex];
//        go = go.transform.position.positions;
//        go = rotation;
//        //var ps = go.AddComponent<ParticleSystem>();
//        // �p�[�e�B�N���̏I���������G�~�b�^�[��~ & �G�~�b�V�����̃N���A�Ƃ���


//        // �p�[�e�B�N����1�b�̃����V���b�g�Đ��Ƃ���
//        // (�̂Ŗ�1�b��Ƀp�[�e�B�N���͒�~����)

//        // �p�[�e�B�N�����I��������v�[���ɕԋp���邽�߂�
//        // ���������������R���|�[�l���g���A�^�b�`
//        //var returnToPool = go.AddComponent<ReturnToPool>();
//        //returnToPool.Pool = Pool;


//        //return ps;
//    }

//    void OnTakeFromPool(GameObject game)
//    {

//        // �v�[������p�[�e�B�N���V�X�e�����؂��Ƃ���
//        // ���̃I�u�W�F�N�g�̃A�N�e�B�u��ON�ɂ���
//        game.gameObject.SetActive(true);
//    }

//    void OnReturnedToPool(GameObject game)
//    {

//        // �t�Ƀv�[���Ƀp�[�e�B�N���V�X�e����ԋp����Ƃ���
//        // ���̃I�u�W�F�N�g�̃A�N�e�B�u��OFF�ɂ���
//        this.gameObject.SetActive(false);
//    }

//    void OnDestroyPoolObject(GameObject game)
//    {

//        // �v�[�����ꂽ�p�[�e�B�N���̍폜���v������Ă���̂ŁA
//        // �I�u�W�F�N�g��j������B
//        //
//        // OnCreatePoolObject�ŃI�u�W�F�N�g�𐶐����Ă���̂�
//        // �����Ŕj������Ӗ�������Ƃ�������
//        Destroy(this.gameObject);
//    }




//}