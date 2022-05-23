//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Pool;
//public class ObjectPoolExample : MonoBehaviour
//{
//    public bool spawnEnabled = false;//スポーンON OFF
//    [SerializeField] int maxEnemies = 1000;//最大数
//    [SerializeField] float minPositionX = -10;//
//    [SerializeField] float maxPositonX = 10;//
//    [SerializeField] float minPositionZ = -10;//
//    [SerializeField] float maxPositonZ = 10;//
//    [SerializeField] float minSpawnInterval = 1;//
//    [SerializeField] float maxSpawnInterval = 5;//
//    [SerializeField] GameObject[] enemyPrefabs;//
//    bool spawning = false;

//    // 初期のプールサイズ
//    public int DefaultCapacity = 10;
//    // プールサイズを最大どれだけ大きくするか
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

//        // プールするパーティクルシステムの作成
//        var go = new GameObject($"Enemy: {_nextId++}");
//        go = enemyPrefabs[choosedIndex];
//        go = go.transform.position.positions;
//        go = rotation;
//        //var ps = go.AddComponent<ParticleSystem>();
//        // パーティクルの終了挙動をエミッター停止 & エミッションのクリアとする


//        // パーティクルを1秒のワンショット再生とする
//        // (ので約1秒後にパーティクルは停止する)

//        // パーティクルが終了したらプールに返却するための
//        // 挙動を実装したコンポーネントをアタッチ
//        //var returnToPool = go.AddComponent<ReturnToPool>();
//        //returnToPool.Pool = Pool;


//        //return ps;
//    }

//    void OnTakeFromPool(GameObject game)
//    {

//        // プールからパーティクルシステムを借りるときに
//        // そのオブジェクトのアクティブをONにする
//        game.gameObject.SetActive(true);
//    }

//    void OnReturnedToPool(GameObject game)
//    {

//        // 逆にプールにパーティクルシステムを返却するときに
//        // そのオブジェクトのアクティブをOFFにする
//        this.gameObject.SetActive(false);
//    }

//    void OnDestroyPoolObject(GameObject game)
//    {

//        // プールされたパーティクルの削除が要求されているので、
//        // オブジェクトを破棄する。
//        //
//        // OnCreatePoolObjectでオブジェクトを生成しているので
//        // ここで破棄する責務があるという解釈
//        Destroy(this.gameObject);
//    }




//}