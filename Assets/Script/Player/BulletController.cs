using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    [SerializeField] float _lifeTime = 3f;
    public int damage = 10;
    public GameObject explosionPrefab;
    //[SerializeField] Rigidbody rb;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * _speed;  // 「前」に飛ばす
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            collision.gameObject.GetComponent<EnemyController>().Damage(damage);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 1.0f);
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            other.gameObject.GetComponent<EnemyController>().Damage(damage);
        }

        if(other.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 1.0f);
        };
    }
}
