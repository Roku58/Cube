using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator1 : MonoBehaviour
{
    [SerializeField, Tooltip(""), Min(0)] float _time = 0.05f;
    [SerializeField, Tooltip(""), Min(0)] int _poolsizu = 100;
    [SerializeField, Tooltip("")] Enemy[] _prefab = null;
    [SerializeField, Tooltip("")] Transform _root = null;

    public bool spawnEnabled = false;//ÉXÉ|Å[ÉìON OFF
    [SerializeField] int maxEnemies = 1000;//ç≈ëÂêî
    [SerializeField] float minPositionX = -10;//
    [SerializeField] float maxPositonX = 10;//
    [SerializeField] float minPositionZ = -10;//
    [SerializeField] float maxPositonZ = 10;//
    [SerializeField] float minSpawnInterval = 1;//
    [SerializeField] float maxSpawnInterval = 5;//
    //[SerializeField] GameObject[] enemyPrefabs;//
    bool spawning = false;

    GameObject player;
    float _timer = 0.0f;
    [SerializeField] float _cRad = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);
    ObjectPool<Enemy> _enemyPool = new ObjectPool<Enemy>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var x = Random.Range(0, _prefab.Length );
        _enemyPool.SetBaseObj(_prefab[x], _root);
        _enemyPool.SetCapacity(_poolsizu);

        //GameManager.Instance.Setup();

        //for (int i = 0; i < 900; ++i) Spawn();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _time)
        {
            Spawn();
            _timer -= _time;
        }
    }

    void Spawn()
    {
        if (!player)
        {
            return;
        }

        var script = _enemyPool.Instantiate();
        if (!script)
        {
            return;
        }

        /*
        var go = GameObject.Instantiate(_prefab);
        var script = go.GetComponent<Enemy>();
        */
        _popPos.x = player.transform.position.x + 20 * Mathf.Cos(_cRad);
        _popPos.z = player.transform.position.z + 20 * Mathf.Sin(_cRad);
        script.transform.position = _popPos;
        _cRad += 1f;
    }


}
