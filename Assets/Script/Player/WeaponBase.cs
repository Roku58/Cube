using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>武器の基底クラス </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField, Tooltip("武器レベル")] int _weponLevel = 0;
    [SerializeField, Tooltip("次の攻撃までの時間（間隔）")] int _attackInterval = 0;
    [SerializeField, Tooltip("敵に与えるダメージ")] int _damage = 0;
    [SerializeField, Tooltip("ノックバック時にかける力")] int _knockBackPower = 0;
    [SerializeField, Tooltip("移動速度")] int _moveSpeed = 0;
    [SerializeField, Tooltip("生成数")] int _generatorNumber = 1;

    public int damage = 10;
    [SerializeField] GameObject hitef; //ヒットエフェクト

    int _currentLevel = 1;
  
    /// <summary>オブジェクトの動き </summary>
    /// <param name="vector3">進行方向</param>
    public abstract void Move(Transform playerTransform);

    /// <summary>一定間隔ごとに武器を生成する </summary>
    /// <param name="playerTransform">プレイヤーの位置</param>
    public abstract IEnumerator Generator(Transform playerTransform);

    public void GameObjectGenerator(GameObject weaponObject, Transform playerTransform)
    {
        for (var i = 0; i < _generatorNumber; i++)
        {
            var offsetX = Random.Range(-1.0f, 1.0f);
            var offsetY = Random.Range(-1.0f, 1.0f);
            var generationPos = new Vector3(playerTransform.position.x + offsetX, playerTransform.position.y + offsetY, 0);
            var go = Instantiate(this, generationPos, Quaternion.identity);
            go.Move(playerTransform);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().GetDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().GetDamage(damage);
        }
    }
}
