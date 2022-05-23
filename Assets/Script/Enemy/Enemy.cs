using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool
{
    [SerializeField] float _speed = 10;
    SpriteRenderer _image;

    [SerializeField, Tooltip(""), Min(0)] int maxHp = 100;
    [SerializeField, Tooltip(""), Min(0)] int hp = 100;
    [SerializeField, Tooltip(""), Min(0)] int atk = 1;
    [SerializeField, Tooltip(""), Min(0)] float speed = 1;
    GameObject player; //
    [SerializeField, Tooltip("")] GameObject bullet; //�e
    [SerializeField, Tooltip("")] GameObject death; //����
    [SerializeField, Tooltip("")] GameObject hitef; //�q�b�g�G�t�F�N�g
    [SerializeField, Tooltip("")] Transform muzzle; //�}�Y��
    Animator _anim = default;
    Rigidbody rb = default;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsActive) return;

        Vector3 sub = player.transform.position - transform.position;
        sub.Normalize();

        transform.position += sub * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerState>().Damage(atk);
            //var obj = Instantiate(death, this.transform.position, Quaternion.identity);
            Destroy();
        }
    }

    public void Damage()
    {
        Destroy();

        //TODO
        //GameManager.Instance.GetExperience(1);
    }

    //ObjectPool
    bool _isActrive = false;
    public bool IsActive => _isActrive;
    public void DisactiveForInstantiate()
    {
        gameObject.SetActive(false);
        _isActrive = false;
    }
    public void Create()
    {
        gameObject.SetActive(true);
        _isActrive = true;
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
        
        //if(death.transform.parent != null)
        //{
        //    death.SetActive(true);
        //    death.transform.parent = null;

        //}
        _isActrive = false;
    }
}
