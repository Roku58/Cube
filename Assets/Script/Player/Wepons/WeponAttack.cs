using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponAttack : MonoBehaviour
{
    [SerializeField] GameObject _wepon;
    [SerializeField] public int index;
    [SerializeField] public float waitTime;

    [SerializeField] bool _randomPos;
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
        AtackManager();

    }

    void AtackManager()
    {
        if(_randomPos)
        {
            StartCoroutine("Atack");

        }
        else
        {
            StartCoroutine("Atack2");

        }

    }

    IEnumerator Atack()
    {
       
        for (int i = 0; i < index; i++)
        {
            _playerPos = GameObject.FindGameObjectWithTag("Player");
            Vector3 pos = _playerPos.transform.position;
            pos.x += Random.Range(-10, 10);
            pos.z += Random.Range(-10, 10);
            Instantiate(_wepon, pos, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator Atack2()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = _playerPos.transform.position;
        for (int i = 0; i < index; i++)
        {
            Instantiate(_wepon, pos, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
    void Death()
    {
        Destroy(this);
    }
}
