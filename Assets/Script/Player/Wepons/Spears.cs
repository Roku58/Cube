using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spears : MonoBehaviour
{
    [SerializeField] GameObject _spear;
    GameObject _playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = _playerPos.transform.position;
        pos.x += Random.Range(-10, 10);
        pos.z += Random.Range(-10, 10);
        Instantiate(_spear, pos, Quaternion.identity);
    }

    void Death()
    {
        Destroy(this);
    }
}
