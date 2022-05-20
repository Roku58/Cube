using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField, Min(0)] public int level = 1;//���݃��x��
    [SerializeField, Min(0)] public int exp = 0;//���݌o���l
    [SerializeField, Min(0)] public int expPool = 100;//�K�v�o���l
    [SerializeField, Min(0)] public int playerLife = 100;//�̗�
    [SerializeField, Min(0)] public int playerMaxLife = 100;//�ő�̗�


    void Start()
    {
        playerLife = playerMaxLife;
    }

    void Update()
    {
        LevelManagar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Exp")
        {
            exp += 10;
            Destroy(collision.gameObject);
        }
    }

    void LevelManagar()//���x���Ǘ�
    {
        if(exp == expPool)
        {
            LevelUp();
        }
    }

    void LevelUp()//���x�����オ�����ۂ̏���
    {
        exp = 0;
        playerMaxLife += 10;
        playerLife = playerMaxLife;
        expPool += 10;
        level ++;
        Debug.Log("�v���C���[�̃��x����" + level + " �ɂȂ����I");
        Debug.Log("���̃��x���܂�" + expPool + " �K�v");
    }

    public void Damage(int damage)
    {

            playerLife -= damage;
            Debug.Log(damage + " �_���[�W���󂯂ăv���C���[��HP�� " + playerLife + " �ɂȂ����I");
    }

    void Death()
    {
        Debug.Log("���S");
    }
}

