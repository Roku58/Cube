using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyGenerator1 : MonoBehaviour
{
    [SerializeField, Tooltip(""), Range(0, 1)] float _time = 0.05f;
    [SerializeField, Tooltip("")] Enemy _prefab = null;
    [SerializeField, Tooltip("")] Transform _root = null;
    GameObject player;
    float _timer = 0.0f;
    float _cRad = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);
    EnemyPools<Enemy> _enemyPool = new EnemyPools<Enemy>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _enemyPool.SetBaseObj(_prefab, _root);
        _enemyPool.SetCapacity(1000);

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
        var script = _enemyPool.Instantiate();
        /*
        var go = GameObject.Instantiate(_prefab);
        var script = go.GetComponent<Enemy>();
        */
        _popPos.x = player.transform.position.x + 100 * Mathf.Cos(_cRad);
        _popPos.z = player.transform.position.z + 100 * Mathf.Sin(_cRad);
        script.transform.position = _popPos;
        _cRad += 0.1f;
    }
}
