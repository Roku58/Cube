using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    [SerializeField] float _lifeTime = 3f;
    public int damage = 10;
    public GameObject explosionPrefab;


    private void Start()
    {
        Bullet();
    }
    void Update()
    {
    }

    void Bullet()
    {
        Rigidbody _rb = GetComponent<Rigidbody>();
        Vector3 directionToTarget;
        Destroy(this.gameObject, _lifeTime);
        GameObject targetObject = GameObject.FindWithTag("Enemy");
        if (targetObject)
        {
            directionToTarget = (targetObject.transform.position - transform.position).normalized;
            _rb.velocity = directionToTarget * 30;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().GetDamage(damage);
            Destroy(this.gameObject);
            //GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            //Destroy(effect, 1.0f);
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    }
}
