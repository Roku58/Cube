using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>����̊��N���X </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField, Tooltip("���탌�x��")] int _weponLevel = 0;
    [SerializeField, Tooltip("���̍U���܂ł̎��ԁi�Ԋu�j")] int _attackInterval = 0;
    [SerializeField, Tooltip("�G�ɗ^����_���[�W")] int _damage = 0;
    [SerializeField, Tooltip("�m�b�N�o�b�N���ɂ������")] int _knockBackPower = 0;
    [SerializeField, Tooltip("�ړ����x")] int _moveSpeed = 0;
    [SerializeField, Tooltip("������")] int _generatorNumber = 1;

    public int damage = 10;
    [SerializeField] GameObject hitef; //�q�b�g�G�t�F�N�g

    int _currentLevel = 1;
  
    /// <summary>�I�u�W�F�N�g�̓��� </summary>
    /// <param name="vector3">�i�s����</param>
    public abstract void Move(Transform playerTransform);

    /// <summary>���Ԋu���Ƃɕ���𐶐����� </summary>
    /// <param name="playerTransform">�v���C���[�̈ʒu</param>
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
